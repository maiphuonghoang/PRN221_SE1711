using System;
using System.Collections.Generic;
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
using GridFormDemo.Models;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Text.Json;

namespace GridFormDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public readonly UniversityDBContext _context;// lay dbcontext trong model de dung


        public MainWindow()
        {
            InitializeComponent();
            _context = new UniversityDBContext();// 
            DGView.ItemsSource = _context.Studentifs.ToList();
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {

        }
        private Studentif getInfo()
        {
            Studentif student = new Studentif();
            student.Rollnumber = txtRollNumber.Text;
            student.StudentName = txtName.Text;
            student.Dateofbirth = dtBirth.SelectedDate;
            student.Address = txtAddress.Text;
            return student;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //lấy studen infor từ form--> kiểm tra roolnumber đã có chưa. nếu chưa có thì thêm -->save change
            //nếu có rồi thì hiện thông báo trùng mã
            Studentif student = getInfo();
            if (student != null)
            {
                var oldInfor = _context.Studentifs.FirstOrDefault(c => c.Rollnumber == student.Rollnumber);
                if (oldInfor == null)
                {
                    _context.Studentifs.Add(student);
                    _context.SaveChanges();
                    DGView.ItemsSource = _context.Studentifs.ToList();
                }
                else
                {
                    MessageBox.Show("The rollnumber " + student.Rollnumber.ToString() + " is exited!");
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //lấy studen infor từ form--> kiểm tra roolnumber đã có chưa. nếu đã có thì sửa -->save change
            //nếu chưa có thì bỏ qua
            Studentif student = getInfo();
            if (student != null)
            {
                var oldInfor = _context.Studentifs.FirstOrDefault(c => c.Rollnumber == student.Rollnumber);
                if (oldInfor != null)
                {
                    oldInfor.Address = student.Address;
                    oldInfor.StudentName = student.StudentName;
                    oldInfor.Dateofbirth = student.Dateofbirth;
                    _context.Studentifs.Update(oldInfor);
                    _context.SaveChanges();
                    DGView.ItemsSource = _context.Studentifs.ToList();
                }
                else
                {
                    MessageBox.Show("The rollnumber " + student.Rollnumber.ToString() + " is not exited!");
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Studentif student = getInfo();
            if (student != null)
            {
                var oldInfor = _context.Studentifs.FirstOrDefault(c => c.Rollnumber == student.Rollnumber);
                if (oldInfor != null)
                {
                    var resul = MessageBox.Show("are you sure to delete " + student.Rollnumber.ToString(), "Question?", MessageBoxButton.YesNoCancel);
                    if (resul == MessageBoxResult.Yes)
                    {
                        _context.Studentifs.Remove(oldInfor);
                        _context.SaveChanges();
                    }
                    DGView.ItemsSource = _context.Studentifs.ToList();
                }
                else
                {
                    MessageBox.Show("The rollnumber " + student.Rollnumber.ToString() + " is not exited!");
                }
            }
        }

        private void LeftButton_Click(object sender, MouseButtonEventArgs e)
        {
            var aStudent = (sender as DataGrid).SelectedItems; // sender mang dong tt cua DataGrid
            if (aStudent != null)       // ep kieu ve Arr student neu 0 rong
            {
                Models.Studentif current = (Models.Studentif)aStudent[0]; // obj Current ep ve kieu cua context
                if (current != null)
                {

                }

            }
        }

        private void btnJson_Click(object sender, RoutedEventArgs e)
        {
            //đọc file json và lưu database các sinh viên nếu chưa có trong csdl
            string filename = "StudentFile.json";
            String data = File.ReadAllText(filename);
            List<Studentif> s;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
               
                s = JsonSerializer.Deserialize<List<Studentif>>(data);//Giải mã chuỗi Json -> list đối tượng 

            }
            foreach (var item in s)
            {
                if (item != null)
                {
                    var arrow = _context.Studentifs.FirstOrDefault(c => c.Rollnumber == item.Rollnumber);
                    if (arrow == null)
                    {
                        _context.Studentifs.Add(item);
                        _context.SaveChanges();
                        DGView.ItemsSource = _context.Studentifs.ToList();
                    }
                    else
                    {
                        MessageBox.Show("The rollnumber " + item.Rollnumber.ToString() + "is existed");
                    }
                }
            }

        }

        private void btnLoadJson_Click(object sender, RoutedEventArgs e)
        {
            //Lọc các sinh viên nằm trong độ tuổi có trong file Json
            TimeSpan min = TimeSpan.MaxValue, max = TimeSpan.MinValue;
            DateTime timemin = DateTime.MinValue, timemax = DateTime.MaxValue;
            string filename = "StudentFile.json";
            string data = File.ReadAllText(filename);
            List<Studentif> s;  
            using(FileStream fs = new FileStream(filename, FileMode.Open))
            {
                s = JsonSerializer.Deserialize<List<Studentif>>(data);
            }
            foreach(var item in s)//lấy name của 2 thành phần đầu trong list và tìm all sv có tên chứa các tên như vậy 
            { 
                if (item != null)
                {
                    TimeSpan x = (TimeSpan)(DateTime.Now - item.Dateofbirth);
                    if(x < min)
                    {
                        min = x; timemin = (DateTime)item.Dateofbirth;
                    }
                    if(x> max) { 
                        max = x; timemax = (DateTime)item.Dateofbirth;
                    }
                }
            }
            DGView.ItemsSource = _context.Studentifs.Where(x=>x.Dateofbirth <= timemin && x.Dateofbirth >= timemax).ToList();
        }

        private void btnXML_Click(object sender, RoutedEventArgs e)
        {
            //Đọc file XML và lưu vào db 
            string filename = "aStudent.xml";
            List<Studentif> s;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Studentif>), new XmlRootAttribute("Students"));
                s = (List<Studentif>)xmlSerializer.Deserialize(fs);//Giải mã file xml thành list đối tượng 

            }
            foreach (var item in s)
            {
                if (item != null)
                {
                    var arrow = _context.Studentifs.FirstOrDefault(c => c.Rollnumber == item.Rollnumber);
                    if (arrow == null)
                    {
                        _context.Studentifs.Add(item);
                        _context.SaveChanges();
                        DGView.ItemsSource = _context.Studentifs.ToList();
                    }
                    else
                    {
                        MessageBox.Show("The rollnumber " + item.Rollnumber.ToString() + "is existed");
                    }
                }
            }
        }

        private void DGView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void saveXML_Click(object sender, RoutedEventArgs e)
        {
            List<Studentif> studentifs = DGView.ItemsSource as List<Studentif>;
            if (studentifs != null)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Studentif>));
                string filepath = "XML1.xml";
                using (FileStream f = new FileStream(filepath, FileMode.Create))
                {
                    xmlSerializer.Serialize(f, studentifs);
                }
                MessageBox.Show("success");
            }
        }

        private void saveJson_Click(object sender, RoutedEventArgs e)
        {
            //lưu dữ liệu từ datagrid xuống file json 
            List<Studentif> studentifs = DGView.ItemsSource as List<Studentif>;
            if (studentifs != null)
            {
                string filepath = "Jsons1.json";
                using (FileStream f = new FileStream(filepath, FileMode.Create))
                {
                    JsonSerializer.Serialize(f, studentifs);
                }
                MessageBox.Show("success");
            }
        }
    }
}

