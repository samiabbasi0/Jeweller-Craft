using Microsoft.VisualBasic;
using Page_Navigation_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Printing;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace Page_Navigation_App.View
{
    public partial class Home : UserControl
    {
        // Collection to hold products
        public ObservableCollection<Product> Products { get; set; }
        // Collection to hold current order items
        public ObservableCollection<OrderItem> CurrentOrderItems { get; set; }
        string connectionString = @"Data Source=DESKTOP-01A3CCI\SQLEXPRESS;Initial Catalog=jewelry;Integrated Security=True";

        public Home()
        {
            InitializeComponent();

            // Initialize Products collection
            Products = new ObservableCollection<Product>();
            // Initialize CurrentOrderItems collection
            CurrentOrderItems = new ObservableCollection<OrderItem>();

            // Load products from database
            LoadProductsFromDatabase();

            // Set ItemsSource for DataGrid
            datagrid.ItemsSource = CurrentOrderItems;

            // Subscribe to CollectionChanged event of CurrentOrderItems collection
            CurrentOrderItems.CollectionChanged += CurrentOrderItems_CollectionChanged;
        }

        // Method to load products from the database
        private void LoadProductsFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT tag_number, category, weight, labour_cost, quantity FROM products";
                    using (SqlCommand cmd = new SqlCommand(query, conn))

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product
                            {
                                TagNumber = reader["tag_number"].ToString(),
                                Category = reader["category"].ToString(),
                                Weight = Convert.ToDouble(reader["weight"]),
                                LabourCost = Convert.ToDecimal(reader["labour_cost"]),
                                Quantity = Convert.ToInt32(reader["quantity"])
                            };
                            // Calculate initial price based on your logic (if needed)
                            product.Price = CalculateProductPrice(product.Weight, product.LabourCost, product.Quantity);
                            Products.Add(product);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading products: " + ex.Message);
                }
            }
        }

        // Method to calculate product price (example logic)
        private decimal CalculateProductPrice(double weight, decimal labourCost, int quantity)
        {
            // Replace this with actual price calculation logic if needed
            return (decimal)weight * labourCost * quantity;
        }

        // Method to update total price
        private void UpdateTotalPrice()
        {
            decimal totalPrice = CurrentOrderItems.Sum(i => (decimal)i.Price); // Sum of all prices in the current order
            txtTotalPrice.Text = $"Total Price: PKR {totalPrice:N2}"; // Update TextBlock
        }

        // Event handler for CollectionChanged event of CurrentOrderItems collection
        private void CurrentOrderItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateTotalPrice(); // Update total price when collection changes
        }

        // Event handler for Add Order button click
        private void addorderBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateOrderInput(out int orderId, out int customerId))
            {
                DateTime orderDate = DateTime.Now; // Assuming current date for simplicity

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO orders (order_id, order_date, customer_id) VALUES (@OrderId, @OrderDate, @CustomerId)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@OrderId", orderId);
                            cmd.Parameters.AddWithValue("@OrderDate", orderDate);
                            cmd.Parameters.AddWithValue("@CustomerId", customerId);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Order inserted successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inserting order: " + ex.Message);
                    }
                }
            }
        }

        // Event handler for Add Item button click
        private void additemBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateItemInput(out int orderId, out string tagNumber, out float goldRate, out int quantity))
            {
                var product = Products.FirstOrDefault(p => p.TagNumber == tagNumber);
                if (product == null)
                {
                    MessageBox.Show("Product not found");
                    return;
                }

                // Check if the requested quantity is available
                if (product.Quantity < quantity)
                {
                    MessageBox.Show("Requested quantity exceeds available quantity.");
                    return;
                }

                float price = (goldRate * (float)product.Weight + (float)product.LabourCost) * quantity;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "INSERT INTO transactions (order_id, tag_number, gold_rate, quantity, price) VALUES (@OrderId, @TagNumber, @GoldRate, @Quantity, @Price)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@OrderId", orderId);
                            cmd.Parameters.AddWithValue("@TagNumber", tagNumber);
                            cmd.Parameters.AddWithValue("@GoldRate", goldRate);
                            cmd.Parameters.AddWithValue("@Quantity", quantity);
                            cmd.Parameters.AddWithValue("@Price", price);
                            cmd.ExecuteNonQuery();
                        }

                        // Update the quantity of the product in the database
                        UpdateProductQuantity(conn, tagNumber, product.Quantity - quantity);

                        // Add the item to the current order items collection
                        CurrentOrderItems.Add(new OrderItem
                        {
                            TagNumber = product.TagNumber,
                            Category = product.Category,
                            Weight = product.Weight,
                            LabourCost = product.LabourCost,
                            GoldRate = goldRate,
                            Quantity = quantity,
                            Price = price
                        });

                        MessageBox.Show("Item inserted successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error inserting item: " + ex.Message);
                    }
                }
                quantityTxtbox.Clear();
                tagnumberTxtbox.Clear();
            }
        }

        // Method to update the quantity of a product in the database
        private void UpdateProductQuantity(SqlConnection conn, string tagNumber, int newQuantity)
        {
            string query = "UPDATE products SET quantity = @NewQuantity WHERE tag_number = @TagNumber";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
                cmd.Parameters.AddWithValue("@TagNumber", tagNumber);
                cmd.ExecuteNonQuery();
            }
        }

        // Event handler for End Sale button click
        private void endsaleBtn_Click(object sender, RoutedEventArgs e)
        {
            // Validate input
            if (!ValidateEndSaleInput())
            {
                return;
            }

            // Get order ID from the textbox
            if (!int.TryParse(orderidTxtbox.Text, out int orderId))
            {
                MessageBox.Show("Order ID must be a valid number");
                return;
            }

            // Parse discount
            float discount = 0;
            if (!string.IsNullOrWhiteSpace(discountTxtbox.Text) && !float.TryParse(discountTxtbox.Text, out discount))
            {
                MessageBox.Show("Discount must be a valid number");
                return;
            }

            // Parse advance
            float advance = 0;
            if (!string.IsNullOrWhiteSpace(advanceTxtbox.Text) && !float.TryParse(advanceTxtbox.Text, out advance))
            {
                MessageBox.Show("Advance must be a valid number");
                return;
            }

            // Calculate remaining
            decimal totalPrice = CurrentOrderItems.Sum(item => (decimal)item.Price);
            float remaining = (float)(totalPrice - (decimal)discount - (decimal)advance);

            // Determine status based on completeCheckbox
            string status = completeCheckbox.IsChecked == true ? "Completed" : "Pending";


            // Update orders table
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE orders SET total_price = (SELECT SUM(price) FROM transactions WHERE transactions.order_id = @OrderId GROUP BY transactions.order_id), discount = @Discount, advance = @Advance, remaining = @Remaining, status = @Status WHERE order_id = @OrderId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderId", orderId);
                        cmd.Parameters.AddWithValue("@Discount", discount);
                        cmd.Parameters.AddWithValue("@Advance", advance);
                        cmd.Parameters.AddWithValue("@Remaining", remaining);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Order updated successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating order: " + ex.Message);
                }
            }

            // Generate receipt content
            string receiptContent = GenerateReceiptContent(orderId, GetCustomerIdFromOrderId(orderId));

            // Print the receipt
            PrintReceipt(receiptContent, discount, advance, remaining, status);

        // Clear all input fields
        discountTxtbox.Clear();
            advanceTxtbox.Clear();
            orderidTxtbox.Clear();
            customeridTxtbox.Clear();
            tagnumberTxtbox.Clear();
            goldrateTxtbox.Clear();
            quantityTxtbox.Clear();
            completeCheckbox.IsChecked = false;

            // Clear the current order items
            CurrentOrderItems.Clear();
        }

        // Method to fetch customer ID from the database based on orderId
        private int GetCustomerIdFromOrderId(int orderId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT customer_id FROM orders WHERE order_id = @OrderId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // Validate input for ending sale
        private bool ValidateEndSaleInput()
        {
            if (string.IsNullOrWhiteSpace(orderidTxtbox.Text))
            {
                MessageBox.Show("Order ID cannot be empty");
                return false;
            }

            return true;
        }

        // Validate order input
        private bool ValidateOrderInput(out int orderId, out int customerId)
        {
            orderId = 0;
            customerId = 0;

            if (string.IsNullOrWhiteSpace(orderidTxtbox.Text))
            {
                MessageBox.Show("Order ID cannot be empty");
                return false;
            }
            if (!int.TryParse(orderidTxtbox.Text, out orderId))
            {
                MessageBox.Show("Order ID must be a valid number");
                return false;
            }

            if (string.IsNullOrWhiteSpace(customeridTxtbox.Text))
            {
                MessageBox.Show("Customer ID cannot be empty");
                return false;
            }
            if (!int.TryParse(customeridTxtbox.Text, out customerId))
            {
                MessageBox.Show("Customer ID must be a valid number");
                return false;
            }

            return true;
        }

        // Validate item input
        private bool ValidateItemInput(out int orderId, out string tagNumber, out float goldRate, out int quantity)
        {
            orderId = 0;
            tagNumber = string.Empty;
            goldRate = 0;
            quantity = 0;

            if (string.IsNullOrWhiteSpace(orderidTxtbox.Text))
            {
                MessageBox.Show("Order ID cannot be empty");
                return false;
            }
            if (!int.TryParse(orderidTxtbox.Text, out orderId))
            {
                MessageBox.Show("Order ID must be a valid number");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tagnumberTxtbox.Text))
            {
                MessageBox.Show("Tag number cannot be empty");
                return false;
            }
            tagNumber = tagnumberTxtbox.Text;

            if (string.IsNullOrWhiteSpace(goldrateTxtbox.Text))
            {
                MessageBox.Show("Gold rate cannot be empty");
                return false;
            }
            if (!float.TryParse(goldrateTxtbox.Text, out goldRate))
            {
                MessageBox.Show("Gold rate must be a valid number");
                return false;
            }

            if (string.IsNullOrWhiteSpace(quantityTxtbox.Text))
            {
                MessageBox.Show("Quantity cannot be empty");
                return false;
            }
            if (!int.TryParse(quantityTxtbox.Text, out quantity))
            {
                MessageBox.Show("Quantity must be a valid number");
                return false;
            }

            return true;
        }
            
        // Method to fetch customer details from the database
        private string GetCustomerDetails(int customerId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM customers WHERE customer_id = @CustomerId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return $"Customer ID: {reader["customer_id"]}\n" +
                                   $"Name: {reader["customer_name"]}\n" +
                                   $"CNIC: {reader["cnic"]}\n" +
                                   $"Phone: {reader["phone_number"]}";
                        }
                    }
                }
            }
            return "Customer details not found.";
        }

        private string GenerateReceiptContent(int orderId, int customerId)
        {
            var receipt = new StringBuilder();
            receipt.AppendLine("===== Order Receipt =====");
            receipt.AppendLine($"Order ID: {orderId}");
            receipt.AppendLine($"Order Date: {DateTime.Now}");
            receipt.AppendLine();
            receipt.AppendLine("Customer Details:");
            receipt.AppendLine(GetCustomerDetails(customerId));
            receipt.AppendLine();
            receipt.AppendLine("Product Details:");

            // Create a table for product details
            var table = new StringBuilder();
            table.AppendLine("| Tag Number | Category | Weight | Labour Cost | Gold Rate | Quantity | Price |");
            table.AppendLine("|------------|----------|--------|-------------|-----------|----------|-------|");

            // Add each product as a row in the table
            foreach (var item in CurrentOrderItems)
            {
                table.AppendLine($"| {item.TagNumber,-11} | {item.Category,-9} | {item.Weight,-6} | {item.LabourCost,-13:C} | {item.GoldRate,-11:C} | {item.Quantity,-8} | {item.Price,-5:C} |");
            }

            // Append the table to the receipt
            receipt.AppendLine(table.ToString());

            // Calculate total price
            decimal totalPrice = (decimal)CurrentOrderItems.Sum(i => i.Price);

            receipt.AppendLine("=========================");
            receipt.AppendLine($"Total Price: PKR {totalPrice:N2}");

            return receipt.ToString();
        }

        private void PrintReceipt(string receiptContent, float discount, float advance, float remaining, string status)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                FlowDocument document = new FlowDocument();

                // Adding title
                Paragraph title = new Paragraph(new Run("Order Receipt"));
                title.FontSize = 24;
                title.FontWeight = FontWeights.Bold;
                title.TextAlignment = TextAlignment.Center;
                title.Margin = new Thickness(0, 0, 0, 20); // Adding bottom margin for spacing

                document.Blocks.Add(title);

                // Adding receipt content
                Paragraph receipt = new Paragraph(new Run(receiptContent));
                receipt.Margin = new Thickness(0, 0, 0, 20); // Adding bottom margin for spacing
                document.Blocks.Add(receipt);

                // Adding additional order details
                Paragraph additionalDetails = new Paragraph();
                additionalDetails.Margin = new Thickness(0, 5, 0, 20);
                additionalDetails.Inlines.Add(new Run($"Discount: PKR {discount:N2}\n"));
                additionalDetails.Inlines.Add(new Run($"Net Amount: PKR {(decimal)(CurrentOrderItems.Sum(i => (decimal)i.Price) - (decimal)discount):N2}\n"));
                additionalDetails.Inlines.Add(new Run($"Advance: PKR {advance:N2}\n"));
                additionalDetails.Inlines.Add(new Run($"Remaining: PKR {remaining:N2}\n"));
                additionalDetails.Inlines.Add(new Run($"Status: {status}\n"));
                document.Blocks.Add(additionalDetails);

                // Set page padding to increase the margins
                document.PagePadding = new Thickness(50);
                document.PageWidth = printDialog.PrintableAreaWidth - 100;
                document.PageHeight = printDialog.PrintableAreaHeight - 100;


                // Ensure proper layout before printing
                IDocumentPaginatorSource idpSource = document;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "Order Receipt");
            }
        }

        // Event handler for Print button click
        private void printBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(orderidTxtbox.Text, out int orderId))
            {
                MessageBox.Show("Order ID must be a valid number");
                return;
            }
            if (!int.TryParse(customeridTxtbox.Text, out int customerId))
            {
                MessageBox.Show("Customer ID must be a valid number");
                return;
            }

            // Generate receipt content
            string receiptContent = GenerateReceiptContent(orderId, customerId);

            // Print the receipt
            //PrintReceipt(receiptContent);
        }

        // Class to represent a product
        public class Product
        {
            public string TagNumber { get; set; }
            public string Category { get; set; }
            public double Weight { get; set; }
            public decimal LabourCost { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public string Name { get; set; }
        }

        // Class to represent an order item
        public class OrderItem
        {
            public string TagNumber { get; set; }
            public string Category { get; set; }
            public double Weight { get; set; }
            public decimal LabourCost { get; set; }
            public float GoldRate { get; set; }
            public int Quantity { get; set; }
            public float Price { get; set; }
        }
        // Event handler for Print button click
        // Event handler for Print button click
    }
}
