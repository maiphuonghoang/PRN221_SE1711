using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;
using WPFMedicineSE1711.Models;

namespace WPFMedicineSE1711
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PRN221_SE1711_MedicineContext _context = new PRN221_SE1711_MedicineContext();
        public MainWindow()
        {
            InitializeComponent();
            LoadMedicineData();
        }
        private void LoadMedicineData()
        {
            var medicines = _context.Medicines
                .Include(m => m.Group).Include(m => m.Supplier).ToList();
            //lấy nguồn dữ liệu cho data grid view 
            dgMedicine.ItemsSource = medicines.Select(m => new
            {
                m.MedicineId,
                m.MedicineName,
                m.Price,
                m.Amount,
                m.ExpiriDate,
                m.Preserve,
                m.UserManual,
                GroupName = m.Group.GroupName,
                SupplierName = m.Supplier.SupplierName
            }).ToList();
        }
        private void btnRefesh_Click(object sender, RoutedEventArgs e)
        {

        }



        private void LoadComboBoxData()
        {
            cbGroup.ItemsSource = _context.GroupMedicines.ToList();
            cbSupplier.ItemsSource = _context.Suppliers.ToList();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
        //Đọc 1 file xml lấy ra ds medicine. Kiểm tra nếu chưa có trong db thì insert
        //nếu đã có thì update database với các dữ liệu trong file xml 
        private void btnXml_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                XDocument xmlDoc = XDocument.Load(openFileDialog.FileName);
                foreach (var xe in xmlDoc.Descendants("Medicine"))//lấy 1 đối tượng có thẻ <Medicine>
                {
                    var medicineId = xe.Element("MedicineId")?.Value;
                    var medicine = _context.Medicines.FirstOrDefault(m => m.MedicineId == medicineId);
                    if (medicine == null)
                    {
                        //Thêm mới nếu medicine k tồn tại 
                        medicine = new Medicine()
                        {
                            MedicineId = medicineId,
                            GroupId = int.Parse(xe.Element("GroupId")?.Value ?? "0"),
                            SupplierId = int.Parse(xe.Element("SupplierId")?.Value ?? "0"),
                            MedicineName = xe.Element("MedicineName")?.Value,
                            Price = decimal.Parse(xe.Element("Price")?.Value ?? "0"),
                            Amount = double.Parse(xe.Element("Amount")?.Value ?? "0"),
                            ExpiriDate = DateTime.Parse(xe.Element("ExpiriDate")?.Value ?? DateTime.Now.ToString()),
                            Preserve = xe.Element("Preserve")?.Value,
                            UserManual = xe.Element("UserManual")?.Value

                        };
                        _context.Medicines.Add(medicine);
                    }
                    else
                    {
                        //Cập nhật nếu MedicineId tồn tại 
                        medicine.GroupId = int.Parse(xe.Element("GroupId")?.Value ?? "0");
                        medicine.SupplierId = int.Parse(xe.Element("SupplierId")?.Value ?? "0");
                        medicine.MedicineName = xe.Element("MedicineName")?.Value;
                        medicine.Price = decimal.Parse(xe.Element("Price")?.Value ?? "0");
                        medicine.Amount = double.Parse(xe.Element("Amount")?.Value ?? "0");
                        medicine.ExpiriDate = DateTime.Parse(xe.Element("ExpiriDate")?.Value ?? DateTime.Now.ToString());
                        medicine.Preserve = xe.Element("Preserve")?.Value;
                        medicine.UserManual = xe.Element("UserManual")?.Value;

                    }
                    _context.SaveChanges();
                    LoadMedicineData();
                }
            }
        }

        private void btnJson_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExpridate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DgMedicine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
