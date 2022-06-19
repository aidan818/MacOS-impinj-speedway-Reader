// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace impinjspeedwayreader
{
	[Register ("ViewController")]
	public partial class ViewController
	{
		[Outlet]
		AppKit.NSTableColumn DetectedColumn { get; set; }

		[Outlet]
		AppKit.NSTextField EnterIPOutlet { get; set; }

		[Outlet]
		AppKit.NSTextField EnterNameOutlet { get; set; }

		[Outlet]
		AppKit.NSTableColumn EPCColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn LastTimeSeenColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn MaxRSSIColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn MinRSSIColumn { get; set; }

		[Outlet]
		AppKit.NSTableView ReaderTable { get; set; }

		[Outlet]
		AppKit.NSTableColumn RSSIColumn { get; set; }

		[Action ("SettingsButtonAction:")]
		partial void SettingsButtonAction (AppKit.NSButton sender);

		[Action ("StartButtonAction:")]
		partial void StartButtonAction (AppKit.NSButton sender);

		[Action ("StopButtonAction:")]
		partial void StopButtonAction (AppKit.NSButton sender);

		[Action ("SubmitIPAction:")]
		partial void SubmitIPAction (AppKit.NSButton sender);

		//public void updateTables()
		//{
		//	GlobalVariable.DataSource.Readers.Add(new Reader(GlobalVariable.EPC, "", "", "", "", ""));
		//	ReaderTable.DataSource = GlobalVariable.DataSource;
		//	ReaderTable.Delegate = new ReaderTableDelegate(GlobalVariable.DataSource);

		//}

		void ReleaseDesignerOutlets ()
		{
			if (DetectedColumn != null) {
				DetectedColumn.Dispose ();
				DetectedColumn = null;
			}

			if (EnterIPOutlet != null) {
				EnterIPOutlet.Dispose ();
				EnterIPOutlet = null;
			}

			if (EnterNameOutlet != null) {
				EnterNameOutlet.Dispose ();
				EnterNameOutlet = null;
			}

			if (EPCColumn != null) {
				EPCColumn.Dispose ();
				EPCColumn = null;
			}

			if (LastTimeSeenColumn != null) {
				LastTimeSeenColumn.Dispose ();
				LastTimeSeenColumn = null;
			}

			if (MaxRSSIColumn != null) {
				MaxRSSIColumn.Dispose ();
				MaxRSSIColumn = null;
			}

			if (MinRSSIColumn != null) {
				MinRSSIColumn.Dispose ();
				MinRSSIColumn = null;
			}

			if (ReaderTable != null) {
				ReaderTable.Dispose ();
				ReaderTable = null;
			}

			if (RSSIColumn != null) {
				RSSIColumn.Dispose ();
				RSSIColumn = null;
			}
		}
	}
}
