using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Ship
{
    public class IndexModel : PageModel
    {
        public List<ShipperInfo> shippersList = new List<ShipperInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=NOTEBOOKPRO;Initial Catalog=Beta;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT *  FROM [Beta].[dbo].[ShipData]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ShipperInfo shipperInfo = new ShipperInfo();
                                shipperInfo.shipperName = reader.GetString(0);
                                shipperInfo.expr1 = reader.GetString(1);
                                shipperInfo.quantity = "" + reader.GetInt16(2);
                                shipperInfo.expr2 = reader.GetString(3);
                                shipperInfo.shipVia = "" + reader.GetInt16(4);
                                shipperInfo.shipCity = reader.GetString(5);
                                shipperInfo.shipAddress = reader.GetString(6);
                                shipperInfo.shipCountry = reader.GetString(7);
                                shipperInfo.requiredDate = reader.GetDateTime(8).ToString();
                                shipperInfo.shippedDate = reader.GetDateTime(9).ToString();
                                shipperInfo.expr3 = reader.GetString(10);

                                shippersList.Add(shipperInfo);
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
    public class ShipperInfo
    {
        public String shipperName;
        public String expr1;
        public String quantity;
        public String expr2;
        public String shipVia;
        public String shipCity;
        public String shipAddress;
        public String shipCountry;
        public String requiredDate;
        public String shippedDate;
        public String expr3;
    }
}
