using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Customers
{
    public class IndexModel : PageModel
    {
        public List<CustomersInfo> customersList = new List<CustomersInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=NOTEBOOKPRO;Initial Catalog=Beta;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT *  FROM [Beta].[dbo].[Customers]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomersInfo customersInfo = new CustomersInfo();
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



                                customersList.Add(customersInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exeption" + ex.ToString());
            }
        }
    }
    public class CustomersInfo
    {
        public String customerID;
        public String companyName;
        public String customerPhone;
        public String customerEmail;
        public String customerFirstName;
        public String customerLastName;
        public String customerCountry;
        public String customerCity;
        public String customerAddress;
        public String postalCode;
    }
}

