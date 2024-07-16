using System;
using System.Windows;

namespace Page_Navigation_App
{
    //public enum UserRole { Admin, Employee } // Define the UserRole enum

    public partial class MainWindow : Window
    {
        private UserRole _userRole; // Store the user's role

        public MainWindow(UserRole userRole) // Modify constructor to accept UserRole parameter
        {
            InitializeComponent();
            _userRole = userRole; // Store the user's role
            CheckAccess(); // Check access based on user role
        }

        private void CheckAccess()
        {
            // Check the user's role and restrict access accordingly
            if (_userRole == UserRole.Employee)
            {
                // Hide buttons or disable functionality for Employee role
                reportbtn.Visibility = Visibility.Collapsed;
                investmentbtn.Visibility = Visibility.Collapsed;
                // Modify other buttons or UI elements as needed
            }
        }

        // Event handlers for button clicks or other UI interactions
        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Btn_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Checked_2(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Checked_3(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Checked_4(object sender, RoutedEventArgs e)
        {

        }
    }
}
