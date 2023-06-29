using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Orders
{
    public class IndexModel : PageModel
    {
        public List<OrdersInfo> ordersList = new List<OrdersInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=NOTEBOOKPRO;Initial Catalog=Beta;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT *  FROM [Beta].[dbo].[ExtendedOrderInfo]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OrdersInfo ordersInfo = new OrdersInfo();
                                ordersInfo.orderID = "" + reader.GetInt32(0);
                                ordersInfo.microschemesID = "" +  reader.GetInt32(1);
                                ordersInfo.chipName = reader.GetString(2);
                                ordersInfo.cost = reader.GetDecimal(3).ToString();
                                ordersInfo.quantity = "" + reader.GetInt16(4);
                                ordersInfo.discountPercentage = reader.GetFloat(5).ToString();
                                ordersInfo.extendedPrice = reader.GetDecimal(6).ToString();



                                ordersList.Add(ordersInfo);
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
    public class OrdersInfo
    {
        public String orderID;
        public String microschemesID;
        public String chipName;
        public String cost;
        public String quantity;
        public String discountPercentage;
        public String extendedPrice;

    }
}