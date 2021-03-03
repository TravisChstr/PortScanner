using System;
using System.Net.Sockets;
using System.Linq;

namespace PortScanner
{
    class Program
    {
        // Enter an IP address and a port range where the program will then attempt to find open ports on the given computer by connecting to each of them.
        //On any successful connections mark the port as open.
        static void Main(string[] args)
        {
            Console.Write("Enter IP Address: ");
            string ipAddress = Console.ReadLine();
            Console.WriteLine("Enter a range of ports.");
            Console.Write("Begin: ");
            string pStart = Console.ReadLine();
            Console.Write("End: ");
            string pEnd = Console.ReadLine();
            var range = Enumerable.Range(Int32.Parse(pStart), Int32.Parse(pEnd)).ToArray();
            Console.WriteLine("Scanning ports....");
            ScanPorts(ipAddress,range);

        }

        static void ScanPorts(string ipAddress, int[] range)
        {
            foreach(int port in range)
            {
                using (TcpClient client = new TcpClient())
                {
                    try
                    {
                        client.Connect(ipAddress, port);
                        Console.WriteLine("Port {0} is OPEN.", port);
                    }
                    catch
                    {
                        Console.WriteLine("Port {0} is CLOSED.", port);
                    }
                    
                }
            }
            
        }
    }
}
