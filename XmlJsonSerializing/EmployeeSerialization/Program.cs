using EmployeeSerialization;
using System.Text.Json;

class Program

{

    static void Main(string[] ares)
    {

        string jsonData3 = @"{
            ""FullName"" : ""Mark"",
            ""Email"" : ""Mark@gmail.com"",
            ""Salary"" : 1000,
        }";
        var option3 = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };
        var emp3 = JsonSerializer.Deserialize<Employee>(jsonData3, option3);
        Console.WriteLine($"Name: {emp3.Name}, Email: {emp3.Email}, Salary:{emp3.Salary}");
        Console.WriteLine("*********");

        var emp1 = new Employee(1000M);
        emp1.Name = "Jack";
        emp1.Email = "jack@gmail.com";
        var option = new JsonSerializerOptions { WriteIndented = true };
        Console.WriteLine("****Serialize*****");

        string jsonData = JsonSerializer.Serialize(emp1, option);
        Console.WriteLine(jsonData);
        Console.WriteLine("****Deserialize*****");

        var emp2 = JsonSerializer.Deserialize<Employee>(jsonData);
        Console.WriteLine($"Name:{emp2.Name}, Salary:{emp2.Salary}");
        Console.ReadLine();


    }
}



