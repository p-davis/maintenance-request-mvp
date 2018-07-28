using System;
using MaintenanceRequestTracker.Views;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Resources;

namespace MaintenanceRequestTracker.Presenters
{
    /// <summary>
    /// Acts upon <see cref="MaintenanceDataSet"/> and <see cref="MainView"/>. Retrieves data from <see cref="MaintenanceDataSet"/>, and formats it for display in <see cref="MainView"/>.
    /// </summary>
    class MainPresenter
    {
        private IMainView mainView;

        //private AddRequestPresenter addRequestPresenter;

        private EditRequestPresenter editRequestPresenter;

        private ExcelReader excelReader;

        private List<string> updateList = new List<string>();

        /// <summary>
        /// Holds valid Excel column header names
        /// </summary>
        private readonly List<string> excelColumnHeaderNames = new List<string>()
        {
            "Maintenance Request ID",
            "Item Type",
            "Item ID",
            "Maintenance Type",
            "STATUS",
            "Description",
            "Date Requested",
            "Date Required",
            "Entered By",
            "Last Modified",
            "Modified By",
            "Comments"
        };

        private readonly List<string> statusList = new List<string>()
        {
            "ongoing",
            "assigned",
            "closed",
            "cancelled",
            "not assigned",
            "out of service"
        };

        public MainPresenter(IMainView view)
        {
            this.mainView = view;
            //this.addRequestPresenter = new AddRequestPresenter(this.mainView);
            this.editRequestPresenter = new EditRequestPresenter(this.mainView);
            this.excelReader = new ExcelReader();
            this.SubscribeToEvents();
            this.SetDgvDoubleBuffered();

        }

        private void SetDgvDoubleBuffered()
        {
            typeof(DataGridView).InvokeMember(
                    "DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null,
                    this.mainView.SqlDgv,
                    new object[] { true });

            typeof(DataGridView).InvokeMember(
                                "DoubleBuffered",
                                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                                null,
                                this.mainView.ChangeDgv,
                                new object[] { true });
        }

        private void SubscribeToEvents()
        {
            // main form load event
            this.mainView.MainViewLoad += MainView_MainViewLoad;

            // button events
            this.mainView.ImportButtonClicked += MainView_ImportButtonClicked;
            this.mainView.UpdateButtonClicked += MainView_UpdateButtonClicked;
            this.mainView.ClearButtonClicked += MainView_ClearButtonClicked;
            this.mainView.AddButtonClicked += MainView_AddButtonClicked;
            this.mainView.EditButtonClicked += MainView_EditButtonClicked;
            this.mainView.HelpButtonClicked += MainView_HelpButtonClicked;

            // sql datagridview events
            this.mainView.SqlDgvDataError += MainView_SqlDgvDataError;
            this.mainView.SqlDgvCellValidating += MainView_SqlDgvCellValidating;
            this.mainView.SqlDgvMouseDown += MainView_SqlDgvMouseDown;
            this.mainView.EditRequestContextMenuItemClicked += MainView_EditRequestContextMenuItemClicked;

            // tab events
            this.mainView.ChangeTabEnter += MainView_ChangeTabEntered;
            this.mainView.ChangeTabLeave += MainView_ChangeTabLeave;
            this.mainView.ClosedTabEnter += MainView_ClosedTabEnter;
            this.mainView.ClosedTabLeave += MainView_ClosedTabLeave;
            this.mainView.OpenTabEnter += MainView_OpenTabEnter;
            this.mainView.OpenTabLeave += MainView_OpenTabLeave;
            this.mainView.TabSelected += MainView_TabSelected;
        }

        private void MainView_HelpButtonClicked(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Open user guide?", "PDF File Open", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string filePath = Path.Combine(Environment.CurrentDirectory, "help.pdf");
                Process.Start(filePath);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void MainView_MainViewLoad(object sender, EventArgs e)
        {
            this.mainView.MainForm.Show();
            this.mainView.MaintenanceRequestBindingSource.Filter = "status <> 'Closed'";
            this.FillTable();
            this.mainView.OpenTab.Select();
        }

        #region Button events

        private void MainView_ImportButtonClicked(object sender, EventArgs e)
        {
            this.ReadExcelData();
            this.mainView.MainTabControl.SelectedTab.Select();
        }

        private void MainView_UpdateButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Update database with changes?", "Update Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.mainView.MaintenanceRequestBindingSource.EndEdit();
                    this.mainView.MaintenanceRequestTableAdapter.Update(this.mainView.MaintenanceDataSet.MaintenanceRequest);
                    MessageBox.Show("Update successful");
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Update failed");
            }
        }

