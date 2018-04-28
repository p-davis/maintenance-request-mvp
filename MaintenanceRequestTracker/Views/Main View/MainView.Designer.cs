namespace MaintenanceRequestTracker
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.importButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.sqlDgv = new System.Windows.Forms.DataGridView();
            this.sqlDgvContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editRequestDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceRequestBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.maintenanceDataSet = new MaintenanceRequestTracker.MaintenanceDataSet();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.openTab = new System.Windows.Forms.TabPage();
            this.closedTab = new System.Windows.Forms.TabPage();
            this.changeTab = new System.Windows.Forms.TabPage();
            this.changeDgv = new System.Windows.Forms.DataGridView();
            this.clearButton = new System.Windows.Forms.Button();
            this.requestCountLabel = new System.Windows.Forms.Label();
            this.addButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.greenPictureBox = new System.Windows.Forms.PictureBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.maintenanceRequestTableAdapter = new MaintenanceRequestTracker.MaintenanceDataSetTableAdapters.MaintenanceRequestTableAdapter();
            this.requestIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maintenanceTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateRequestedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateRequiredColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enteredByColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifiedByColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.sqlDgv)).BeginInit();
            this.sqlDgvContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maintenanceRequestBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maintenanceDataSet)).BeginInit();
            this.mainTabControl.SuspendLayout();
            this.openTab.SuspendLayout();
            this.changeTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changeDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // importButton
            // 
            this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.importButton.Location = new System.Drawing.Point(1289, 12);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(97, 27);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "Import Excel File";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updateButton.Location = new System.Drawing.Point(657, -2);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(97, 27);
            this.updateButton.TabIndex = 3;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Visible = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // sqlDgv
            // 
            this.sqlDgv.AllowUserToAddRows = false;
            this.sqlDgv.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.sqlDgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.sqlDgv.AutoGenerateColumns = false;
            this.sqlDgv.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sqlDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sqlDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sqlDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.requestIdColumn,
            this.itemTypeColumn,
            this.itemIdColumn,
            this.maintenanceTypeColumn,
            this.statusColumn,
            this.descriptionColumn,
            this.dateRequestedColumn,
            this.dateRequiredColumn,
            this.enteredByColumn,
            this.lastModifiedColumn,
            this.modifiedByColumn,
            this.commentsColumn});
            this.sqlDgv.ContextMenuStrip = this.sqlDgvContextMenu;
            this.sqlDgv.DataSource = this.maintenanceRequestBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sqlDgv.DefaultCellStyle = dataGridViewCellStyle3;
            this.sqlDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlDgv.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sqlDgv.Location = new System.Drawing.Point(3, 3);
            this.sqlDgv.MultiSelect = false;
            this.sqlDgv.Name = "sqlDgv";
            this.sqlDgv.ReadOnly = true;
            this.sqlDgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.sqlDgv.RowHeadersWidth = 20;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sqlDgv.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.sqlDgv.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sqlDgv.RowTemplate.Height = 60;
            this.sqlDgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sqlDgv.Size = new System.Drawing.Size(1469, 623);
            this.sqlDgv.TabIndex = 0;
            this.sqlDgv.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.sqlDgv_CellMouseDown);
            this.sqlDgv.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.sqlDgv_CellValidating);
            this.sqlDgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.sqlDgv_DataError);
            // 
            // sqlDgvContextMenu
            // 
            this.sqlDgvContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editRequestDetailsToolStripMenuItem});
            this.sqlDgvContextMenu.Name = "sqlDgvContextMenu";
            this.sqlDgvContextMenu.Size = new System.Drawing.Size(178, 26);
            // 
            // editRequestDetailsToolStripMenuItem
            // 
            this.editRequestDetailsToolStripMenuItem.Name = "editRequestDetailsToolStripMenuItem";
            this.editRequestDetailsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.editRequestDetailsToolStripMenuItem.Text = "Edit Request Details";
            this.editRequestDetailsToolStripMenuItem.Click += new System.EventHandler(this.editRequestDetailsToolStripMenuItem_Click);
            // 
            // maintenanceRequestBindingSource
            // 
            this.maintenanceRequestBindingSource.DataMember = "MaintenanceRequest";
            this.maintenanceRequestBindingSource.DataSource = this.maintenanceDataSet;
            // 
            // maintenanceDataSet
            // 
            this.maintenanceDataSet.DataSetName = "MaintenanceDataSet";
            this.maintenanceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mainTabControl
            // 
            this.mainTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainTabControl.Controls.Add(this.openTab);
            this.mainTabControl.Controls.Add(this.closedTab);
            this.mainTabControl.Controls.Add(this.changeTab);
            this.mainTabControl.Location = new System.Drawing.Point(13, 45);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1483, 655);
            this.mainTabControl.TabIndex = 5;
            this.mainTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.mainTabControl_Selected);
            // 
            // openTab
            // 
            this.openTab.Controls.Add(this.sqlDgv);
            this.openTab.Location = new System.Drawing.Point(4, 22);
            this.openTab.Name = "openTab";
            this.openTab.Padding = new System.Windows.Forms.Padding(3);
            this.openTab.Size = new System.Drawing.Size(1475, 629);
            this.openTab.TabIndex = 0;
            this.openTab.Text = "Open Requests";
            this.openTab.UseVisualStyleBackColor = true;
            this.openTab.Enter += new System.EventHandler(this.openTab_Enter);
            this.openTab.Leave += new System.EventHandler(this.openTab_Leave);
            // 
            // closedTab
            // 
            this.closedTab.Location = new System.Drawing.Point(4, 22);
            this.closedTab.Name = "closedTab";
            this.closedTab.Size = new System.Drawing.Size(1475, 629);
            this.closedTab.TabIndex = 3;
            this.closedTab.Text = "Closed Requests";
            this.closedTab.UseVisualStyleBackColor = true;
            this.closedTab.Enter += new System.EventHandler(this.closedTab_Enter);
            this.closedTab.Leave += new System.EventHandler(this.closedTab_Leave);
            // 
            // changeTab
            // 
            this.changeTab.Controls.Add(this.changeDgv);
            this.changeTab.Location = new System.Drawing.Point(4, 22);
            this.changeTab.Name = "changeTab";
            this.changeTab.Size = new System.Drawing.Size(1475, 629);
            this.changeTab.TabIndex = 2;
            this.changeTab.Text = "Changes";
            this.changeTab.UseVisualStyleBackColor = true;
            this.changeTab.Enter += new System.EventHandler(this.changeTab_Enter);
            this.changeTab.Leave += new System.EventHandler(this.changeTab_Leave);
            // 
            // changeDgv
            // 
            this.changeDgv.AllowUserToAddRows = false;
            this.changeDgv.AllowUserToDeleteRows = false;
            this.changeDgv.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.changeDgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.changeDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.changeDgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.changeDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changeDgv.Location = new System.Drawing.Point(0, 0);
            this.changeDgv.Name = "changeDgv";
            this.changeDgv.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.changeDgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.changeDgv.RowHeadersWidth = 20;
            this.changeDgv.RowTemplate.Height = 40;
            this.changeDgv.Size = new System.Drawing.Size(1475, 629);
            this.changeDgv.TabIndex = 0;
            // 
            // clearButton
            // 
            this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearButton.Location = new System.Drawing.Point(554, -2);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(97, 27);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear Changes";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Visible = false;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // requestCountLabel
            // 
            this.requestCountLabel.AutoSize = true;
            this.requestCountLabel.Location = new System.Drawing.Point(13, 12);
            this.requestCountLabel.Name = "requestCountLabel";
            this.requestCountLabel.Size = new System.Drawing.Size(96, 13);
            this.requestCountLabel.TabIndex = 7;
            this.requestCountLabel.Text = "requestCountLabel";
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(760, -2);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(97, 27);
            this.addButton.TabIndex = 8;
            this.addButton.Text = "New Request";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Visible = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.Location = new System.Drawing.Point(1392, 12);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(97, 27);
            this.editButton.TabIndex = 9;
            this.editButton.Text = "Edit Request";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // greenPictureBox
            // 
            this.greenPictureBox.Image = global::MaintenanceRequestTracker.Properties.Resources.green;
            this.greenPictureBox.Location = new System.Drawing.Point(12, 10);
            this.greenPictureBox.Name = "greenPictureBox";
            this.greenPictureBox.Size = new System.Drawing.Size(15, 15);
            this.greenPictureBox.TabIndex = 10;
            this.greenPictureBox.TabStop = false;
            this.greenPictureBox.Visible = false;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(33, 12);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(150, 13);
            this.colorLabel.TabIndex = 11;
            this.colorLabel.Text = "Changes to be made in ProCal";
            this.colorLabel.Visible = false;
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(863, -2);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(97, 27);
            this.helpButton.TabIndex = 13;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Visible = false;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // maintenanceRequestTableAdapter
            // 
            this.maintenanceRequestTableAdapter.ClearBeforeFill = true;
            // 
            // requestIdColumn
            // 
            this.requestIdColumn.DataPropertyName = "request_id";
            this.requestIdColumn.HeaderText = "request_id";
            this.requestIdColumn.Name = "requestIdColumn";
            this.requestIdColumn.ReadOnly = true;
            // 
            // itemTypeColumn
            // 
            this.itemTypeColumn.DataPropertyName = "item_type";
            this.itemTypeColumn.HeaderText = "item_type";
            this.itemTypeColumn.Name = "itemTypeColumn";
            this.itemTypeColumn.ReadOnly = true;
            // 
            // itemIdColumn
            // 
            this.itemIdColumn.DataPropertyName = "item_id";
            this.itemIdColumn.HeaderText = "item_id";
            this.itemIdColumn.Name = "itemIdColumn";
            this.itemIdColumn.ReadOnly = true;
            // 
            // maintenanceTypeColumn
            // 
            this.maintenanceTypeColumn.DataPropertyName = "maintenance_type";
            this.maintenanceTypeColumn.HeaderText = "maintenance_type";
            this.maintenanceTypeColumn.Name = "maintenanceTypeColumn";
            this.maintenanceTypeColumn.ReadOnly = true;
            // 
            // statusColumn
            // 
            this.statusColumn.DataPropertyName = "status";
            this.statusColumn.HeaderText = "status";
            this.statusColumn.Name = "statusColumn";
            this.statusColumn.ReadOnly = true;
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.DataPropertyName = "description";
            this.descriptionColumn.HeaderText = "description";
            this.descriptionColumn.Name = "descriptionColumn";
            this.descriptionColumn.ReadOnly = true;
            // 
            // dateRequestedColumn
            // 
            this.dateRequestedColumn.DataPropertyName = "date_requested";
            this.dateRequestedColumn.HeaderText = "date_requested";
            this.dateRequestedColumn.Name = "dateRequestedColumn";
            this.dateRequestedColumn.ReadOnly = true;
            // 
            // dateRequiredColumn
            // 
            this.dateRequiredColumn.DataPropertyName = "date_required";
            this.dateRequiredColumn.HeaderText = "date_required";
            this.dateRequiredColumn.Name = "dateRequiredColumn";
            this.dateRequiredColumn.ReadOnly = true;
            // 
            // enteredByColumn
            // 
            this.enteredByColumn.DataPropertyName = "entered_by";
            this.enteredByColumn.HeaderText = "entered_by";
            this.enteredByColumn.Name = "enteredByColumn";
            this.enteredByColumn.ReadOnly = true;
            // 
            // lastModifiedColumn
            // 
            this.lastModifiedColumn.DataPropertyName = "last_modified";
            this.lastModifiedColumn.HeaderText = "last_modified";
            this.lastModifiedColumn.Name = "lastModifiedColumn";
            this.lastModifiedColumn.ReadOnly = true;
            // 
            // modifiedByColumn
            // 
            this.modifiedByColumn.DataPropertyName = "modified_by";
            this.modifiedByColumn.HeaderText = "modified_by";
            this.modifiedByColumn.Name = "modifiedByColumn";
            this.modifiedByColumn.ReadOnly = true;
            // 
            // commentsColumn
            // 
            this.commentsColumn.DataPropertyName = "comments";
            this.commentsColumn.HeaderText = "comments";
            this.commentsColumn.Name = "commentsColumn";
            this.commentsColumn.ReadOnly = true;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 712);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.greenPictureBox);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.requestCountLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.importButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maintenance Request Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sqlDgv)).EndInit();
            this.sqlDgvContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.maintenanceRequestBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maintenanceDataSet)).EndInit();
            this.mainTabControl.ResumeLayout(false);
            this.openTab.ResumeLayout(false);
            this.changeTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.changeDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.DataGridView sqlDgv;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage openTab;
        private System.Windows.Forms.TabPage changeTab;
        private System.Windows.Forms.DataGridView changeDgv;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TabPage closedTab;
        private System.Windows.Forms.Label requestCountLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.PictureBox greenPictureBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.ContextMenuStrip sqlDgvContextMenu;
        private System.Windows.Forms.ToolStripMenuItem editRequestDetailsToolStripMenuItem;
        private System.Windows.Forms.Button helpButton;
        private MaintenanceDataSet maintenanceDataSet;
        private System.Windows.Forms.BindingSource maintenanceRequestBindingSource;
        private MaintenanceDataSetTableAdapters.MaintenanceRequestTableAdapter maintenanceRequestTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maintenanceTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateRequestedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateRequiredColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enteredByColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifiedByColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentsColumn;
    }
}

