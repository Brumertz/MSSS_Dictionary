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
        public AdminWindow(int staffId, string staffName)
        {
            InitializeComponent(); 
            this.staffId = staffId;
            this.isCreateMode = false; // Update/Delete mode
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
        private void CreateStaff(object sender, RoutedEventArgs e)
        {
            // Check if we are in Create Mode
            if (!isCreateMode)
            {
                statusMessage.Content = "Invalid operation: Not in Create Mode.";
                return;
            }

            // Get staff name from the text box
            string staffName = txtAdminStaffName.Text.Trim();

            // Validate that a name has been entered
            if (string.IsNullOrEmpty(staffName))
            {
                statusMessage.Content = "Please enter a valid Staff Name.";
                return;
            }

            // Generate a new unique Staff ID
            int newStaffId = GenerateNewStaffID();

            // Add the new staff member to MasterFile in MainWindow
            if (MainWindow.MasterFile.ContainsKey(newStaffId))
            {
                statusMessage.Content = "Error: Staff ID already exists.";
                return;
            }

            MainWindow.MasterFile[newStaffId] = staffName;
            statusMessage.Content = "Staff created successfully.";
        }
        private void UpdateStaff(object sender, RoutedEventArgs e)
        {
            // Ensure we are not in Create Mode, as updates should only occur in Update/Delete Mode
            if (isCreateMode)
            {
                statusMessage.Content = "Invalid operation: Not in Update Mode.";
                return;
            }

            // Get the updated staff name
            string updatedName = txtAdminStaffName.Text.Trim();

            // Validate that a name has been provided
            if (string.IsNullOrEmpty(updatedName))
            {
                statusMessage.Content = "Please enter a valid Staff Name.";
                return;
            }

            // Check if the Staff ID exists in MasterFile
            if (MainWindow.MasterFile.ContainsKey(staffId))
            {
                MainWindow.MasterFile[staffId] = updatedName; // Update the name
                statusMessage.Content = "Staff updated successfully.";
            }
            else
            {
                statusMessage.Content = "Error: Staff ID not found.";
            }
        }
        private void DeleteStaff(object sender, RoutedEventArgs e)
        {
            // Ensure we are not in Create Mode, as deletions should only occur in Update/Delete Mode
            if (isCreateMode)
            {
                statusMessage.Content = "Invalid operation: Not in Delete Mode.";
                return;
            }

            // Confirm deletion
            var result = MessageBox.Show("Are you sure you want to delete this staff member?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                // Check if the Staff ID exists in MasterFile and remove it
                if (MainWindow.MasterFile.Remove(staffId))
                {
                    // Clear the text fields
                    txtAdminStaffID.Clear();
                    txtAdminStaffName.Clear();
                    statusMessage.Content = "Staff deleted successfully.";
                }
                else
                {
                    statusMessage.Content = "Error: Staff ID not found.";
                }
            }
            else
            {
                statusMessage.Content = "Deletion cancelled.";
            }
        }
    }
}
