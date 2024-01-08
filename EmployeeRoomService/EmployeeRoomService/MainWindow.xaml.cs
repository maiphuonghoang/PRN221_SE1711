using EmployeeRoomService.Models;
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

namespace EmployeeRoomService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PRN221_Spr22Context _context;
        public MainWindow(PRN221_Spr22Context context)
        {
            InitializeComponent();
            _context = context;
            HandleBeforeLoad();
        }
        public void UpdateGridView()
        {
            listEmployee.ItemsSource = _context.Employees.ToList();

        }
        private void HandleBeforeLoad()
        {
            UpdateGridView();
        }
        public Employee GetEmployeeObject()
        {
            try
            {
                return new Employee
                {
                    Id = string.IsNullOrEmpty(employeeId.Text) ? 0 : int.Parse(employeeId.Text),
                    Name = employeeName.Text,
                    Gender = male.IsChecked == true ? "Male" : "Female",
                    Phone = phone.Text,
                    Dob = dob.SelectedDate,
                    Idnumber = idNumber.Text

                };
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot get employee", "Get Employee");
            }
            return null;
        }

        private void btnRefesh_Click(object sender, RoutedEventArgs e)
        {
            employeeId.Text = string.Empty;
            employeeName.Text = string.Empty;
            male.IsChecked = true;
            phone.Text = string.Empty;
            dob.SelectedDate = null;
            idNumber.Text = string.Empty;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = GetEmployeeObject();
                if(employee != null)
                {
                    employee.Id = 0;
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                    UpdateGridView();
                    MessageBox.Show("Insert employee success " + employee.Id + employee.Name, "Add Employee" );
                }
            }
            catch(Exception ex ) 
            {
                MessageBox.Show("Insert employee failed", "Add Employee");
            }
        }
        

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = GetEmployeeObject();
                if (employee != null)
                {
                    var oldEmployee = _context.Employees.FirstOrDefault(x=>x.Id== employee.Id);
                    if(oldEmployee != null)
                    {
                        oldEmployee.Dob = employee.Dob;
                        oldEmployee.Name = employee.Name;
                        oldEmployee.Phone = employee.Phone;
                        oldEmployee.Idnumber = employee.Idnumber;
                        oldEmployee.Gender = employee.Gender;
                        _context.Employees.Update(oldEmployee);
                        _context.SaveChanges();
                        UpdateGridView();
                        MessageBox.Show("Update employee success", "Update Employee");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update employee failed", "Update Employee");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = GetEmployeeObject();
                if (employee != null)
                {
                    var oldEmployee = _context.Employees.FirstOrDefault(x => x.Id == employee.Id);
                    if (oldEmployee != null)
                    {
                        _context.Employees.Remove(oldEmployee);
                        _context.SaveChanges();
                        UpdateGridView();
                        MessageBox.Show("Delete employee success", "Delete Employee");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete employee failed", "Delete Employee");
            }
        }
        private void listView_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                var gender = ((Employee)item).Gender;
                if(!string.IsNullOrEmpty(gender))
                {
                    if (gender.ToLower() == "female")
                    {
                        female.IsChecked = true;
                    }
                    else
                    {
                        male.IsChecked = true;
                    }
                }
            }

        }
    }
}
