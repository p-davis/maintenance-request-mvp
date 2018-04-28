using System;
using System.Windows.Forms;

namespace MaintenanceRequestTracker.Views
{
    interface IRequestView
    {
        //events
        event EventHandler AcceptButtonClicked;
        event EventHandler CancelButtonClicked;
        event EventHandler RequestFormShown;
        event FormClosingEventHandler RequestFormClosing;

        //ui getter and setters
        Form RequestForm { get; }
        Button AddRequestButton { get; }
        Button CancelRequestButton { get; }
        TextBox ItemIdTextBox { get; }
        string DescriptionText { get; set; }
        string CommentsText { get; set; }  
        TextBox ItemTypeTextBox { get; }
        TextBox MaintenanceTypeTextBox { get; }      
        ComboBox StatusComboBox { get; }
        DateTimePicker DateRequiredDtp { get; set; }
        DateTimePicker DateRequestDtp { get; }
        Label MaintenanceRequestIdLabel { get; }
        Label MaintenanceRequestIdTextLabel { get; }
        Label EnteredByLabel { get; }
        Label EnteredByTextLabel { get; }
        Label LastModifiedLabel { get; }
        Label LastModifiedTextLabel { get; }
        Label ModifiedByLabel { get; }
        Label ModifiedByTextLabel { get; }
    }
}
