using MaintenanceRequestTracker.Views;
using MaintenanceRequestTracker.Views.RequestViews;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MaintenanceRequestTracker
{
    class AddRequestPresenter
    {
        /// <summary>
        /// <see cref="IMainView"/> field gives <see cref="AddRequestPresenter"/> access to <see cref="MainView"/>'s events and fields
        /// </summary>
        private IMainView mainView;

        private IRequestView addRequestView;

        public AddRequestPresenter(IMainView view)
        {
            this.mainView = view;
        }

        /// <summary>
        /// Initializes and shows a new instance of <see cref="RequestView"/>
        /// </summary>
        public void AddRequest()
        {
            // create new AddRequestView form
            if (this.addRequestView == null || this.addRequestView.RequestForm.IsDisposed)
            {
                this.addRequestView = new AddRequestView();
            }
            this.SubscribeToEvents();

            // show RequestView form

            this.addRequestView.RequestForm.Show();

            // disable user interaction with MainView form until AddRequestView form is closed
            this.mainView.MainForm.Enabled = false;
        }

        private void SubscribeToEvents()
        {
            this.addRequestView.RequestFormShown += AddRequestView_RequestFormShown;
            this.addRequestView.RequestFormClosing += AddRequestView_RequestFormClosing;
            this.addRequestView.AcceptButtonClicked += AddRequestView_AcceptButtonClicked;
            this.addRequestView.CancelButtonClicked += AddRequestView_CancelButtonClicked;
        }

        private void AddRequestView_CancelButtonClicked(object sender, EventArgs e)
        {
            this.addRequestView.RequestForm.Close();
        }

        private void AddRequestView_AcceptButtonClicked(object sender, EventArgs e)
        {
            // create new maintenance request
            MaintenanceRequest m = new MaintenanceRequest();
            Console.WriteLine("created new MR");


            // attempt to set up new MRt with form values
            if (this.CreateMaintenanceRequest(m))
            {
                // insert new MR to MaintenanceRequest
                this.InsertMaintenanceRequest(m);
                Console.WriteLine("inserted");
            }
            else
            {
                // error
                Console.WriteLine("MR create error");
            }
        }

        private void AddRequestView_RequestFormClosing(object sender, FormClosingEventArgs e)
        {
            this.mainView.MainForm.Enabled = true;
            this.addRequestView.RequestForm.Dispose();
            this.mainView.MainTabControl.SelectedTab.Select();
            this.mainView.SqlDgv.ClearSelection();
        }

        private void AddRequestView_RequestFormShown(object sender, EventArgs e)
        {
            // set Maintenance Request ID Label to disabled 
            this.addRequestView.MaintenanceRequestIdLabel.Enabled = false;

            // hide MaintenanceRequestIdTextLabel
            // this value will be generated when the user clicks accept
            this.addRequestView.MaintenanceRequestIdTextLabel.Visible = false;
            this.addRequestView.StatusComboBox.SelectedIndex = 0;

            // set last modified and modified by to disabled
            // these values will be generated when the user click accept
            this.addRequestView.LastModifiedLabel.Enabled = false;
            this.addRequestView.ModifiedByLabel.Enabled = false;

            // set EnteredByTextLabel to the current user's username
            this.addRequestView.EnteredByTextLabel.Text = Environment.UserName.ToString();

            // hide LastModifiedTextLabel and ModifiedByTextLabel
            // these values will be generated when the user clicks accept
            this.addRequestView.LastModifiedTextLabel.Visible = false;
            this.addRequestView.ModifiedByTextLabel.Visible = false;

            this.addRequestView.DateRequestDtp.Value = DateTime.Now;
            this.addRequestView.DateRequestDtp.Enabled = false;

            // uncheck and display DateRequiredDtp's checkbox
            this.addRequestView.DateRequiredDtp.Checked = false;
            this.addRequestView.DateRequiredDtp.ShowCheckBox = true;
        }

        /// <summary>
        /// Populates new <see cref="MaintenanceRequest"/> object with user values entered into <see cref="RequestView"/> form.
        /// Finally, returns whether validation has been successful or not.
        /// </summary>
        /// <param name="m">New instance of MaintenanceRequest to be populated with user entered values</param>
        /// <returns>Returns true if user value validation is successful, else false</returns>
        private bool CreateMaintenanceRequest(MaintenanceRequest m)
        {
            if (string.IsNullOrWhiteSpace(this.addRequestView.ItemIdTextBox.Text))
            {
                Console.WriteLine("item id is null");
                return false;
            }
            else
            {
                m.ItemId = this.addRequestView.ItemIdTextBox.Text;
            }

            if (string.IsNullOrWhiteSpace(this.addRequestView.ItemTypeTextBox.Text))
            {
                Console.WriteLine("item type is null");
                return false;
            }
            else
            {
                m.ItemType = this.addRequestView.ItemTypeTextBox.Text;
            }

            if (string.IsNullOrWhiteSpace(this.addRequestView.MaintenanceTypeTextBox.Text))
            {
                return false;
            }
            else
            {
                m.MaintenanceType = this.addRequestView.MaintenanceTypeTextBox.Text;
            }

            if (string.IsNullOrWhiteSpace(this.addRequestView.DescriptionText))
            {
                Console.WriteLine("description empty");
                return false;
            }
            else
            {
                m.Description = this.addRequestView.DescriptionText;
            }

            m.Status = this.addRequestView.StatusComboBox.SelectedItem.ToString();
            m.DateRequested = Convert.ToDateTime(DateTime.Now.ToShortDateString());

            if (this.addRequestView.DateRequiredDtp.Checked)
            {
                m.DateRequired = Convert.ToDateTime(this.addRequestView.DateRequiredDtp.Value.ToShortDateString());
            }
            else
            {
                m.DateRequired = null;
            }

            m.EnteredBy = Environment.UserName.ToString();
            m.LastModified = DateTime.Now;
            m.ModifiedBy = Environment.UserName.ToString();
            m.Comments = this.addRequestView.CommentsText;
            return true;

        }

        private bool Validate(MaintenanceRequest m)
        {
            // do some validation of fields
            return true;
        }

        /// <summary>
        /// 
        /// s valid <see cref="MaintenanceRequest"/> into MaintenanceRequest table
        /// </summary>
        /// <param name="m"><see cref="MaintenanceRequest"/> with valid values</param>
        private void InsertMaintenanceRequest(MaintenanceRequest m)
        {
            string commandText = "INSERT INTO MaintenanceRequest " +
                "(item_type, item_id, maintenance_type, status, description," +
                "date_requested, date_required, entered_by, last_modified, modified_by, comments)" +
                "VALUES (@item_type, @item_id, @maintenance_type, @status, @description," +
                "@date_requested, @date_required, @entered_by, @last_modified, @modified_by, @comments)";

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MaintenanceRequest"].ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(commandText, conn);
                    //command.Parameters.AddWithValue("@request_id", m.RequestId);
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
                    this.addRequestView.RequestForm.Close();
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
