﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace SortedDictionaryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Static and public Dictionary as required
        public static Dictionary<int, string> MasterFile = new Dictionary<int, string>();
        // Define the command for opening the Admin GUI
        public static readonly RoutedUICommand OpenAdminCommand = new RoutedUICommand("Open Admin", "OpenAdminCommand", typeof(MainWindow));
        public static readonly RoutedCommand ClearStaffIDFilterCommand = new RoutedCommand();
        public static readonly RoutedCommand ClearStaffNameFilterCommand = new RoutedCommand();
        public static readonly RoutedUICommand SaveDataCommand = new RoutedUICommand("Save Data", "SaveDataCommand", typeof(MainWindow));
        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromCsv("MalinStaffNamesV3.csv");
            DisplayData();
            CommandBindings.Add(new CommandBinding(ClearStaffNameFilterCommand, ClearAndFocusStaffNameFilter));
            CommandBindings.Add(new CommandBinding(ClearStaffIDFilterCommand, ClearAndFocusStaffIDFilter));
            CommandBindings.Add(new CommandBinding(OpenAdminCommand, OpenAdminGui));
            CommandBindings.Add(new CommandBinding(SaveDataCommand, SaveData_Click)); // Bind SaveDataCommand to SaveData_Click

        }
        private void LoadDataFromCsv(string filePath)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();

                        // Check if the line is not null and contains data
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            var values = line.Split(',');

                            // Ensure values contain at least two elements for ID and Name
                            if (values.Length >= 2 && int.TryParse(values[0], out int id))
                            {
                                MasterFile[id] = values[1];
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
            stopwatch.Stop();
            Trace.WriteLine($"LoadDataFromCsv execution time: {stopwatch.ElapsedMilliseconds} ms");
        }
        // Method to display data in a read-only list box
        private void DisplayData()
        {
            listBoxAllItems.ItemsSource = MasterFile.Select(item => $"{item.Key} - {item.Value}");
        }
        private void FilterData(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Get the current text from the filters
            string nameFilter = txtStaffNameFilter.Text.Trim();
            string idFilter = txtStaffIDFilter.Text.Trim();

            // Filter the Dictionary based on both Name and ID filters
            var filteredResults = MasterFile.Where(item =>
                (string.IsNullOrEmpty(nameFilter) || item.Value.IndexOf(nameFilter, StringComparison.OrdinalIgnoreCase) >= 0) &&
                (string.IsNullOrEmpty(idFilter) || item.Key.ToString().StartsWith(idFilter))
            ).Select(item => $"{item.Key} - {item.Value}");

            // Update the filtered list box with the new results
            listBoxFilteredResults.ItemsSource = filteredResults.ToList();
        }
        private void ClearAndFocusStaffNameFilter(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            txtStaffNameFilter.Clear();
            txtStaffNameFilter.Focus();
        }
        private void ClearAndFocusStaffIDFilter(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            txtStaffIDFilter.Clear();
            txtStaffIDFilter.Focus();
        }
        private void listBoxFilteredResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ensure an item is selected in the list box
            if (listBoxFilteredResults.SelectedItem != null)
            {
                // Get the selected item text
                string selectedText = listBoxFilteredResults.SelectedItem.ToString();

                // Assuming each item in the list box is formatted as "ID - Name", split by " - "
                var parts = selectedText.Split(new[] { " - " }, StringSplitOptions.None);

                // Check that the split operation provided both an ID and Name
                if (parts.Length == 2)
                {
                    // Set the values of the text boxes with the selected item's ID and Name
                    txtSelectedStaffID.Text = parts[0].Trim();
                    txtSelectedStaffName.Text = parts[1].Trim();
                }
            }
        }// Method to open the Admin GUI with Alt + A
        private void OpenAdminGui(object sender, ExecutedRoutedEventArgs e)
        {
            // Check if an item is selected in the list
            if (listBoxFilteredResults.SelectedItem != null)
            {
                // Retrieve the selected Staff ID and Name from listBoxFilteredResults
                string selectedText = listBoxFilteredResults.SelectedItem.ToString();
                var parts = selectedText.Split(new[] { " - " }, StringSplitOptions.None);

                if (parts.Length == 2 && int.TryParse(parts[0], out int staffId))
                {
                    string staffName = parts[1].Trim();

                    // Check if we need to open in "Create Mode" specifically for Staff ID 77 with empty name
                    if (staffId == 77 && string.IsNullOrEmpty(staffName))
                    {
                        // Open AdminWindow in Create Mode
                        AdminWindow adminWindow = new AdminWindow(true); // Passing true for "Create Mode"
                        adminWindow.ShowDialog();
                    }
                    else
                    {
                        // Open AdminWindow in Update/Delete Mode
                        AdminWindow adminWindow = new AdminWindow(staffId, staffName);
                        adminWindow.ShowDialog();
                    }
                }
            }
            else
            {
                // New logic: Check for "Create Mode" criteria when no item is selected
                if (txtSelectedStaffID.Text == "77" && string.IsNullOrEmpty(txtSelectedStaffName.Text))
                {
                    // Open AdminWindow in Create Mode if Staff ID is 77 and Name is empty
                    AdminWindow adminWindow = new AdminWindow(true); // Passing true for "Create Mode"
                    adminWindow.ShowDialog();
                }
                else
                {
                    // Prompt user to select a record or enter 77 as Staff ID with an empty Staff Name
                    MessageBox.Show("Please select a record to edit, or set Staff ID to 77 and leave Staff Name empty to create a new entry.",
                        "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void SaveData_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Create a SaveFileDialog to allow the user to choose where to save the data
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            saveFileDialog.Title = "Save Staff Data";
            saveFileDialog.FileName = "MalinStaffNamesV3.csv"; // Default file name

            // Show the dialog and get the selected file path
            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var entry in MasterFile)
                        {
                            writer.WriteLine($"{entry.Key},{entry.Value}");
                        }
                    }
                    MessageBox.Show("Data saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                stopwatch.Stop();
                Trace.WriteLine($"SaveData execution time: {stopwatch.ElapsedMilliseconds} ms");
            }
        }
        public void RefreshListBox()
        {
            // Convert MasterFile to a list format suitable for display
            listBoxFilteredResults.ItemsSource = MainWindow.MasterFile
                .Select(item => $"{item.Key} - {item.Value}")
                .ToList();
        }
    }
}


