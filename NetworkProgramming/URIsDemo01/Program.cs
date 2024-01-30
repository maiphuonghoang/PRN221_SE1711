using static System.Console;
class Program
{
    static void Main(string[] args)

    {

        Uri info = new Uri("http://www.domain.com:80/info?id=123#fragment");
        Uri page = new Uri("http://www.domain.com/info/page.html");
        //Uri info = new Uri("https://cmshn.fpt.edu.vn/mod/folder/view.php?id=157360");
        //Uri page = new Uri("https://cmshn.fpt.edu.vn/mod/folder/view.php");
        WriteLine($"Host: {info.Host}");

        WriteLine($"Port: {info.Port}");

        WriteLine($"PathAndQuery: {info.PathAndQuery}");
        WriteLine($"Query: {info.Query}");

        WriteLine($"Fragment: {info.Fragment}");
        WriteLine($"Default HTTP port: {page.Port}");
        WriteLine($"IsBaseOf: {info.IsBaseOf(page)}");

        Uri relative = info.MakeRelativeUri(page);
        WriteLine($"IsAbsoluteUri: {relative.IsAbsoluteUri}");
        WriteLine($"RelativeUri: {relative.ToString()}");
        ReadLine();

    }
}