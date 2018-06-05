/*
 * C# program to accept a book title from clients and sends back    
 * its price using XML
 */
 
//SERVER SIDE PROGRAM
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Configuration;

namespace ServerSocket
{
    class Program
    {
        static TcpListener listener;
        const int LIMIT = 2; 
        public static void Query(object cid)
        {
            while (true)
            {
                Socket soc = listener.AcceptSocket();
                Console.WriteLine("Connected: {0}", soc.RemoteEndPoint);
                try
                {	 
					Stream s = new NetworkStream(soc);
                    StreamReader sr = new StreamReader(s);
                    StreamWriter sw = new StreamWriter(s);
                    sw.AutoFlush = true; // enable automatic flushing
                    sw.WriteLine("{0} Students Available", ConfigurationManager.AppSettings.Count);
                    while (true)
                    {

				
						StuMaj sinfo = (StuMaj)cid;
						
							
                        string ide = sr.ReadLine();
                        if (ide == "" || ide == null) 
							break;
						
                        sinfo.iD = ConfigurationManager.AppSettings[ide];
						sinfo.mavg = ConfigurationManager.AppSettings[sinfo.iD];
						
						 
						sw.WriteLine(sinfo.iD);
						sw.Flush();
				
						sw.WriteLine(sinfo.mavg);
				
				
                    }
                    s.Close();
                }
                catch (Exception e)
                {
 
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Disconnected: {0}", soc.RemoteEndPoint);
                soc.Close();
            }
        }
       static void Main(string[] args)
        {
			int i = 0;
			IPAddress ipAd = IPAddress.Parse("127.0.0.1"); 
            listener = new TcpListener(ipAd, 2055);
            listener.Start();
 
            Console.WriteLine("Server started, listening to port 2055");
			
			while(++i != LIMIT){
				
				StuMaj studentInfo = new StuMaj();
                Thread t = new Thread(Query);
                t.Start(studentInfo);
				Console.WriteLine("Server thread {0} started....", i);
            }
        }
		
		class StuMaj{
			
			public string iD { get; set;}
			public string mavg{get; set;}
		
			
			public void Info(string studentID, string majoraverage){
				
				iD = studentID;
				mavg = majoraverage;
			
			}
		}
		
    }
	
}