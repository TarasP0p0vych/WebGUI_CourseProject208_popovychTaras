using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Customers
{
    public class CustomerEditModel : PageModel
    {
        public CustomersInfo customersInfo = new CustomersInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String customerID = Request.Query["id"];
            try
            {
                String connectionString = "Data Source=NOTEBOOKPRO;Initial Catalog=Beta;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM [Beta].[dbo].[Customers] Where CustomerID = @customerID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@customerID", customerID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                customersInfo.customerID = "" + reader.GetInt32(0);
                                customersInfo.companyName = reader.GetString(1);
                                customersInfo.customerPhone = reader.GetString(2);
                                customersInfo.customerEmail = reader.GetString(3);
                                customersInfo.customerFirstName = reader.GetString(4);
                                customersInfo.customerLastName = reader.GetString(5);
                                customersInfo.customerCountry = reader.GetString(6);
                                customersInfo.customerCity = reader.GetString(7);
                                customersInfo.customerAddress = reader.GetString(8);
                                customersInfo.postalCode = reader.GetString(9);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

        }
        public void OnPost()
        {
            customersInfo.customerID = Request.Form["id"];
            customersInfo.companyName = Request.Form["companyName"];
            customersInfo.customerPhone = Request.Form["customerPhone"];
            customersInfo.customerEmail = Request.Form["customerEmail"];
            customersInfo.customerFirstName = Request.Form["customerFirstName"];
            customersInfo.customerLastName = Request.Form["customerLastName"];
            customersInfo.customerCountry = Request.Form["customerCountry"];
            customersInfo.customerCity = Request.Form["customerCity"];
            customersInfo.customerAddress = Request.Form["customerAddress"];
            customersInfo.postalCode = Request.Form["postalCode"];

            if (string.IsNullOrEmpty(customersInfo.companyName) ||
    string.IsNullOrEmpty(customersInfo.customerPhone) ||
    string.IsNullOrEmpty(customersInfo.customerEmail) ||
    string.IsNullOrEmpty(customersInfo.customerFirstName) ||
    string.IsNullOrEmpty(customersInfo.customerLastName) ||
    string.IsNullOrEmpty(customersInfo.customerCountry) ||
    string.IsNullOrEmpty(customersInfo.customerCity) ||
    string.IsNullOrEmpty(customersInfo.customerAddress) ||
    string.IsNullOrEmpty(customersInfo.postalCode)
    || string.IsNullOrEmpty(customersInfo.customerID))
            {
                errorMessage = "All the fields are required";
                return;
            }
            try
            {
                String connectionString = "Data Source=NOTEBOOKPRO;Initial Catalog=Beta;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "UPDATE [Beta].[dbo].[Customers] SET [CompanyName] = @companyName, [CustomerPhone] = @customerPhone, [CustomerEmail] = @customerEmail, [CustomerFirstName] = @customerFirstName, [CustomerLastName] = @customerLastName, [CustomerCountry] = @customerCountry, [CustomerCity] = @customerCity, [CustomerAddress] = @customerAddress, [PostalCode] = @postalCode WHERE [CustomerID] = @id;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@companyName", customersInfo.companyName);
                        command.Parameters.AddWithValue("@customerPhone", customersInfo.customerPhone);
                        command.Parameters.AddWithValue("@customerEmail", customersInfo.customerEmail);
                        command.Parameters.AddWithValue("@customerFirstName", customersInfo.customerFirstName);
                        command.Parameters.AddWithValue("@customerLastName", customersInfo.customerLastName);
                        command.Parameters.AddWithValue("@customerCountry", customersInfo.customerCountry);
                        command.Parameters.AddWithValue("@customerCity", customersInfo.customerCity);
                        command.Parameters.AddWithValue("@customerAddress", customersInfo.customerAddress);
                        command.Parameters.AddWithValue("@postalCode", customersInfo.postalCode);
                        command.Parameters.AddWithValue("@id", customersInfo.customerID);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/Customers/Index");
        }
    }
}
