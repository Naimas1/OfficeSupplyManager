using System;
using System.Data.SqlClient;
using System.Data;

public class OfficeSupplyManager
{
    // ...

    public void DisplayAllProducts()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Products";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Products");

                DataTable productsTable = dataSet.Tables["Products"];

                Console.WriteLine("Інформація про товари:");

                foreach (DataRow row in productsTable.Rows)
                {
                    Console.WriteLine($"ID: {row["ProductID"]}, Назва: {row["ProductName"]}, Тип: {row["ProductType"]}, " +
                                      $"Кількість: {row["Quantity"]}, Собівартість: {row["Cost"]}, " +
                                      $"Постачальник: {row["SupplierName"]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при виведенні товарів: {ex.Message}");
        }
    }

    public void DisplayAllSales()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Sales";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "Sales");

                DataTable salesTable = dataSet.Tables["Sales"];

                Console.WriteLine("Інформація про продажі:");

                foreach (DataRow row in salesTable.Rows)
                {
                    Console.WriteLine($"ID: {row["SaleID"]}, ID товару: {row["ProductID"]}, Менеджер: {row["SalesManager"]}, " +
                                      $"Компанія покупця: {row["CustomerCompany"]}, " +
                                      $"Кількість проданих: {row["QuantitySold"]}, Ціна за одиницю: {row["UnitPrice"]}, " +
                                      $"Дата продажу: {row["SaleDate"]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при виведенні продажів: {ex.Message}");
        }
    }

    public void DisplaySalesManagers()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT SalesManager FROM Sales";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet, "SalesManagers");

                DataTable salesManagersTable = dataSet.Tables["SalesManagers"];

                Console.WriteLine("Менеджери з продажу:");

                foreach (DataRow row in salesManagersTable.Rows)
                {
                    Console.WriteLine($"Менеджер: {row["SalesManager"]}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при виведенні менеджерів з продажу: {ex.Message}");
        }
    }

    internal void CreateDatabase()
    {
        throw new NotImplementedException();
    }

    // Додайте інші методи відповідно до ваших потреб
}

class Program
{
    static void Main()
    {
        string connectionString = "YourConnectionString";

        OfficeSupplyManager officeSupplyManager = new OfficeSupplyManager(connectionString);
        officeSupplyManager.CreateDatabase();

        // Приклад виведення інформації про товари
        officeSupplyManager.DisplayAllProducts();

        // Приклад виведення інформації про продажі
        officeSupplyManager.DisplayAllSales();

        // Приклад виведення інформації про менеджерів з продажу
        officeSupplyManager.DisplaySalesManagers();
    }
}