        private void MainView_ClearButtonClicked(object sender, EventArgs e)
        {
            if (MessageBox.Show("Undo all changes since last update?", "Undo Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.FillTable();
            }
        }

        private void MainView_AddButtonClicked(object sender, EventArgs e)
        {
            // this.addRequestPresenter.AddRequest();
        }

        private void MainView_EditButtonClicked(object sender, EventArgs e)
        {
            DataGridViewRow r = this.mainView.GetCurrentRow;
            this.editRequestPresenter.EditRequest(r);
            //this.FillTable();
            //this.mainView.SqlDgv.ClearSelection();
        }

        #endregion

        #region DataGridView events

        private void MainView_SqlDgvDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine("dgv data error");
            this.mainView.SqlDgv.CancelEdit();
        }

        private void MainView_SqlDgvCellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewCell cell = this.mainView.SqlDgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            var columnName = cell.OwningColumn.Name;

            if (columnName.Equals("statusColumn"))
            {
                this.ValidateStatus(cell, e);
            }
            else if (columnName.Equals("dateRequestedColumn"))
            {
                this.ValidateDateRequested(cell, e);
            }
            else if (columnName.Equals("dateRequiredColumn"))
            {
                this.ValidateDateRequired(cell, e);
            }
            else if (columnName.Equals("lastModifiedColumn"))
            {
                this.ValidateLastModified(cell, e);
            }
            this.UpdateRequestCountLabel();
        }

        private void ValidateStatus(DataGridViewCell cell, DataGridViewCellValidatingEventArgs e)
        {
            string status = e.FormattedValue.ToString().Trim().ToLower();

            if (this.statusList.Contains(status))
            {
                if (status.Equals("out of service"))
                {
                    cell.Value = "Out of Service";
                }
                else
                {
                    cell.Value = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(status);
                }
                this.mainView.SqlDgv.RefreshEdit();
            }
            else
            {
                MessageBox.Show("invalid status");
                this.mainView.SqlDgv.CancelEdit();
            }
        }

        private void ValidateDateRequested(DataGridViewCell cell, DataGridViewCellValidatingEventArgs e)
        {
            DateTime date;
            // make sure date is entered
            if (DateTime.TryParse(e.FormattedValue.ToString(), out date))
            {
                cell.Value = date.AddHours(0).AddMinutes(0);
                Console.WriteLine(date.ToString());
                this.mainView.SqlDgv.RefreshEdit();
            }
            else
            {
                // if no valid date/time is passed - print error and cancel edit
                Console.WriteLine("enter valid date/time");
                this.mainView.SqlDgv.CancelEdit();
            }
        }

        private void ValidateDateRequired(DataGridViewCell cell, DataGridViewCellValidatingEventArgs e)
        {
            DateTime date;

            if (DateTime.TryParse(e.FormattedValue.ToString(), out date))
            {
                cell.Value = date.AddHours(0).AddMinutes(0);
                Console.WriteLine(date.ToString());
                this.mainView.SqlDgv.RefreshEdit();
            }
            // date requried column allows nothing to be entered
            else if (string.IsNullOrWhiteSpace(e.FormattedValue.ToString()))
            {
                Console.WriteLine("nothing");
            }
            else
            {
                Console.WriteLine("enter valid date/time");
                this.mainView.SqlDgv.CancelEdit();
            }
        }

        private void ValidateLastModified(DataGridViewCell cell, DataGridViewCellValidatingEventArgs e)
        {
            DateTime date;
            if (DateTime.TryParse(e.FormattedValue.ToString(), out date))
            {
                cell.Value = date;
                Console.WriteLine(date.ToString());
                this.mainView.SqlDgv.RefreshEdit();
            }
            else
            {
                Console.WriteLine("enter valid date/time");
                this.mainView.SqlDgv.CancelEdit();
            }
        }

        private void MainView_EditRequestContextMenuItemClicked(object sender, EventArgs e)
        {
            DataGridViewRow r = this.mainView.GetCurrentRow;
            this.editRequestPresenter.EditRequest(r);
        }

        private void MainView_SqlDgvMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.mainView.SqlDgv.CurrentCell != this.mainView.SqlDgv.Rows[e.RowIndex].Cells[e.ColumnIndex])
                {
                    // clears previous cell selection and sets clicked cell as current selection
                    this.mainView.SqlDgv.ClearSelection();
                    this.mainView.SqlDgv.CurrentCell = this.mainView.SqlDgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                }
            }
        }

        #endregion

        #region Tab events

        private void MainView_TabSelected(object sender, TabControlEventArgs e)
        {
            this.FillTable();
        }

        private void MainView_OpenTabLeave(object sender, EventArgs e)
        {
            this.mainView.RequestCountLabel.Visible = false;
        }

        private void MainView_ClosedTabLeave(object sender, EventArgs e)
        {
            this.mainView.RequestCountLabel.Visible = false;
        }

        private void MainView_OpenTabEnter(object sender, EventArgs e)
        {
            if (!this.mainView.OpenTab.Controls.Contains(this.mainView.SqlDgv))
            {
                this.mainView.OpenTab.Controls.Add(this.mainView.SqlDgv);
            }
            this.mainView.MaintenanceRequestBindingSource.Filter = "status <> 'Closed'";
            this.FillTable();
        }

        private void MainView_ClosedTabEnter(object sender, EventArgs e)
        {
            if (!this.mainView.ClosedTab.Controls.Contains(this.mainView.SqlDgv))
            {
                this.mainView.ClosedTab.Controls.Add(this.mainView.SqlDgv);
            }
            this.mainView.MaintenanceRequestBindingSource.Filter = "status = 'Closed'";
            this.FillTable();
        }

        private void MainView_ChangeTabLeave(object sender, EventArgs e)
        {
            this.mainView.UpdateButton.Enabled = true;
            this.mainView.ClearButton.Enabled = true;
            this.mainView.EditButton.Enabled = true;
            this.mainView.ColorLabel.Visible = false;
            this.mainView.GreenSquare.Visible = false;
        }

        private void MainView_ChangeTabEntered(object sender, EventArgs e)
        {
            this.mainView.UpdateButton.Enabled = false;
            this.mainView.ClearButton.Enabled = false;
            this.mainView.RequestCountLabel.Visible = false;
            this.mainView.EditButton.Enabled = false;
            if (this.mainView.ChangeDgv.RowCount > 0)
            {
                this.mainView.ColorLabel.Visible = true;
                this.mainView.GreenSquare.Visible = true;
            }
            this.mainView.ChangeDgv.ClearSelection();
        }

        #endregion

        private void UpdateRequestCountLabel()
        {
            this.mainView.RequestCountLabel.Text = $"{this.mainView.SqlDgv.RowCount} Requests Found";
            this.mainView.RequestCountLabel.Visible = true;
        }

        private void FillTable()
        {
            this.mainView.MaintenanceRequestTableAdapter.Fill(this.mainView.MaintenanceDataSet.MaintenanceRequest);
            this.UpdateRequestCountLabel();
        }

        private void ReadExcelData()
        {
            try
            {
                if (this.excelReader.LoadExcelDataIntoTable())
                {
                    //this.view.SqlDgv.DataSource = this.dtManager.SqlDt;
                    if(this.mainView.MaintenanceRequestTableAdapter.CountRows().ToString().Equals("0"))
                    {
                        this.AddAllExcelRows();
                    }
                    else if (this.CompareTables())
                    {
                        // software is up to date with database
                        Console.WriteLine("Up to date with database");
                        this.mainView.ChangeDgv.DataSource = null;
                    }
                    
                }
                //else
                //{
                //    this.mainView.ChangeDgv.DataSource = null;
                //}
            }
            catch (Exception ex)
            {
                this.mainView.ChangeDgv.DataSource = null;
                this.mainView.OpenTab.Select();
                Console.WriteLine("ReadExcelData() error");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
            }
        }

        private bool CompareTables()
        {
            this.mainView.MainTabControl.SelectedTab = this.mainView.ChangeTab;
            var currentRowIndex = -1;

            // idList holds request id numbers of all requests to be updated in maintenance software
            var changeIdList = new List<int>();
            var addIdList = new List<int>();

            // keeps track of cell indexes used when adding color
            var rowIndexList = new List<int>();
            var columnIndexList = new List<int>();

            // copy tblMaintenanceRequest table to Data Table
            var dt = this.mainView.MaintenanceRequestTableAdapter.GetData().CopyToDataTable();

            // begin checking for differences between the database table and the Excel table
            for (int i = 0; i < this.excelReader.ExcelDt.Rows.Count; i++)
            {
                // bool to make sure that row id is only added to idList once, even if multiple column values are different to sql table
                bool rowErrorFlag = false;

                // dt.Columns.Count - 4, so that last 4 columns are not included in comparison
                for (int c = 0; c < dt.Columns.Count - 4; c++)
                {
                    // make sure the number of row comparisons does not exceed total number of rows in Excel document
                    // if i exceeds the Excel row count then these must be new maintenance requests
                    if (i < dt.Rows.Count)
                    {                   
                        if (!Equals(dt.Rows[i][c].ToString().Trim(), this.excelReader.ExcelDt.Rows[i][c].ToString().Trim()))
                        {
                            Console.WriteLine(this.excelReader.ExcelDt.Rows[i][c].ToString());
                            if (!rowErrorFlag)
                            {
                                //this.changeDt.ImportRow(this.dtManager.ExcelDt.Rows[i]);
                                rowErrorFlag = true;
                                currentRowIndex++;
                                changeIdList.Add(Convert.ToInt32(this.excelReader.ExcelDt.Rows[i][0]));
                            }
                            rowIndexList.Add(currentRowIndex);
                            columnIndexList.Add(c);
                        }
                    }
                    else
                    {
                        if (!rowErrorFlag)
                        {
                            addIdList.Add(Convert.ToInt32(this.excelReader.ExcelDt.Rows[i][0]));

                            rowErrorFlag = true;
                            // add to database
                            Console.WriteLine("new row");
                        }                        
                    }
                }               
            }

            foreach (int id in addIdList)
            {
                Console.WriteLine(id);
            }

            if (currentRowIndex < 0 && addIdList.Count == 0)
            {
                // return true if no differences between tables are found
                return true;
            }
            else
            {
                Console.WriteLine(addIdList.Count);
                
                this.FilterByIdList(changeIdList);
                this.FormatChangeDgv();
                this.AddColorToChangeDgv(rowIndexList, columnIndexList);
                if (addIdList.Count > 0)
                {
                    if (addIdList.Count == 1)
                    {
                        MessageBox.Show($"{addIdList.Count} new request imported", "Requests Added");
                    }
                    else
                    {
                        MessageBox.Show($"{addIdList.Count} new requests imported", "Requests Added");
                    }
                    this.AddNewExcelRows(addIdList);
                }
                return false;
            }
        }

        private void AddAllExcelRows()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MaintenanceRequest"].ConnectionString))
            using (SqlBulkCopy sbc = new SqlBulkCopy(conn))
            {
                try
                {
                    conn.Open();
                    sbc.DestinationTableName = "MaintenanceRequest";

                    // Number of records to be processed in one go
                    sbc.BatchSize = this.excelReader.ExcelDt.Rows.Count;

                    // create table of new DataRows to be added from Excel spreadsheet
                    // 
                    var dt = this.excelReader.ExcelDt.Rows.Cast<DataRow>().CopyToDataTable();

                    // Add column mappings
                    sbc.ColumnMappings.Add("Maintenance Request ID", "request_id");
                    sbc.ColumnMappings.Add("Item Type", "item_type");
                    sbc.ColumnMappings.Add("Item ID", "item_id");
                    sbc.ColumnMappings.Add("Maintenance Type", "maintenance_type");
                    sbc.ColumnMappings.Add("STATUS", "status");
                    sbc.ColumnMappings.Add("Description", "description");
                    sbc.ColumnMappings.Add("Date Requested", "date_requested");
                    sbc.ColumnMappings.Add("Date Required", "date_required");
                    sbc.ColumnMappings.Add("Entered By", "entered_by");
                    sbc.ColumnMappings.Add("Last Modified", "last_modified");
                    sbc.ColumnMappings.Add("Modified By", "modified_by");
                    // sbc.ColumnMappings.Add("Comments", "comments");

                    // Finally write to server
                    sbc.WriteToServer(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void AddNewExcelRows(List<int> addIdList)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MaintenanceRequest"].ConnectionString))
            using (SqlBulkCopy sbc = new SqlBulkCopy(conn))
            {
                try
                {
                    conn.Open();
                    sbc.DestinationTableName = "MaintenanceRequest";

                    // Number of records to be processed in one go
                    sbc.BatchSize = addIdList.Count;

                    // create table of new DataRows to be added from Excel spreadsheet
                    // 
                    var dt = this.excelReader.ExcelDt.Rows.Cast<DataRow>().Reverse().Take(addIdList.Count).CopyToDataTable();
                    
                    // Add column mappings
                    sbc.ColumnMappings.Add("Maintenance Request ID", "request_id");
                    sbc.ColumnMappings.Add("Item Type", "item_type");
                    sbc.ColumnMappings.Add("Item ID", "item_id");
                    sbc.ColumnMappings.Add("Maintenance Type", "maintenance_type");
                    sbc.ColumnMappings.Add("STATUS", "status");
                    sbc.ColumnMappings.Add("Description", "description");
                    sbc.ColumnMappings.Add("Date Requested", "date_requested");
                    sbc.ColumnMappings.Add("Date Required", "date_required");
                    sbc.ColumnMappings.Add("Entered By", "entered_by");
                    sbc.ColumnMappings.Add("Last Modified", "last_modified");
                    sbc.ColumnMappings.Add("Modified By", "modified_by");
                    // sbc.ColumnMappings.Add("Comments", "comments");

                    // Finally write to server
                    sbc.WriteToServer(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void FilterByIdList(List<int> idList)
        {
            // create filter query using maintenance request ids in idList
            var sb = new StringBuilder();
            sb.Append("request_id IN ('" + string.Join("', '", idList) + "')");
            Console.WriteLine(sb.ToString());

            // filter database table using sb query and set as DGV's data source
            this.mainView.MaintenanceDataSet.MaintenanceRequest.DefaultView.RowFilter = sb.ToString();
            DataTable filteredDt = this.mainView.MaintenanceDataSet.MaintenanceRequest.DefaultView.ToTable();
            this.mainView.ChangeDgv.DataSource = filteredDt;
        }

        private void FormatChangeDgv()
        {
            // changeDgv formatting
            for (int i = 0; i < this.mainView.ChangeDgv.Columns.Count; i++)
            {
                // get column header text
                DataGridViewColumn column = this.mainView.ChangeDgv.Columns[i];
                column.HeaderText = this.excelColumnHeaderNames[i];

                // set sort mode to NotSortable, so that colors can be added in correct position
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

                this.mainView.ChangeDgv.Columns["Description"].Width = 300;
                this.mainView.ChangeDgv.Columns["Comments"].Width = 300;
            }
        }

        private void AddColorToChangeDgv(List<int> rowIndexList, List<int> columnIndexList)
        {
            // finally use index lists to apply colors to cells that need to be updated in maintenance software
            for (int i = 0; i < rowIndexList.Count; i++)
            {
                this.mainView.ChangeDgv.Rows[rowIndexList[i]].Cells[columnIndexList[i]].Style.BackColor = Color.LightGreen;
            }

            // calculate number of distinct rows with changes - used to color new rows
            var distinctRow = (from x in rowIndexList select x).Distinct().Count();

            // color new maintenance requests that are present in tblMaintenenaceRequests, but not in maintenance software
            for (int i = distinctRow; i < this.mainView.ChangeDgv.RowCount; i++)
            {
                this.mainView.ChangeDgv.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

    }
}

