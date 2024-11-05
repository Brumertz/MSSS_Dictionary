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
using System.IO;


namespace DictionaryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Static and public Dictionary as required
        public static Dictionary<int, string> MasterFile = new Dictionary<int, string>();
        // Define the command for opening the Admin GUI
        public static RoutedUICommand OpenAdminCommand = new RoutedUICommand("Open Admin", "OpenAdminCommand", typeof(MainWindow));
        public static RoutedCommand ClearStaffIDFilterCommand = new RoutedCommand();
        public static RoutedCommand ClearStaffNameFilterCommand = new RoutedCommand();
        
        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromCsv("MalinStaffNamesV3.csv");
            DisplayData();
            CommandBindings.Add(new CommandBinding(ClearStaffNameFilterCommand, ClearAndFocusStaffNameFilter));
            CommandBindings.Add(new CommandBinding(ClearStaffIDFilterCommand, ClearAndFocusStaffIDFilter));
            CommandBindings.Add(new CommandBinding(OpenAdminCommand, OpenAdminGui));
        }
        private void LoadDataFromCsv(string filePath)
        {

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
            if (listBoxFilteredResults.SelectedItem != null)
            {
                // Retrieve the selected Staff ID and Name from listBoxFilteredResults
                string selectedText = listBoxFilteredResults.SelectedItem.ToString();
                var parts = selectedText.Split(new[] { " - " }, StringSplitOptions.None);

                if (parts.Length == 2 && int.TryParse(parts[0], out int staffId))
                {
                    string staffName = parts[1].Trim();

                    // Check if we need to open in "Create Mode" for new user
                    if (staffId == 77 && string.IsNullOrEmpty(staffName))
                    {
                        // Open AdminWindow in Create Mode (e.g., pass special parameter or set a flag)
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
                MessageBox.Show("Please select a record to edit or leave Staff ID as 77 and Staff Name empty to create a new entry.",
                    "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
} 






