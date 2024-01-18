using System;
using System.Collections.Generic;
using System.Xml.Serialization;


namespace GridFormDemo.Models
{
    [XmlRoot("Students")]
    public class Studentif
    {
        
        public string Rollnumber { get; set; } = null!;
        public string? StudentName { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public string? Address { get; set; }
    }
}
