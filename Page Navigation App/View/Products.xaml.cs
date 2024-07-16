using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Page_Navigation_App.View
{
    public partial class Products : UserControl
    {
        public ObservableCollection<Home.Product> _productItems = new ObservableCollection<Home.Product>();
        private ObservableCollection<Home.Product> originalProducts;
        private readonly string _connectionString = @"Data Source=DESKTOP-01A3CCI\SQLEXPRESS;Initial Catalog=jewelry;Integrated Security=True";

        public Products()
        {
            InitializeComponent();
            LoadDatafromDatabase();
        }

        private void LoadDatafromDatabase()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string query = "Select tag_number, category, weight, labour_cost, quantity FROM products";
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            _productItems.Add(new Home.Product
                            {
                                Name = reader["category"].ToString(),
                                TagNumber = reader["tag_number"].ToString(),
                                Weight = Convert.ToDouble(reader["weight"]),
                                LabourCost = Convert.ToDecimal(reader["labour_cost"]),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            datagrid.ItemsSource = _productItems;
            originalProducts = new ObservableCollection<Home.Product>(_productItems);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Clear the search query text box
            txtSearch.Text = "";

            // Restore the original data to the data grid
            datagrid.ItemsSource = originalProducts;
        }

        private void Button_Click_add(object sender, RoutedEventArgs e)
        {
            // Open the AddItemWindow
            var addItemWindow = new AddItemWindow(productsWindow: this);
            addItemWindow.ShowDialog();
        }

        public void AddItem(string product, string tagNumber, double weight, decimal labourCost, int quantity)
        {
            var newItem = new Home.Product
            {
                Name = product,
                TagNumber = tagNumber,
                Weight = weight,
                LabourCost = labourCost,
                Quantity = quantity,
            };

            _productItems.Add(newItem);
            originalProducts.Add(newItem);
            datagrid.Items.Refresh(); // Refresh DataGrid to reflect changes
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();

            // If search query is empty, reset the DataGrid to display all items
            if (string.IsNullOrEmpty(searchQuery))
            {
                // Reset DataGrid with original data
                datagrid.ItemsSource = originalProducts;
                return;
            }

            // Filter the items based on the search query
            var filteredProducts = new ObservableCollection<Home.Product>(
                originalProducts.Where(p => p.Name.Equals(searchQuery, StringComparison.OrdinalIgnoreCase))
            );

            // Update the DataGrid with the filtered items
            datagrid.ItemsSource = filteredProducts;
        }

        private void txtSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
