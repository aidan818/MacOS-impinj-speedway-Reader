using System;
using Foundation;
using AppKit;

namespace impinjspeedwayreader
{
	[Register("ReaderData")]
	public class ReaderData : NSObject
	{
		private string _EPC = "";
		private string _lastTimeSeen = "";
		private NSMutableArray _data = new NSMutableArray();

		[Export("EPC")]
		public string EPC
        {
			get { return _EPC; }
			set {
				WillChangeValue("EPC");
				_EPC = value;
				DidChangeValue("EPC");
            }
        }

		[Export("LastTimeSeen")]
		public string LastTimeSeen
        {
            get { return _lastTimeSeen; }
			set
            {
				WillChangeValue("LastTimeSeen");
				_lastTimeSeen = value;
				DidChangeValue("LastTimeSeen");
            }
        }

		[Export("ReaderDataArray")]
		public NSArray Data
        {
			get { return _data; }
        }

		public ReaderData()
        {

        }

		public ReaderData(string EPC, string lastTimeSeen)
        {
			this.EPC = EPC;
			this.LastTimeSeen = lastTimeSeen;
        }

		[Export("addObject:")]
		public void AddData(ReaderData newData)
        {
			WillChangeValue("ReaderDataArray");
			_data.Add(newData);
			Console.WriteLine(_data);
			DidChangeValue("ReaderDataArray");
        }

		
	}
}

