using System;
using System.Threading;

using AppKit;
using Foundation;

using Impinj.OctaneSdk;


namespace impinjspeedwayreader
{
	public partial class ViewController : NSViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

        //public ViewController()
        //{
        //}

        public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			UpdateData(GlobalVariable.EPC, GlobalVariable.LastTimeSeen, ViewController);
		}


		//Function to transfer data onto the table
		//Made it public to try to call it in my main for loop in connections.cs
		// I cannot make this to a static or I will get an CS0120 Error
		// to fix that I must add the ViewController View but this creates an ERROR when the function is called
		// as I do not know what to put for the data for viewcontroller spot
		public static void UpdateData(string EPC, string LastTimeSeen, ViewController view)
        {
			view.AddData(new ReaderData(EPC, LastTimeSeen));
			view.ReaderTable.ReloadData();
		}
		

		public override NSObject RepresentedObject {
			get {
				return base.RepresentedObject;
			}
			set {
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}


		partial void StartButtonAction(NSButton sender)
        {
			NewSettings.CustomSettings();
			
			//Console.WriteLine("EPC: {0}. Timestamp: {1}", GlobalVariable.EPC, GlobalVariable.LastTimeSeen);
			//Call a method/function that will start taking the data and providing it to the table
		}
		partial void StopButtonAction(NSButton sender)
        {
			GlobalVariable.reader.Stop();
			Console.WriteLine("Reader Stop");
        }

        partial void SubmitIPAction(NSButton sender)
        {
			GlobalVariable.Host_IP = EnterIPOutlet.StringValue;
			GlobalVariable.reader.Name = EnterNameOutlet.StringValue;
			Console.WriteLine("The reader is now named: " + GlobalVariable.reader.Name);
			Console.WriteLine("Now attempting to connect to: " + GlobalVariable.Host_IP);
			Connection.ConnectToReader();
			//Call function to predetermine the settings if reader was connected successfully
        }

		
		private NSMutableArray _data = new NSMutableArray();

		[Export("ReaderDataArray")]
		public NSArray Data
		{
			get { return _data; }
		}

		[Export("addObject:")]
		public void AddData(ReaderData newData)
		{
			WillChangeValue("ReaderDataArray");
			_data.Add(newData);
			DidChangeValue("ReaderDataArray");
		}

	}
}
