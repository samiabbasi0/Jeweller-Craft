using System;
using System.Windows;
using System.Data.SqlClient;

namespace Page_Navigation_App.View
{
    // Custom exception for empty fields
    public class EmptyFieldException : Exception
    {
        public EmptyFieldException(string fieldName) : base($"The field '{fieldName}' cannot be empty.")
        {
        }
    }

    public partial class CustomersWindow : Window
    {
        private Customers parentCustomersControl;
        private SqlConnection con;

        public CustomersWindow(Customers parent)
        {
            InitializeComponent();
            parentCustomersControl = parent;
            con = new SqlConnection(@"Data Source=DESKTOP-01A3CCI\SQLEXPRESS;Initial Catalog=jewelry;Integrated Security=True");
        }

        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if any required field is empty
                if (string.IsNullOrWhiteSpace(txtName.Text))
                    throw new EmptyFieldException("Name");
                if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
                    throw new EmptyFieldException("Customer ID");
                if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
                    throw new EmptyFieldException("Phone Number");
                if (string.IsNullOrWhiteSpace(txtCNICNumber.Text))
                    throw new EmptyFieldException("CNIC Number");

                // Open the database connection
                con.Open();

                // Create and execute the SQL command
                string query = "INSERT INTO customers (customer_id, customer_name, cnic, phone_number, email) VALUES (@id, @name, @cnic, @number, @email)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", txtCustomerID.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@cnic", txtCNICNumber.Text);
                    cmd.Parameters.AddWithValue("@number", txtPhoneNumber.Text);

                    // Check if email is empty, if so, insert NULL
                    if (string.IsNullOrWhiteSpace(txtEmail.Text))
                        cmd.Parameters.AddWithValue("@email", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    // Execute the command
                    cmd.ExecuteNonQuery();
                }

                // Close the database connection
                con.Close();

                // Refresh the data gridc
                parentCustomersControl.RefreshDataGrid();

                // Close the window after adding the customer
                this.Close();
            }
            catch (EmptyFieldException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                // Close the database connection in case of any error
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
