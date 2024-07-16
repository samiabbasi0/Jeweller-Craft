using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Page_Navigation_App.View
{
    public partial class Customers : UserControl
    {
        private List<Customer> customers = new List<Customer>();
        private List<Customer> filteredCustomers = new List<Customer>();

        public Customers()
        {
            InitializeComponent();

            // Subscribe to the loaded event
            Loaded += Customers_Loaded;
        }

        private void Customers_Loaded(object sender, RoutedEventArgs e)
        {
            // Fetch data from the database and populate the DataGrid
            GetDataFromDatabase();
        }

        private void GetDataFromDatabase()
        {
            try
            {
                string connectionString = @"Data Source=DESKTOP-01A3CCI\SQLEXPRESS;Initial Catalog=jewelry;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM customers";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                Name = reader["customer_name"].ToString(),
                                CustomerID = reader["customer_id"].ToString(),
                                PhoneNumber = reader["phone_number"].ToString(),
                                Email = reader["email"].ToString(),
                                CNICNumber = reader["cnic"].ToString()
                            });
                        }
                    }
                }

                // Set the ItemsSource of the DataGrid
                dataGrid.ItemsSource = customers;
                filteredCustomers.AddRange(customers);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void AddCustomer(Customer customer)
        {
            try
            {
                // Add the customer to the database
                string connectionString = @"Data Source=DESKTOP-01A3CCI\SQLEXPRESS;Initial Catalog=jewelry;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO customers (customer_id, customer_name, cnic, phone_number, email) VALUES (@id, @name, @cnic, @number, @email)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", customer.CustomerID);
                        cmd.Parameters.AddWithValue("@name", customer.Name);
                        cmd.Parameters.AddWithValue("@cnic", customer.CNICNumber);
                        cmd.Parameters.AddWithValue("@number", customer.PhoneNumber);
                        cmd.Parameters.AddWithValue("@email", string.IsNullOrEmpty(customer.Email) ? DBNull.Value : (object)customer.Email);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Update the DataGrid
                GetDataFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Class to represent a customer
        public class Customer
        {
            public string Name { get; set; }
            public string CustomerID { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string CNICNumber { get; set; }
        }

        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            CustomersWindow window = new CustomersWindow(this);
            window.ShowDialog();
            // Update the DataGrid
        }

        private void ClearSearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch != null)
            {
                txtSearch.Text = "";
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshDataGrid();
        }

        public void RefreshDataGrid()
        {
            if (dataGrid != null && txtSearch != null)
            {
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    filteredCustomers = customers.Where(c => c.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                    dataGrid.ItemsSource = filteredCustomers;
                }
                else
                {
                    dataGrid.ItemsSource = customers;
                    filteredCustomers.Clear();
                    filteredCustomers.AddRange(customers);
                }
            }
            dataGrid.ItemsSource = filteredCustomers;
        }
    }
}
