/*
 * This is a C# Program which displays the IP address of an input URL.
 */

using System;
using System.Net;

namespace CNT4704L
{
    class MySocketLab
    {
        static void Main()
        {
            String strIpAddr; 
			Console.Write("Enter an IP address (e.g., 131.247.2.211): ");
			strIpAddr = Console.ReadLine();
			IPHostEntry HostName = Dns.GetHostEntry(strIpAddr);
			
			
			//didnt have enought time to figure out how to turn hostname to string and print
			
            Console.Write("\nHost name of {0} is: {1}", strIpAddr, HostName);
            
    }
}
