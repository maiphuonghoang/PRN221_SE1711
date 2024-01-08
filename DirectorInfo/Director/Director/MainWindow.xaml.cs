﻿using DirectorInfo.Models;
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

namespace DirectorInfo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PE_PRN_Fall2023B1Context _context;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(PE_PRN_Fall2023B1Context context)
        {
            InitializeComponent();
            _context = context;
            LoadData();
        }
        public void UpdateGridView()
        {
            List<DirectorDTO> directors = _context.Directors.ToList()
                .Select(item => MapToDirectorDTO(item)).ToList();

            lsDirector.ItemsSource = directors;
        }
        public void LoadData()
        {
            UpdateGridView();
        }
        public Director GetDirectorObject()
        {
            try
            {
                return new Director
                {
                    Id = string.IsNullOrEmpty(txtId.Text)? 0: int.Parse(txtId.Text),
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Dob = dpDob.SelectedDate,
                    Male = cbMale.IsChecked == true? true:false,
                    Nationality = txtNationality.Text
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot get Director", "Get Director");
            }
            return null;
        }

        private void btnSaveToFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSendToServer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddToList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var director = GetDirectorObject();
                if (director != null)
                {
                    director.Id = 0;
                    _context.Directors.Add(director);
                    _context.SaveChanges();
                    UpdateGridView();
                    MessageBox.Show("Insert Director success " + director.Id +" "+ director.Name, "Add Director");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Director failed", "Add Director");
            }
        }

        private void listView_Click(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if(item != null )
            {
                cbMale.IsChecked = ((DirectorDTO)item).Male == true? true : false;
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchText = txtSearch.Text;
            List<DirectorDTO> directors = new List<DirectorDTO>();
            var listDirector = _context.Directors
                .Where(i => (i.Name.Contains(searchText) || (i.Description != null && i.Description.Contains(searchText)))
                || (searchText != null)//nếu k có đk 
                )
                .Select(item => MapToDirectorDTO(item))
                .ToList();
  
            lsDirector.ItemsSource = directors;

        }
        private DirectorDTO MapToDirectorDTO(Director item)
        {
            return new DirectorDTO()
            {
                Id = item.Id,
                Name = item.Name,
                Dob = item.Dob,
                Description = item.Description,
                Male = item.Male,
                GenderString = item.Male == true ? "Male" : "Female",
                Nationality = item.Nationality
            };
        }
        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}