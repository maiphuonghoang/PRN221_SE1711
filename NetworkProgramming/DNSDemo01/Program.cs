using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(new string('*', 30));
        var domainEntry = Dns.GetHostEntry("www.contoso.com");
        Console.WriteLine(domainEntry.HostName);
        foreach (var ip in domainEntry.AddressList)
        {
            Console.WriteLine(ip);
        }
        Console.WriteLine(new string('*', 30));
        var domainEntryByAddress = Dns.GetHostEntry("127.0.0.1");
        Console.WriteLine(domainEntryByAddress.HostName);
        foreach (var ip in domainEntryByAddress.AddressList)
        {
            Console.WriteLine(ip);
        }
        //my test 
        Console.WriteLine(new string('*', 30));
        var domainEntry2 = Dns.GetHostEntry("cmshn.fpt.edu.vn");
        Console.WriteLine(domainEntry2.HostName);
        foreach (var ip in domainEntry2.AddressList)
        {
            Console.WriteLine(ip);
        }
        Console.WriteLine(new string('*', 30));
        var domainEntry3 = Dns.GetHostEntry("www.google.com");
        Console.WriteLine(domainEntry3.HostName);
        foreach (var ip in domainEntry3.AddressList)
        {
            Console.WriteLine(ip);
        }
    }
}