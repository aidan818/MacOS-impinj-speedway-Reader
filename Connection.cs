using System;
using System.Threading;
//using AppKit.NSViewController;
using Impinj.OctaneSdk;
using Foundation;
using AppKit;

namespace impinjspeedwayreader
{
	public class Connection
	{
        public Connection()
        { }
            public static void ConnectToReader()
            {
                try
                {
                    Console.WriteLine("Attempting to connect to {0} ({1}).",
                        GlobalVariable.reader.Name, GlobalVariable.Host_IP);

                    // Number of milliseconds before a 
                    // connection attempt times out.
                    GlobalVariable.reader.ConnectTimeout = 6000;
                // Connect to the reader.
                // Change the ReaderHostname constant in SolutionConstants.cs 
                // to the IP address or hostname of your reader.
                    //const string testIP = "169.254.81.242";
                    GlobalVariable.reader.Connect(GlobalVariable.Host_IP);
                    Console.WriteLine("Successfully connected.");

                    // Tell the reader to send us any tag reports and 
                    // events we missed while we were disconnected.
                    GlobalVariable.reader.ResumeEventsAndReports();
                }
                catch (OctaneSdkException e)
                {
                    Console.WriteLine("Failed to connect. Please try again");
                    throw e;
                }
            }

            public static void OnConnectionLost(ImpinjReader reader)
            {
                // This event handler is called if the reader  
                // stops sending keepalive messages (connection lost).
                Console.WriteLine("Connection lost : {0} ({1})", reader.Name, reader.Address);

                // Cleanup
                reader.Disconnect();

                // Try reconnecting to the reader
                ConnectToReader();
            }

            public static void OnKeepaliveReceived(ImpinjReader reader)
            {
                // This event handler is called when a keepalive 
                // message is received from the reader.
                Console.WriteLine("Keepalive received from {0} ({1})", reader.Name, reader.Address);
            }

        public static void OnTagsReported(ImpinjReader reader, TagReport report)
            {
            // This event handler is called asynchronously 
            // when tag reports are available.
            // Loop through each tag in the report 
            // and print the data.
                foreach (Tag tag in report)
                {

                Console.WriteLine("EPC : {0} Timestamp : {1}", tag.Epc, tag.LastSeenTime);
                
                GlobalVariable.EPC = tag.Epc.ToHexWordString();
                GlobalVariable.LastTimeSeen = tag.LastSeenTime.ToString();
               
                Console.WriteLine("EPC: {0}. Timestamp: {1}", GlobalVariable.EPC, GlobalVariable.LastTimeSeen);
                UpdateData(GlobalVariable.EPC, GlobalVariable.LastTimeSeen);
                
                }
            }

        
        
        public static void UpdateData(string EPC, string LastTimeSeen)
        {
            
            //SAME ERRORS as the view controller file
            ViewController.UpdateData(EPC, LastTimeSeen);
            Console.WriteLine("UPDATED DATA");
           
        }

     }
}

