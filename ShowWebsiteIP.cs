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
            String strSiteName, ipv4_or_ipv6; 
			Console.Write("Enter a site name (e.g., www.usf.edu):  ");
			strSiteName = Console.ReadLine();
			IPAddress addr = Dns.GetHostAddresses(strSiteName)[0];
			
            Console.Write("\nIP address of {0} is:  ", strSiteName);
            ipv4_or_ipv6 = addr.GetAddressBytes().Length == 4 ? "IPv4" : "IPv6";		//IPv4 is 4 bytes, IPv6 is 16 bytes
            Console.WriteLine("({0}) {1}", ipv4_or_ipv6, addr);
        }
    }
}
