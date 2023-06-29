using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebGUI_CourseProject208_popovychTaras.Pages.Patents;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Supplyers
{
    public class IndexModel : PageModel
    {
        public List<SupplyersInfo> supplyersList = new List<SupplyersInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=NOTEBOOKPRO;Initial Catalog=Beta;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT *  FROM [Beta].[dbo].[LogisticData]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SupplyersInfo supplyersInfo = new SupplyersInfo();
                                supplyersInfo.ChipName = reader.GetString(0);
                                supplyersInfo.ConsignmentNumber = reader.GetString(1);
                                supplyersInfo.SupplyerName = reader.GetString(2);
                                supplyersInfo.SupplyDate = reader.GetDateTime(3).ToString();
                                supplyersInfo.OrderPrivateInfo = reader.GetString(4);
                                supplyersInfo.OrderInfo = reader.GetString(5);
                                supplyersInfo.PaymentInfo = reader.GetString(6);

                                supplyersList.Add(supplyersInfo);
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
    public class SupplyersInfo
    {
        public String ChipName;
        public String ConsignmentNumber;
        public String SupplyerName;
        public String SupplyDate;
        public String OrderPrivateInfo;
        public String OrderInfo;
        public String PaymentInfo;
    }
}
