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
using System.Windows.Shapes;

namespace DictionaryApp
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private int staffId;
        private bool isCreateMode;
        public static Dictionary<int, string> MasterFile = new Dictionary<int, string>();
        public AdminWindow(int staffId, string staffName)
        {
            InitializeComponent(); 
            this.staffId = staffId;
            this.isCreateMode = true; // Update/Delete mode
            txtAdminStaffID.Text = staffId.ToString();
            txtAdminStaffName.Text = staffName;
        }// Constructor for Create Mode
        public AdminWindow(bool isCreateMode)
        {
            InitializeComponent();

            this.isCreateMode = isCreateMode;
            txtAdminStaffID.IsReadOnly = true;
            txtAdminStaffID.Text = GenerateNewStaffID().ToString(); // Auto-generate a new ID
            txtAdminStaffName.Clear(); // Clear the name for new entry
        }// Method to generate a new unique Staff ID starting with 77
        private int GenerateNewStaffID()
        {
            Random rnd = new Random();
            int newId;
            do
            {
                newId = 77000000 + rnd.Next(1000000);
            } while (MainWindow.MasterFile.ContainsKey(newId)); // Ensure ID is unique

            return newId;
        }

        // Create a Staff Method
        private void CreateStaff(object sender, RoutedEventArgs e)
        {
            if (!isCreateMode)
            {
                statusMessage.Content = "Invalid operation: Not in Create Mode.";
                return;
            }

            // Validate that a valid Staff ID has been entered
            if (!int.TryParse(txtAdminStaffID.Text, out int newStaffId) || !txtAdminStaffID.Text.StartsWith("77"))
            {
                statusMessage.Content = "Staff ID must be numeric and start with '77'.";
                return;
            }

            // Check if the ID is unique
            if (MainWindow.MasterFile.ContainsKey(newStaffId))
            {
                statusMessage.Content = "Error: Staff ID already exists. Please enter a unique ID.";
                return;
            }

            // Validate that a name has been provided
            string staffName = txtAdminStaffName.Text.Trim();
            if (string.IsNullOrEmpty(staffName))
            {
                statusMessage.Content = "Please enter a valid Staff Name.";
                return;
            }

            // Add the new staff member to MasterFile
            MainWindow.MasterFile[newStaffId] = staffName;

            

            // Confirm success and close the AdminWindow
            statusMessage.Content = "Staff created successfully.";
            MessageBox.Show("New staff member added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close(); // Close the window after successful creation
        }

        // Delete User Method
        private void DeleteUser(int staffId)
        {
            // Check if the user exists in MasterFile
            if (MainWindow.MasterFile.ContainsKey(staffId))
            {
                // Remove the user from MasterFile (in-memory only)
                MainWindow.MasterFile.Remove(staffId);

                // Display a success message
                MessageBox.Show("User deleted successfully (in-memory only).", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Optionally, clear the text fields after deletion
                txtAdminStaffID.Clear();
                txtAdminStaffName.Clear();
            }
            else
            {
                MessageBox.Show("Error: Staff ID not found in MasterFile.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Update Method
        private void UpdateUser(int staffId, string newStaffName)
        {
            // Check if the user exists in MasterFile
            if (MainWindow.MasterFile.ContainsKey(staffId))
            {
                // Update the user's name in MasterFile (in-memory only)
                MainWindow.MasterFile[staffId] = newStaffName;

                // Display a success message
                MessageBox.Show("User updated successfully (in-memory only).", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Error: Staff ID not found in MasterFile.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UpdateStaff(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtAdminStaffID.Text, out int staffId))
            {
                string newStaffName = txtAdminStaffName.Text.Trim();
                if (!string.IsNullOrEmpty(newStaffName))
                {
                    UpdateUser(staffId, newStaffName);
                }
                else
                {
                    MessageBox.Show("Please enter a valid Staff Name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid Staff ID entered.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteStaff(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtAdminStaffID.Text, out int staffId))
            {
                DeleteUser(staffId);
            }
            else
            {
                MessageBox.Show("Invalid Staff ID entered.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
