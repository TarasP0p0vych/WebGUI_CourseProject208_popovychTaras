using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebGUI_CourseProject208_popovychTaras.Pages.Customers;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Storage
{
    public class IndexModel : PageModel
    {
        public List<StorageInfo> storageList = new List<StorageInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=NOTEBOOKPRO;Initial Catalog=Beta;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT *  FROM [Beta].[dbo].[Storage]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                StorageInfo storageInfo = new StorageInfo();
                                storageInfo.storageID = "" + reader.GetInt32(0);
                                storageInfo.storageNumber = "" + reader.GetInt32(1);
                                storageInfo.consignmentID = "" + reader.GetInt32(2);
                                storageInfo.shelf = reader.GetString(3);
                                storageInfo.countOfSchemes = "" + reader.GetInt32(4);

                                storageList.Add(storageInfo);
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
    public class StorageInfo
    {
        public String storageID;
        public String storageNumber;
        public String consignmentID;
        public String shelf;
        public String countOfSchemes;

    }
}
