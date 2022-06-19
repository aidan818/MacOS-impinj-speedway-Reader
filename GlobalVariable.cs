using System;
using AppKit;
using Impinj.OctaneSdk;

namespace impinjspeedwayreader
{
	public class GlobalVariable
	{
		public static string Host_IP;

		public static ImpinjReader reader = new ImpinjReader();
		//public var ReaderTableDataSource DataSource = new ReaderTableDataSource();
		public static ReaderData data = new ReaderData();
		public static NSTableView TableView = new NSTableView();
		//public static ViewController viewcontroller = new ViewController();
		public static string EPC = "Test";
		public static string Detected = "";
		public static string LastTimeSeen = "Test";
		public static bool Print = true;
	}
}

