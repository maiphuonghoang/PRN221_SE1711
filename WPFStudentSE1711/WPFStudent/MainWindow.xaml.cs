using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using WPFStudent.Models;
namespace WPFStudent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PRN221_SE1711_StudentContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new PRN221_SE1711_StudentContext();
            Load_Data();
        }
        public void Load_Data()
        {
            List<StudentDTO> students = new List<StudentDTO>();
            var p = _context.Students.ToList();
            foreach (var item in p)
            {
                var mn = _context.Majors.Where(x => x.Id == item.Major).FirstOrDefault();
                StudentDTO tmp = new StudentDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    Dob = item.Dob,
                    Gender = item.Gender,
                    GenderString = (bool)item.Gender ? "Male" : "Female",
                    Male = (bool)item.Gender ? true : false,
                    Female = (bool)item.Gender ? false : true,
                    Major = item.Major,
                    MajorName = mn !=null? mn.Name : null,
                };
                students.Add(tmp);
            }
            lvStudent.ItemsSource = students;
            cboNganh.ItemsSource = _context.Majors.ToList();
        }

        public Student GetStudentObject()
        {
            try
            {
                int selectedMajorId = -1;
                if (cboNganh.SelectedItem != null)
                {
                    Major selectedMajor = (Major)cboNganh.SelectedItem;
                    selectedMajorId = selectedMajor.Id;
                }

                return new Student
                {
                    Id = string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text),
                    Name = txtName.Text,
                    Gender = rdoMale.IsChecked == true ? true : false,
                    Dob = txtDateofBirth.SelectedDate,
                    Major = selectedMajorId != -1 ? selectedMajorId : null,
                };  
                return null;
            }
            catch
            {
                MessageBox.Show("Cannot get student", "Get student");
            }
            return null;
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    var student = GetStudentObject();
            //    if(student != null)
            //    {
            //        student.Id = 0;
            //        _context.Students.Add(student);
            //        _context.SaveChanges();
            //        Load_Data();
            //        MessageBox.Show("Insert student success " + student.Id +" "+ student.Name, "Add Employee");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Insert student failed", "Add Student");
            //}
            btnAddClickV2();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = GetStudentObject();
                if (student != null)
                {
                    var oldStudent = _context.Students.FirstOrDefault(x => x.Id == student.Id);
                    if (oldStudent != null)
                    {
                        oldStudent.Dob = student.Dob;
                        oldStudent.Name = student.Name;
                        oldStudent.Gender = student.Gender;
                        oldStudent.Major = student.Major;
                        _context.Students.Update(oldStudent);
                        _context.SaveChanges();
                        Load_Data();
                        MessageBox.Show("Update student success " + student.Id + " " + student.Name, "Update Student");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update student failed", "Update Student");
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = GetStudentObject();
                if (student != null)
                {
                    
                    var oldStudent = _context.Students.FirstOrDefault(x => x.Id == student.Id);
                    if (oldStudent != null)
                    {
                        var result = MessageBox.Show("Are you sure to delete " + oldStudent.Name, "Question", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                        if(result == MessageBoxResult.Yes)
                        {
                            _context.Students.Remove(oldStudent);
                            _context.SaveChanges();
                            Load_Data();
                            MessageBox.Show("Delete student success " + student.Id + " " + student.Name, "Delete Student");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete student failed", "Delete Student");
            }

        }


        private void lvStudent_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        //----------------------------------------
        public Student GetStudentV2()
        {

            Student tmp = new Student()
            {
                Id = string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text),
                Name = txtName.Text,
                Dob = txtDateofBirth.SelectedDate,
                Gender = rdoMale.IsChecked == true ? true : false,
                Major = Int32.Parse(cboNganh.SelectedValue.ToString())
            };
            return tmp;
        }
        public void btnAddClickV2()
        {
            try
            {
                Student tmp = GetStudentV2();
                if (tmp != null)
                {
                    var p = _context.Students.FirstOrDefault(x => x.Id == tmp.Id);
                    if (p == null)
                    {
                        _context.Students.Add(tmp);
                        _context.SaveChanges();
                        Load_Data();
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnXML_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(XMLStudent));
            string x = File.ReadAllText("XMLStudent.xml");
            using Stream s2 = File.OpenRead("XMLStudent.xml");//đọc lại theo dạng stream 
            var p2 = (XMLStudent)xs.Deserialize(s2);//giải mã trở lại thành đối tượng
            DateTime dob;
            if(p2!= null)
            {
                dob = System.DateTime.Parse(p2.Dob + " 12:00:00AM");
                Student s = new Student()
                {
                    Name = p2.Name,
                    Dob = dob,
                    Gender = p2.Gender,
                    Major = p2.Major,
                };
                _context.Students.Add(s);
                _context.SaveChanges() ;
                Load_Data() ;
            }

        }
    }
    [XmlRoot("XMLStudent")]
    public class XMLStudent
    {
        [XmlElement("Id")]
        public string Id { get; set; }

        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("Dob")]
        public string Dob { get; set; }

        [XmlElement("Gender")]
        public bool Gender { get; set; }
        
        [XmlElement("Major")]
        public int Major { get; set; }
    }//end class
}