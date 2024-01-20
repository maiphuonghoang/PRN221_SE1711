using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

[XmlRoot("Candidate")]
public class Person
{
    [XmlElement("FirstName")]
    public string Name { get; set; }
    [XmlElement("RoughAge")]
    public int Age { get; set; }
}//end class
class Program
{
    static void Main(string[] args)
    {
        //khởi dụng  1 đối tượng person để ghi vào file 
        Person p1 = new Person() { Name = "David", Age = 30 };
        var xs = new XmlSerializer(typeof(Person));
        //Serialize ghi đối tượng person ở trên vào file 
        using Stream s1 = File.Create("person.xml");//ghi theo stream 
        xs.Serialize(s1, p1);//hàm mã hóa theo định dạng xml của class person bên trên 
        s1.Close();

        //Deserialize: Giải tuần tự 
        using Stream s2 = File.OpenRead("person.xml");//đọc lại theo dạng stream 
        var p2 = (Person)xs.Deserialize(s2);//giải mã trở lại thành đối tượng 
        Console.WriteLine("****Person Info****");//hiện đối tượng 
        Console.WriteLine($"Name: {p2.Name}, Age: {p2.Age}");
        Console.WriteLine("****Person.xml****");
        string xmlData = File.ReadAllText("person.xml");//hiện all file xml 
        Console.WriteLine(xmlData);
        s2.Close();
        Console.ReadLine();
    }//end Main
}//end Program
//khởi tạo 1 file xml chứa sẵn 2 student, sau đó thêm vào database 2 student đó
//ghi toàn bộ dữ liệu vào file xml 
