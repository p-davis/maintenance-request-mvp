using System;
using System.Windows.Forms;

namespace MaintenanceRequestTracker.Views
{
    public partial class RequestView : Form, IRequestView
    {
        public RequestView()
        {
            InitializeComponent();
        }

        public Form RequestForm
        {
            get
            {
                return this;
            }
        }

        public Button CancelRequestButton
        {
            get
            {
                return this.cancelButton;
            }
        }

        public Button AddRequestButton
        {
            get
            {
                return this.acceptButton;
            }
        }

        public TextBox ItemIdTextBox
        {
            get
            {
                return this.itemIdTextBox;
            }

        }

        public string DescriptionText
        {
            get
            {
                return this.descriptionTextBox.Text;
            }

            set
            {
                this.descriptionTextBox.Text = value;
            }
        }

        public string CommentsText
        {
            get
            {
                return this.commentsTextBox.Text;
            }

            set
            {
                this.commentsTextBox.Text = value;
            }
        }

        public ComboBox StatusComboBox
        {
            get
            {
                return this.statusComboBox;
            }
        }

        public DateTimePicker DateRequiredDtp
        {
            get
            {
                return this.dateRequiredDtp;
            }

            set
            {
                this.dateRequiredDtp = value;
            }
        }

        public TextBox ItemTypeTextBox
        {
            get
            {
                return this.itemTypeTextBox;
            }
        }

        public TextBox MaintenanceTypeTextBox
        {
            get
            {
                return this.maintenanceTypeTextBox;
            }
        }

        public DateTimePicker DateRequestDtp
        {
            get
            {
                return this.dateRequestedDtp;
            }
        }

        public Label MaintenanceRequestIdTextLabel
        {
            get
            {
                return this.requestIdText;
            }
        }

        public Label EnteredByTextLabel
        {
            get
            {
                return this.enteredByText;
            }
        }

        public Label LastModifiedTextLabel
        {
            get
            {
                return this.lastModifiedText;
            }
        }

        public Label ModifiedByTextLabel
        {
            get
            {
                return this.modifiedByText;
            }
        }

        public Label MaintenanceRequestIdLabel
        {
            get
            {
                return this.requestIdLabel;
            }
        }

        public Label EnteredByLabel
        {
            get
            {
                return this.enteredByLabel;
            }
        }

        public Label LastModifiedLabel
        {
            get
            {
                return this.lastModifiedLabel;
            }
        }

        public Label ModifiedByLabel
        {
            get
            {
                return this.modifiedByLabel;
            }
        }

        public event EventHandler AcceptButtonClicked;

        public event EventHandler CancelButtonClicked;

        public event EventHandler RequestFormShown;

        public event FormClosingEventHandler RequestFormClosing;

        private void AddRequestView_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.RequestFormClosing?.Invoke(sender, e);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.CancelButtonClicked?.Invoke(sender, e);
        }

        private void AddRequestView_Shown(object sender, EventArgs e)
        {
            this.RequestFormShown?.Invoke(sender, e);
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.AcceptButtonClicked?.Invoke(sender, e);
        }
    }
}
