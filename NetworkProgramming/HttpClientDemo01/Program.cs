using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    // HttpClient is intended to be instantiated once per application
    static readonly HttpClient client = new HttpClient();
    static async Task Main()
    {
        string uri = "https://cmshn.fpt.edu.vn/mod/folder/view.php?id=157360";
        // Call asynchronous network methods in a try/catch block to handle exceptions.
        try
        {
            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);

        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
    }
}

