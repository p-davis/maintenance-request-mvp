using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using MaintenanceRequestTracker.Views;
using MaintenanceRequestTracker.Views.RequestViews;

namespace MaintenanceRequestTracker.Presenters
{
    /// <summary>
    /// Retrieves data from selected <see cref="DataGridViewRow"/> of <see cref="MainView"/>, and formats it for display in <see cref="EditRequestView"/>.
    /// On AcceptButtonClicked the values of <see cref="EditRequestView"/> are updated in <see cref="cs3liveDataSet"/>.
    /// </summary>
    class EditRequestPresenter
    {
        /// <summary>
        /// <see cref="IMainView"/> field gives <see cref="AddRequestPresenter"/> access to <see cref="MainView"/>'s events and fields
        /// </summary>
        private IMainView mainView;

        private IRequestView editRequestView;

        public EditRequestPresenter(IMainView view)
        {
            this.mainView = view;
        }

        public void EditRequest(DataGridViewRow r)
        {
            // create new EditRequestView form
            if (this.editRequestView == null || this.editRequestView.RequestForm.IsDisposed)
            {
                this.editRequestView = new EditRequestView();
                Console.WriteLine("this");
            }

            this.SubscribeToEvents();
            this.GetValuesFromDgvRow(r);

            // show RequestView form
            this.editRequestView.RequestForm.Show();

            // disable user interaction with MainView form until AddRequestView form is closed
            this.mainView.MainForm.Enabled = false;
        }

        private void SubscribeToEvents()
        {
            this.editRequestView.RequestFormShown += EditRequestView_RequestFormShown;
            this.editRequestView.RequestFormClosing += EditRequestView_RequestFormClosing;
            this.editRequestView.AcceptButtonClicked += EditRequestView_AcceptButtonClicked;
            this.editRequestView.CancelButtonClicked += EditRequestView_CancelButtonClicked;
        }

        private void EditRequestView_CancelButtonClicked(object sender, EventArgs e)
        {
            this.editRequestView.RequestForm.Close();
        }

        private void EditRequestView_RequestFormClosing(object sender, FormClosingEventArgs e)
        {
            this.mainView.MainForm.Enabled = true;           
            this.editRequestView.RequestForm.Dispose();
            this.mainView.MainTabControl.SelectedTab.Select();
            this.mainView.SqlDgv.ClearSelection();
        }

        private void EditRequestView_AcceptButtonClicked(object sender, EventArgs e)
        {
            MaintenanceRequest m = new MaintenanceRequest();

            if (this.CreateMaintenanceRequest(m))
            {
                this.UpdateSqlMaintenanceRequest(m);
                this.mainView.MaintenanceRequestTableAdapter.Fill(this.mainView.MaintenanceDataSet.MaintenanceRequest);
            }
            else
            {
                Console.WriteLine("Error creating MR");
            }

            Console.WriteLine("EditRequestView accept button clicked");
        }

        private void EditRequestView_RequestFormShown(object sender, EventArgs e)
        {
            this.editRequestView.DateRequestDtp.Enabled = false;
        }

        private void GetValuesFromDgvRow(DataGridViewRow r)
        {
            this.editRequestView.MaintenanceRequestIdTextLabel.Text = r.Cells["requestIdColumn"].Value.ToString();
            this.editRequestView.ItemTypeTextBox.Text = r.Cells["itemTypeColumn"].Value.ToString();
            this.editRequestView.ItemIdTextBox.Text = r.Cells["itemIdColumn"].Value.ToString();
            this.editRequestView.MaintenanceTypeTextBox.Text = r.Cells["maintenanceTypeColumn"].Value.ToString();
            this.editRequestView.StatusComboBox.SelectedItem = r.Cells["statusColumn"].Value.ToString();
            this.editRequestView.DateRequestDtp.Value = Convert.ToDateTime(r.Cells["dateRequestedColumn"].Value);

            if (r.Cells["dateRequiredColumn"].Value != DBNull.Value)
            {
                this.editRequestView.DateRequiredDtp.Value = Convert.ToDateTime(r.Cells["dateRequiredColumn"].Value);
            }
            else
            {
                this.editRequestView.DateRequiredDtp.Checked = false;
                this.editRequestView.DateRequiredDtp.ShowCheckBox = true;
            }

            this.editRequestView.EnteredByTextLabel.Text = r.Cells["enteredByColumn"].Value.ToString();
            this.editRequestView.LastModifiedTextLabel.Text = r.Cells["lastModifiedColumn"].Value.ToString();
            this.editRequestView.ModifiedByTextLabel.Text = r.Cells["modifiedByColumn"].Value.ToString();
            this.editRequestView.DescriptionText = r.Cells["descriptionColumn"].Value.ToString();
            this.editRequestView.CommentsText = r.Cells["commentsColumn"].Value.ToString();
        }

