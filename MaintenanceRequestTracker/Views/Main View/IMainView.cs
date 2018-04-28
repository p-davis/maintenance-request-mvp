using System;
using System.Windows.Forms;
using MaintenanceRequestTracker.MaintenanceDataSetTableAdapters;

namespace MaintenanceRequestTracker.Views
{
    /// <summary>
    /// Defines all event handlers, UI getters and setters and database getters of <see cref="MainView"/>.
    /// </summary>
    interface IMainView
    {
        // events
        event EventHandler MainViewLoad;

        event EventHandler ImportButtonClicked;

        event EventHandler UpdateButtonClicked;

        event EventHandler ClearButtonClicked;

        event EventHandler AddButtonClicked;

        event EventHandler EditButtonClicked;

        event EventHandler HelpButtonClicked;

        event EventHandler ChangeTabEnter;

        event EventHandler ChangeTabLeave;

        event EventHandler ClosedTabEnter;

        event EventHandler ClosedTabLeave;

        event EventHandler OpenTabEnter;

        event EventHandler OpenTabLeave;

        event EventHandler EditRequestContextMenuItemClicked;

        event DataGridViewCellMouseEventHandler SqlDgvMouseDown;

        event DataGridViewDataErrorEventHandler SqlDgvDataError;

        event DataGridViewCellValidatingEventHandler SqlDgvCellValidating;

        event TabControlEventHandler TabSelected;

        // field getter and setters
        Form MainForm { get; }

        DataGridView SqlDgv { get; }

        DataGridView ChangeDgv { get; }

        DataGridViewRow GetCurrentRow { get; }

        TabControl MainTabControl { get; }

        TabPage OpenTab { get; }

        TabPage ClosedTab { get; }

        TabPage ChangeTab { get; }

        Button AddButton { get; }

        Button UpdateButton { get; }

        Button ClearButton { get; }

        Button EditButton { get; }

        Label RequestCountLabel { get; }

        PictureBox GreenSquare { get; }

        Label ColorLabel { get; }

        // data set
        MaintenanceRequestTableAdapter MaintenanceRequestTableAdapter { get; }

        BindingSource MaintenanceRequestBindingSource { get; }

        MaintenanceDataSet MaintenanceDataSet { get; }
    }
}
