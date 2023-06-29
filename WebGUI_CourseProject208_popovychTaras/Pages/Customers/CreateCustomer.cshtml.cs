using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Customers
{
    public class CreateCustomerModel : PageModel
    {
        public CustomersInfo customersInfo = new CustomersInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnPost()
        {
            customersInfo.customerID = Request.Form["customerID"];
            customersInfo.companyName = Request.Form["companyName"];
            customersInfo.customerPhone = Request.Form["customerPhone"];
            customersInfo.customerEmail = Request.Form["customerEmail"];
            customersInfo.customerFirstName = Request.Form["customerFirstName"];
            customersInfo.customerLastName = Request.Form["customerLastName"];
            customersInfo.customerCountry = Request.Form["customerCountry"];
            customersInfo.customerCity = Request.Form["customerCity"];
            customersInfo.customerAddress = Request.Form["customerAddress"];
            customersInfo.postalCode = Request.Form["postalCode"];


            if (string.IsNullOrEmpty(Request.Form["companyName"]) ||
    string.IsNullOrEmpty(Request.Form["customerPhone"]) ||
    string.IsNullOrEmpty(Request.Form["customerEmail"]) ||
    string.IsNullOrEmpty(Request.Form["customerFirstName"]) ||
    string.IsNullOrEmpty(Request.Form["customerLastName"]) ||
    string.IsNullOrEmpty(Request.Form["customerCountry"]) ||
    string.IsNullOrEmpty(Request.Form["customerCity"]) ||
    string.IsNullOrEmpty(Request.Form["customerAddress"]) ||
    string.IsNullOrEmpty(Request.Form["postalCode"]))
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
                    String sql = "INSERT INTO [dbo].[Customers] ([CompanyName], [CustomerPhone], [CustomerEmail], [CustomerFirstName], [CustomerLastName], [CustomerCountry], [CustomerCity], [CustomerAddress], [PostalCode])"
                        + " VALUES " + "(@companyName, @customerPhone, @customerEmail, @customerFirstName, @customerLastName, @customerCountry, @customerCity, @customerAddress, @postalCode);";
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

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            customersInfo.customerID = "";
            customersInfo.companyName = "";
            customersInfo.customerPhone = "";
            customersInfo.customerEmail = "";
            customersInfo.customerFirstName = "";
            customersInfo.customerLastName = "";
            customersInfo.customerCountry = "";
            customersInfo.customerCity = "";
            customersInfo.customerAddress = "";
            customersInfo.postalCode = "";
            successMessage = "New Client Was Added!";
        }

    }
}
