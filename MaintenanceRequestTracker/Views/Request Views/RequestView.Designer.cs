namespace MaintenanceRequestTracker.Views
{
    partial class RequestView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestView));
            this.itemIdTextBox = new System.Windows.Forms.TextBox();
            this.itemIdLabel = new System.Windows.Forms.Label();
            this.itemTypeLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.statusComboBox = new System.Windows.Forms.ComboBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.dateRequiredDtp = new System.Windows.Forms.DateTimePicker();
            this.dateRequiredLabel = new System.Windows.Forms.Label();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.commentsTextBox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.maintenanceTypeLabel = new System.Windows.Forms.Label();
            this.requestIdLabel = new System.Windows.Forms.Label();
            this.dateRequestedDtp = new System.Windows.Forms.DateTimePicker();
            this.dateRequestedLabel = new System.Windows.Forms.Label();
            this.requestIdText = new System.Windows.Forms.Label();
            this.enteredByText = new System.Windows.Forms.Label();
            this.enteredByLabel = new System.Windows.Forms.Label();
            this.lastModifiedText = new System.Windows.Forms.Label();
            this.lastModifiedLabel = new System.Windows.Forms.Label();
            this.modifiedByText = new System.Windows.Forms.Label();
            this.modifiedByLabel = new System.Windows.Forms.Label();
            this.maintenanceTypeTextBox = new System.Windows.Forms.TextBox();
            this.itemTypeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // itemIdTextBox
            // 
            this.itemIdTextBox.Location = new System.Drawing.Point(244, 32);
            this.itemIdTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.itemIdTextBox.MaxLength = 49;
            this.itemIdTextBox.Name = "itemIdTextBox";
            this.itemIdTextBox.ReadOnly = true;
            this.itemIdTextBox.Size = new System.Drawing.Size(200, 20);
            this.itemIdTextBox.TabIndex = 2;
            // 
            // itemIdLabel
            // 
            this.itemIdLabel.AutoSize = true;
            this.itemIdLabel.Location = new System.Drawing.Point(240, 15);
            this.itemIdLabel.Name = "itemIdLabel";
            this.itemIdLabel.Size = new System.Drawing.Size(41, 13);
            this.itemIdLabel.TabIndex = 4;
            this.itemIdLabel.Text = "Item ID";
            // 
            // itemTypeLabel
            // 
            this.itemTypeLabel.AutoSize = true;
            this.itemTypeLabel.Location = new System.Drawing.Point(63, 15);
            this.itemTypeLabel.Name = "itemTypeLabel";
            this.itemTypeLabel.Size = new System.Drawing.Size(54, 13);
            this.itemTypeLabel.TabIndex = 5;
            this.itemTypeLabel.Text = "Item Type";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.AutoSize = true;
            this.descriptionLabel.Location = new System.Drawing.Point(17, 228);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.descriptionLabel.TabIndex = 6;
            this.descriptionLabel.Text = "Description";
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(19, 244);
            this.descriptionTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.descriptionTextBox.MaxLength = 299;
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.ReadOnly = true;
            this.descriptionTextBox.Size = new System.Drawing.Size(200, 80);
            this.descriptionTextBox.TabIndex = 7;
            // 
            // statusComboBox
            // 
            this.statusComboBox.FormattingEnabled = true;
            this.statusComboBox.Items.AddRange(new object[] {
            "Assigned",
            "Cancelled",
            "Closed",
            "Not Assigned",
            "Ongoing",
            "Out of Service"});
            this.statusComboBox.Location = new System.Drawing.Point(243, 88);
            this.statusComboBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.statusComboBox.Name = "statusComboBox";
            this.statusComboBox.Size = new System.Drawing.Size(200, 21);
            this.statusComboBox.TabIndex = 4;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(240, 72);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(40, 13);
            this.statusLabel.TabIndex = 9;
            this.statusLabel.Text = "Status:";
            // 
            // dateRequiredDtp
            // 
            this.dateRequiredDtp.Location = new System.Drawing.Point(244, 139);
            this.dateRequiredDtp.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.dateRequiredDtp.Name = "dateRequiredDtp";
            this.dateRequiredDtp.Size = new System.Drawing.Size(200, 20);
            this.dateRequiredDtp.TabIndex = 6;
            // 
            // dateRequiredLabel
            // 
            this.dateRequiredLabel.AutoSize = true;
            this.dateRequiredLabel.Location = new System.Drawing.Point(243, 123);
            this.dateRequiredLabel.Name = "dateRequiredLabel";
            this.dateRequiredLabel.Size = new System.Drawing.Size(76, 13);
            this.dateRequiredLabel.TabIndex = 13;
            this.dateRequiredLabel.Text = "Date Required";
            // 
            // commentsLabel
            // 
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(241, 228);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(56, 13);
            this.commentsLabel.TabIndex = 14;
            this.commentsLabel.Text = "Comments";
            // 
            // commentsTextBox
            // 
            this.commentsTextBox.Location = new System.Drawing.Point(244, 244);
            this.commentsTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.commentsTextBox.MaxLength = 299;
            this.commentsTextBox.Multiline = true;
            this.commentsTextBox.Name = "commentsTextBox";
            this.commentsTextBox.Size = new System.Drawing.Size(200, 80);
            this.commentsTextBox.TabIndex = 8;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(244, 347);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 41;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(145, 347);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 40;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // maintenanceTypeLabel
            // 
            this.maintenanceTypeLabel.AutoSize = true;
            this.maintenanceTypeLabel.Location = new System.Drawing.Point(16, 72);
            this.maintenanceTypeLabel.Name = "maintenanceTypeLabel";
            this.maintenanceTypeLabel.Size = new System.Drawing.Size(96, 13);
            this.maintenanceTypeLabel.TabIndex = 19;
            this.maintenanceTypeLabel.Text = "Maintenance Type";
            // 
            // requestIdLabel
            // 
            this.requestIdLabel.AutoSize = true;
            this.requestIdLabel.Location = new System.Drawing.Point(17, 15);
            this.requestIdLabel.Name = "requestIdLabel";
            this.requestIdLabel.Size = new System.Drawing.Size(38, 13);
            this.requestIdLabel.TabIndex = 22;
            this.requestIdLabel.Text = "MR ID";
            // 
            // dateRequestedDtp
            // 
            this.dateRequestedDtp.Location = new System.Drawing.Point(20, 139);
            this.dateRequestedDtp.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.dateRequestedDtp.Name = "dateRequestedDtp";
            this.dateRequestedDtp.Size = new System.Drawing.Size(200, 20);
            this.dateRequestedDtp.TabIndex = 5;
            // 
            // dateRequestedLabel
            // 
            this.dateRequestedLabel.AutoSize = true;
            this.dateRequestedLabel.Location = new System.Drawing.Point(17, 123);
            this.dateRequestedLabel.Name = "dateRequestedLabel";
            this.dateRequestedLabel.Size = new System.Drawing.Size(85, 13);
            this.dateRequestedLabel.TabIndex = 25;
            this.dateRequestedLabel.Text = "Date Requested";
            // 
            // requestIdText
            // 
            this.requestIdText.AutoSize = true;
            this.requestIdText.Location = new System.Drawing.Point(17, 33);
            this.requestIdText.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.requestIdText.Name = "requestIdText";
            this.requestIdText.Size = new System.Drawing.Size(15, 13);
            this.requestIdText.TabIndex = 26;
            this.requestIdText.Text = "id";
            // 
            // enteredByText
            // 
            this.enteredByText.AutoSize = true;
            this.enteredByText.Location = new System.Drawing.Point(17, 195);
            this.enteredByText.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.enteredByText.Name = "enteredByText";
            this.enteredByText.Size = new System.Drawing.Size(34, 13);
            this.enteredByText.TabIndex = 28;
            this.enteredByText.Text = "entBy";
            // 
            // enteredByLabel
            // 
            this.enteredByLabel.AutoSize = true;
            this.enteredByLabel.Location = new System.Drawing.Point(17, 179);
            this.enteredByLabel.Name = "enteredByLabel";
            this.enteredByLabel.Size = new System.Drawing.Size(59, 13);
            this.enteredByLabel.TabIndex = 27;
            this.enteredByLabel.Text = "Entered By";
            // 
            // lastModifiedText
            // 
            this.lastModifiedText.AutoSize = true;
            this.lastModifiedText.Location = new System.Drawing.Point(243, 195);
            this.lastModifiedText.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.lastModifiedText.Name = "lastModifiedText";
            this.lastModifiedText.Size = new System.Drawing.Size(44, 13);
            this.lastModifiedText.TabIndex = 30;
            this.lastModifiedText.Text = "lastMod";
            // 
            // lastModifiedLabel
            // 
            this.lastModifiedLabel.AutoSize = true;
            this.lastModifiedLabel.Location = new System.Drawing.Point(241, 179);
            this.lastModifiedLabel.Name = "lastModifiedLabel";
            this.lastModifiedLabel.Size = new System.Drawing.Size(70, 13);
            this.lastModifiedLabel.TabIndex = 29;
            this.lastModifiedLabel.Text = "Last Modified";
            // 
            // modifiedByText
            // 
            this.modifiedByText.AutoSize = true;
            this.modifiedByText.Location = new System.Drawing.Point(365, 195);
            this.modifiedByText.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.modifiedByText.Name = "modifiedByText";
            this.modifiedByText.Size = new System.Drawing.Size(39, 13);
            this.modifiedByText.TabIndex = 32;
            this.modifiedByText.Text = "modBy";
            // 
            // modifiedByLabel
            // 
            this.modifiedByLabel.AutoSize = true;
            this.modifiedByLabel.Location = new System.Drawing.Point(365, 179);
            this.modifiedByLabel.Name = "modifiedByLabel";
            this.modifiedByLabel.Size = new System.Drawing.Size(62, 13);
            this.modifiedByLabel.TabIndex = 31;
            this.modifiedByLabel.Text = "Modified By";
            // 
            // maintenanceTypeTextBox
            // 
            this.maintenanceTypeTextBox.Location = new System.Drawing.Point(20, 88);
            this.maintenanceTypeTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.maintenanceTypeTextBox.MaxLength = 49;
            this.maintenanceTypeTextBox.Name = "maintenanceTypeTextBox";
            this.maintenanceTypeTextBox.ReadOnly = true;
            this.maintenanceTypeTextBox.Size = new System.Drawing.Size(200, 20);
            this.maintenanceTypeTextBox.TabIndex = 3;
            // 
            // itemTypeTextBox
            // 
            this.itemTypeTextBox.Location = new System.Drawing.Point(66, 32);
            this.itemTypeTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.itemTypeTextBox.MaxLength = 49;
            this.itemTypeTextBox.Name = "itemTypeTextBox";
            this.itemTypeTextBox.ReadOnly = true;
            this.itemTypeTextBox.Size = new System.Drawing.Size(150, 20);
            this.itemTypeTextBox.TabIndex = 1;
            // 
            // RequestView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 388);
            this.ControlBox = false;
            this.Controls.Add(this.itemTypeTextBox);
            this.Controls.Add(this.maintenanceTypeTextBox);
            this.Controls.Add(this.modifiedByText);
            this.Controls.Add(this.modifiedByLabel);
            this.Controls.Add(this.lastModifiedText);
            this.Controls.Add(this.lastModifiedLabel);
            this.Controls.Add(this.enteredByText);
            this.Controls.Add(this.enteredByLabel);
            this.Controls.Add(this.requestIdText);
            this.Controls.Add(this.dateRequestedLabel);
            this.Controls.Add(this.dateRequestedDtp);
            this.Controls.Add(this.requestIdLabel);
            this.Controls.Add(this.maintenanceTypeLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.itemIdTextBox);
            this.Controls.Add(this.commentsTextBox);
            this.Controls.Add(this.itemIdLabel);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.itemTypeLabel);
            this.Controls.Add(this.dateRequiredLabel);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.statusComboBox);
            this.Controls.Add(this.dateRequiredDtp);
            this.Controls.Add(this.statusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RequestView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Request";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddRequestView_FormClosing);
            this.Shown += new System.EventHandler(this.AddRequestView_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox itemIdTextBox;
        private System.Windows.Forms.Label itemIdLabel;
        private System.Windows.Forms.Label itemTypeLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.ComboBox statusComboBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.DateTimePicker dateRequiredDtp;
        private System.Windows.Forms.Label dateRequiredLabel;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.TextBox commentsTextBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Label maintenanceTypeLabel;
        private System.Windows.Forms.Label requestIdLabel;
        private System.Windows.Forms.DateTimePicker dateRequestedDtp;
        private System.Windows.Forms.Label dateRequestedLabel;
        private System.Windows.Forms.Label requestIdText;
        private System.Windows.Forms.Label enteredByText;
        private System.Windows.Forms.Label enteredByLabel;
        private System.Windows.Forms.Label lastModifiedText;
        private System.Windows.Forms.Label lastModifiedLabel;
        private System.Windows.Forms.Label modifiedByText;
        private System.Windows.Forms.Label modifiedByLabel;
        private System.Windows.Forms.TextBox maintenanceTypeTextBox;
        private System.Windows.Forms.TextBox itemTypeTextBox;
    }
}