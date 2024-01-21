using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
using System.Xml.Serialization;
using WPFMedicineSE1711.Models;

namespace WPFMedicineSE1711
{
    public partial class MainWindow : Window
    {
        private PRN221_SE1711_MedicineContext _context = new PRN221_SE1711_MedicineContext();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            LoadMedicineData();
            LoadComboBoxData();
        }
        private void LoadMedicineData()
        {
            var medicines = _context.Medicines
                .Include(m => m.Group).Include(m => m.Supplier).ToList();
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
        private void LoadComboBoxData()
        {
            cbGroup.ItemsSource = _context.GroupMedicines.ToList();
            cbSupplier.ItemsSource = _context.Suppliers.ToList();
        }
        private void btnRefesh_Click(object sender, RoutedEventArgs e)
        {
            txtMedicineID.Text = string.Empty;
            txtMedicineName.Text = string.Empty;
            dpExpiriDate.SelectedDate = null;
            txtPrice.Text = string.Empty;
            txtAmount.Text = string.Empty;
            txtPreserve.Text = string.Empty;
            txtUserManual.Text = string.Empty;
            cbGroup.SelectedValue = null;
            cbSupplier.SelectedValue = null;
            LoadData();
        }

        public Medicine GetMedicineObject()
        {
            try
            {
                Medicine medicine = new Medicine
                {
                    MedicineId = txtMedicineID.Text,
                    GroupId = int.Parse(cbGroup.SelectedValue.ToString()),
                    SupplierId = int.Parse(cbSupplier.SelectedValue.ToString()),
                    MedicineName = txtMedicineName.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    Amount = double.Parse(txtAmount.Text),
                    ExpiriDate = dpExpiriDate.SelectedDate,
                    Preserve = txtPreserve.Text,
                    UserManual = txtUserManual.Text,

                };
                return medicine;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var medicine = GetMedicineObject();
                if (medicine != null)
                {
                    _context.Add(medicine);
                    _context.SaveChanges();
                    LoadData();
                    MessageBox.Show("Insert Medicine Success", "Create Medicine");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Medicine Failed: " + ex.Message, "Create Medicine");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var medicine = GetMedicineObject();
                if (medicine != null)
                {
                    var oldMedicine = _context.Medicines.FirstOrDefault(c => c.MedicineId == medicine.MedicineId);
                    if (oldMedicine != null)
                    {
                        oldMedicine.GroupId = medicine.GroupId;
                        oldMedicine.SupplierId = medicine.SupplierId;
                        oldMedicine.MedicineName = medicine.MedicineName;
                        oldMedicine.Price = medicine.Price;
                        oldMedicine.Amount = medicine.Amount;
                        oldMedicine.ExpiriDate = medicine.ExpiriDate;
                        oldMedicine.Preserve = medicine.Preserve;
                        oldMedicine.UserManual = medicine.UserManual;
                        _context.Update(oldMedicine);
                        _context.SaveChanges();
                        LoadData();
                        MessageBox.Show("Update Medicine success", "Update Medicine");
                    }
                    else
                    {
                        MessageBox.Show("Medicine is not exist");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Medicine Failed: " + ex.Message, "Update Medicine");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var medicine = GetMedicineObject();
                if (medicine != null)
                {
                    var existingMedicine = _context.Medicines.FirstOrDefault(c => c.MedicineId == medicine.MedicineId);
                    if (existingMedicine != null)
                    {
                        _context.Remove(existingMedicine);
                        _context.SaveChanges();
                        LoadData();
                        MessageBox.Show("Delete Medicine Success", "Delete Medicine");
                    }
                    else
                    {
                        MessageBox.Show("Medicine is not exist");
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Medicine Failed: " + ex.Message, "Delete Medicine");
            }
        }
        //Đọc 1 file xml lấy ra ds medicine. Kiểm tra nếu chưa có trong db thì insert
        //nếu đã có thì update database với các dữ liệu trong file xml 
        private void btnXml_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                XDocument xmlDoc = XDocument.Load(openFileDialog.FileName);

                foreach (var xe in xmlDoc.Descendants())
                {
                    if (xe.Name.LocalName == "Medicine")
                    {
                        var medicineId = xe.Attribute("MedicineId")?.Value;
                        var medicine = _context.Medicines.FirstOrDefault(m => m.MedicineId == medicineId);

                        if (medicine == null)
                        {
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
        }

        //đọc các đối tượng trong file JSON, sau đó Filter tất cả các thuốc có cùng Group với đối tượng trong file
        private void btnJson_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string jsonContent = File.ReadAllText(openFileDialog.FileName);
                    var data = JsonSerializer.Deserialize<MedicineListWrapper>(jsonContent);
                    List<Medicine> medicineList = data.Medicines;
                    List<int> groupIds = medicineList.Select(m => m.GroupId).ToList();
                    var medicines = _context.Medicines.Where(m => groupIds.Contains(m.GroupId))
                                    .Include(m => m.Group).Include(m => m.Supplier).ToList();
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

                    MessageBox.Show("Load JSON Success");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Load JSON Failed: " + ex.Message);

                }
            }
        }
        public class MedicineListWrapper
        {
            public List<Medicine> Medicines { get; set; }
        }


        private void btnExpridate_Click(object sender, RoutedEventArgs e)
        {
            var today = DateTime.Today;
            var thirtyDaysFromToday = today.AddDays(30);
            dgMedicine.ItemsSource = _context.Medicines
                .Where(m => m.ExpiriDate >= today && m.ExpiriDate <= thirtyDaysFromToday)
                .ToList();
        }

        private void DgMedicine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgMedicine.SelectedItem != null)
            {
                var dataGridMedicine = (dgMedicine.SelectedItem as dynamic);
                Medicine selectedMedicine = new Medicine
                {
                    MedicineId = dataGridMedicine.MedicineId,
                    MedicineName = dataGridMedicine.MedicineName,
                    Price = dataGridMedicine.Price,
                    Amount = dataGridMedicine.Amount,
                    ExpiriDate = dataGridMedicine.ExpiriDate,
                    Preserve = dataGridMedicine.Preserve,
                    UserManual = dataGridMedicine.UserManual,
                    Group = new GroupMedicine { GroupName = dataGridMedicine.GroupName },
                    Supplier = new Supplier { SupplierName = dataGridMedicine.SupplierName }
                };

                txtMedicineID.Text = selectedMedicine.MedicineId.ToString();
                txtMedicineName.Text = selectedMedicine.MedicineName.ToString();
                txtPrice.Text = selectedMedicine.Price.ToString();
                txtAmount.Text = selectedMedicine.Amount.ToString();
                dpExpiriDate.SelectedDate = selectedMedicine.ExpiriDate;
                txtPreserve.Text = selectedMedicine.Preserve.ToString();
                txtUserManual.Text = selectedMedicine.UserManual.ToString();
                cbGroup.Text = selectedMedicine.Group.GroupName;
                cbSupplier.Text = selectedMedicine.Supplier.SupplierName;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }
    }
}