        /// <summary>
        /// Populates <see cref="MaintenanceRequest"/> fields with the values that are present on <see cref="EditRequestView"/>.
        /// </summary>
        /// <param name="m">New <see cref="MaintenanceRequest"/> object to be populated with <see cref="EditRequestView"/> values.</param>
        /// <returns>True if <see cref="MaintenanceRequest"/> is created successfully. False if an error has occured.</returns>
        private bool CreateMaintenanceRequest(MaintenanceRequest m)
        {
            try
            {
                m.RequestId = Convert.ToInt32(this.editRequestView.MaintenanceRequestIdTextLabel.Text);
                m.ItemType = this.editRequestView.ItemTypeTextBox.Text;
                m.ItemId = this.editRequestView.ItemIdTextBox.Text;
                m.MaintenanceType = this.editRequestView.MaintenanceTypeTextBox.Text;
                m.Status = this.editRequestView.StatusComboBox.SelectedItem.ToString();
                m.DateRequested = this.editRequestView.DateRequestDtp.Value;

                if (this.editRequestView.DateRequiredDtp.Checked)
                {
                    m.DateRequired = DateTime.Parse(this.editRequestView.DateRequiredDtp.Value.ToShortDateString());
                }
                else
                {
                    m.DateRequired = null;
                }

                m.EnteredBy = this.editRequestView.EnteredByTextLabel.Text;
                m.LastModified = DateTime.Now;
                m.ModifiedBy = Environment.UserName.ToString();
                m.Description = this.editRequestView.DescriptionText;
                m.Comments = this.editRequestView.CommentsText;

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private void UpdateSqlMaintenanceRequest(MaintenanceRequest m)
        {
            // validate
            string commandText = "UPDATE MaintenanceRequest SET item_type = @item_type, item_id = @item_id, " +
                                                                "maintenance_type = @maintenance_type, status = @status, description = @description, " +
                                                                "date_requested = @date_requested, date_required = @date_required, entered_by = @entered_by, " +
                                                                "last_modified = @last_modified, modified_by = @modified_by, comments = @comments " +
                                                                "WHERE request_id = @request_id";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MaintenanceRequest"].ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(commandText, conn);
                    command.Parameters.AddWithValue("@request_id", m.RequestId);
                    command.Parameters.AddWithValue("@item_type", m.ItemType);
                    command.Parameters.AddWithValue("@item_id", m.ItemId);
                    command.Parameters.AddWithValue("@maintenance_type", m.MaintenanceType);
                    command.Parameters.AddWithValue("@status", m.Status);
                    command.Parameters.AddWithValue("@description", m.Description);
                    command.Parameters.AddWithValue("@date_requested", m.DateRequested);

                    if (m.DateRequired != null)
                    {
                        command.Parameters.AddWithValue("@date_required", m.DateRequired);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@date_required", DBNull.Value);
                    }

                    command.Parameters.AddWithValue("@entered_by", m.EnteredBy);
                    command.Parameters.AddWithValue("@last_modified", m.LastModified);
                    command.Parameters.AddWithValue("@modified_by", m.ModifiedBy);
                    command.Parameters.AddWithValue("@comments", m.Comments);

                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    this.editRequestView.RequestForm.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
