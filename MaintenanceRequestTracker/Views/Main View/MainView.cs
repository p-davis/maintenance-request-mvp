using System;
using System.Windows.Forms;
using MaintenanceRequestTracker.MaintenanceDataSetTableAdapters;
using MaintenanceRequestTracker.Views;

namespace MaintenanceRequestTracker
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            this.InitializeComponent();
        }

        #region Event Declarations

        public event EventHandler ImportButtonClicked;

        public event EventHandler MainViewLoad;

        public event EventHandler StatusComboSelectedIndexChanged;

        public event EventHandler UpdateButtonClicked;

        public event EventHandler ClearButtonClicked;

        public event EventHandler AddButtonClicked;

        public event EventHandler EditButtonClicked;

        public event EventHandler HelpButtonClicked;

        public event EventHandler ChangeTabEnter;

        public event EventHandler ChangeTabLeave;

        public event EventHandler ClosedTabEnter;

        public event EventHandler ClosedTabLeave;

        public event EventHandler OpenTabEnter;

        public event EventHandler OpenTabLeave;

        public event EventHandler EditRequestContextMenuItemClicked;

        public event DataGridViewDataErrorEventHandler SqlDgvDataError;

        public event DataGridViewCellValidatingEventHandler SqlDgvCellValidating;

        public event TabControlEventHandler TabSelected;

        public event DataGridViewCellMouseEventHandler SqlDgvMouseDown;

        #endregion

        #region Properties
        public Form MainForm
        {
            get
            {
                return this;
            }
        }

        public DataGridView SqlDgv
        {
            get
            {
                return this.sqlDgv;
            }
        }

        public DataGridView ChangeDgv
        {
            get
            {
                return this.changeDgv;
            }
        }

        public TabControl MainTabControl
        {
            get
            {
                return this.mainTabControl;
            }
        }

        public TabPage OpenTab
        {
            get
            {
                return this.openTab;
            }
        }

        public TabPage ClosedTab
        {
            get
            {
                return this.closedTab;
            }
        }

        public TabPage ChangeTab
        {
            get
            {
                return this.changeTab;
            }
        }

        public Label RequestCountLabel
        {
            get
            {
                return this.requestCountLabel;
            }
        }

        public MaintenanceRequestTableAdapter MaintenanceRequestTableAdapter
        {
            get
            {
                return this.maintenanceRequestTableAdapter;
            }
        }

        public BindingSource MaintenanceRequestBindingSource
        {
            get
            {
                return this.maintenanceRequestBindingSource;
            }
        }

        public MaintenanceDataSet MaintenanceDataSet
        {
            get
            {
                return this.maintenanceDataSet;
            }
        }

        public Button AddButton
        {
            get
            {
                return this.addButton;
            }
        }

        public Button UpdateButton
        {
            get
            {
                return this.updateButton;
            }
        }

        public Button ClearButton
        {
            get
            {
                return this.clearButton;
            }
        }

        public Button EditButton
        {
            get
            {
                return this.editButton;
            }
        }

        public DataGridViewRow GetCurrentRow
        {
            get
            {
                int rowIndex = this.sqlDgv.CurrentCell.RowIndex;
                DataGridViewRow r = this.sqlDgv.Rows[rowIndex];
                return r;
            }
        }

        public PictureBox GreenSquare
        {
            get
            {
                return this.greenPictureBox;
            }
        }

        public Label ColorLabel
        {
            get
            {
                return this.colorLabel;
            }
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'maintenanceDataSet.MaintenanceRequest' table. You can move, or remove it, as needed.
            this.maintenanceRequestTableAdapter.Fill(this.maintenanceDataSet.MaintenanceRequest);
            this.MainViewLoad?.Invoke(sender, e);
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            this.ImportButtonClicked?.Invoke(sender, e);
        }

        private void statusCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.StatusComboSelectedIndexChanged?.Invoke(sender, e);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            this.UpdateButtonClicked?.Invoke(sender, e);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.ClearButtonClicked?.Invoke(sender, e);
        }

        private void sqlDgv_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            this.SqlDgvDataError?.Invoke(sender, e);
        }

        private void sqlDgv_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            this.SqlDgvCellValidating?.Invoke(sender, e);
        }

        private void changeTab_Enter(object sender, EventArgs e)
        {
            this.ChangeTabEnter?.Invoke(sender, e);
        }

        private void changeTab_Leave(object sender, EventArgs e)
        {
            this.ChangeTabLeave?.Invoke(sender, e);
        }

        private void closedTab_Enter(object sender, EventArgs e)
        {
            this.ClosedTabEnter?.Invoke(sender, e);
        }

        private void openTab_Enter(object sender, EventArgs e)
        {
            this.OpenTabEnter?.Invoke(sender, e);
        }

        private void openTab_Leave(object sender, EventArgs e)
        {
            this.OpenTabLeave?.Invoke(sender, e);
        }

        private void closedTab_Leave(object sender, EventArgs e)
        {
            this.ClosedTabLeave?.Invoke(sender, e);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            this.AddButtonClicked?.Invoke(sender, e);
        }

        private void mainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            this.TabSelected?.Invoke(sender, e);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            this.EditButtonClicked?.Invoke(sender, e);
        }

        private void sqlDgv_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.SqlDgvMouseDown?.Invoke(sender, e);
        }

        private void editRequestDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.EditRequestContextMenuItemClicked?.Invoke(sender, e);
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            this.HelpButtonClicked?.Invoke(sender, e);
        }
    }
}
