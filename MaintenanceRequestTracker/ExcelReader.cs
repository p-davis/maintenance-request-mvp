using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MaintenanceRequestTracker
{
    public class ExcelReader
    {
        private DataTable excelDt;

        private string filePath;

        private string FilePath
        {
            get
            {
                return this.filePath;
            }

            set
            {
                this.filePath = value;
            }
        }

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

        public DataTable ExcelDt
        {
            get
            {
                return this.excelDt;
            }

            set
            {
                this.excelDt = value;
            }
        }

        public ExcelReader()
        {
            this.ExcelDt = new DataTable();
        }

        public bool LoadExcelDataIntoTable()
        {
            if (this.SetFilePath())
            {
                this.ReadExcelData();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks that <seealso cref="filePath"/> is of valid type (Excel Spreadsheet) by checking file extension.
        /// </summary>
        /// <returns>Returns true if valid, false if invalid or null.</returns>
        private bool IsValidFileType()
        {
            if (Path.GetExtension(this.FilePath) != null)
            {
                var fileExtension = Path.GetExtension(this.FilePath);

                if (fileExtension.Equals(".xlsx") || fileExtension.Equals(".xls"))
                {
                    Console.WriteLine("valid file type");
                    return true;
                }
                else
                {
                    Console.WriteLine("invalid file type");
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Opens file browser dialog to select file that is to be read into DataGridView. Assigns this file path to <see cref="filePath"/>
        /// </summary>
        private bool SetFilePath()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Select Excel file";
                ofd.InitialDirectory = @"H:\";
                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(ofd.FileName))
                {
                    this.FilePath = ofd.FileName;
                    if (!this.IsValidFileType())
                    {
                        this.FilePath = null;
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("open file dialog cancelled");
                    return false;
                }
            }
        }

        /// <summary>
        /// Reads Excel spreadsheet data into <see cref="MainView.sqlDgv"/>
        /// Auto-detects format, supports: Binary Excel files (2.0-2003 format; *.xls) / OpenXml Excel files (2007 format; *.xlsx)
        /// </summary>
        private void ReadExcelData()
        {
            using (var stream = File.Open(this.FilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    // Gets or sets a callback to obtain configuration options for a DataTable
                    ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                    {
                        // Gets or sets a value indicating whether to use a row from the data as column names
                        UseHeaderRow = true
                    }
                });

                // create data table and fill with excel data
                this.ExcelDt = result.Tables[0];

                // check that columns are valid
                this.IsColumnValid();

                // ensure that table is sorted by request id in ascending order - important for comparison in CompareTables()
                this.ExcelDt.DefaultView.Sort = $"{this.excelColumnHeaderNames[0]} ASC";
                this.ExcelDt = this.ExcelDt.DefaultView.ToTable();
            }

           //this.InsertDataTable();
        }

        public void IsColumnValid()
        {
            if (!this.IsColumnCountValid())
            {
                MessageBox.Show("Invalid number of columns - must be 11", "Error - Invalid Column Count");
                throw new Exception("Invalid number of columns");
            }

            if (!this.IsColumnHeaderValid())
            {
                var sb = new StringBuilder();
                foreach (string s in this.excelColumnHeaderNames)
                {
                    sb.Append(s + "\n");
                }

                MessageBox.Show($"Invalid column header names: First row of Excel spreadsheet must match:\n{sb}", "Error - Invalid Column Header Names");
                throw new Exception("Invalid column names");
            }
        }
        
        private bool IsColumnCountValid()
        {
            // check for correct number of expected columns
            if (this.ExcelDt.Columns.Count != 11)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsColumnHeaderValid()
        {
            // check that column names are correct - requires correct order
            for (int i = 0; i < this.ExcelDt.Columns.Count; i++)
            {
                if (!this.ExcelDt.Columns[i].ColumnName.Equals(this.excelColumnHeaderNames[i]))
                {
                    return false;
                }

            }
            return true;
        }

        private void InsertDataTable()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MaintenanceRequest"].ConnectionString))
            using (SqlBulkCopy sbc = new SqlBulkCopy(conn))
            {
                try
                {
                    conn.Open();
                    sbc.DestinationTableName = "MaintenanceRequest";

                    // Number of records to be processed in one go
                    sbc.BatchSize = this.ExcelDt.Rows.Count;

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

                    // write to server
                    sbc.WriteToServer(this.ExcelDt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
