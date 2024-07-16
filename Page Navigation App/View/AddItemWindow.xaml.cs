// AddItemWindow.xaml.cs
using System;
using System.Windows;
using System.Data.SqlClient;

namespace Page_Navigation_App.View
{
    public partial class AddItemWindow : Window
    {
        private Products _productsWindow;
        private Home _homeWindow;
        string connectionString = @"Data Source=DESKTOP-01A3CCI\SQLEXPRESS;Initial Catalog=jewelry;Integrated Security=True";

        public AddItemWindow(Products productsWindow = null, Home homeWindow = null)
        {
            InitializeComponent();
            _productsWindow = productsWindow;
            _homeWindow = homeWindow;
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Retrieve input values
                string product = txtProduct.Text;
                string tagNumber = txtTagNumber.Text;
                double weight = double.Parse(txtWeight.Text);
                decimal labourCost = decimal.Parse(txtLabourCost.Text);
                int quantity = int.Parse(txtQuantity.Text);

                // Check for empty inputs
                if (string.IsNullOrWhiteSpace(product) || string.IsNullOrWhiteSpace(tagNumber) ||
                    string.IsNullOrWhiteSpace(txtWeight.Text) || string.IsNullOrWhiteSpace(txtLabourCost.Text) ||
                    string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                // Add item to the corresponding window's DataGrid
                if (_productsWindow != null)
                {
                    _productsWindow.AddItem(product, tagNumber, weight, labourCost, quantity);
                }
                else
                {
                    MessageBox.Show("Window reference not provided.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "insert into products(tag_number, category, weight, labour_cost, quantity) " +
                                    "Values (@TagNumber, @Category, @Weight, @LabourCost, @Quantity)";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@TagNumber", tagNumber);
                        cmd.Parameters.AddWithValue("@Category", product);
                        cmd.Parameters.AddWithValue("@Weight", weight);
                        cmd.Parameters.AddWithValue("@LabourCost", labourCost);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Data inserted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to insert data.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }

                // Close the AddItemWindow
                Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Invalid input format. Please enter valid numeric values: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
