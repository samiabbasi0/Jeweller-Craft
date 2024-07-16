using System.Windows;

namespace Page_Navigation_App.View
{
    public partial class LoginPage : Window
    {
        // Hardcoded credentials and roles (replace with your own authentication logic)
        private const string AdminUsername = "admin";
        private const string AdminPassword = "admin123";
        private const string EmployeeUsername = "employee";
        private const string EmployeePassword = "employee123";
        private const string AccountantUsername = "accountant";
        private const string AccountantPassword = "accountant123";
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Password;

            UserRole userRole = AuthenticateUser(enteredUsername, enteredPassword);

            if (userRole != UserRole.Admin && userRole != UserRole.Employee)
            {
                // Invalid credentials
                txtError.Visibility = Visibility.Visible;
                txtError.Text = "Invalid username or password.";
            }
            else
            {
                // Successful login
                MainWindow main = new MainWindow(userRole); // Pass the user's role to the main window
                main.Show();
                Close(); // Close the login window
            }
        }

        private UserRole AuthenticateUser(string username, string password)
        {
            if (username == AdminUsername && password == AdminPassword)
            {
                return UserRole.Admin;
            }
            else if (username == EmployeeUsername && password == EmployeePassword)
            {
                return UserRole.Employee;
            }
            else if (username == AccountantUsername && password == AccountantPassword)
            {
                return UserRole.Accountant;
            }
            else
            {
                return (UserRole)(-1); // Return an invalid role if authentication fails
            }
        }
    }
}
