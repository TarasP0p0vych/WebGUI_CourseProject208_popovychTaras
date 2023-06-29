using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Patents
{
    public class IndexModel : PageModel
    {
        public List<PatentsInfo> patentsList = new List<PatentsInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=NOTEBOOKPRO;Initial Catalog=Beta;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT *  FROM [Beta].[dbo].[ManufacturersPatents]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PatentsInfo patentsInfo = new PatentsInfo();
                                patentsInfo.technology = reader.GetString(0);
                                patentsInfo.year = "" + reader.GetInt16(1);
                                patentsInfo.manufacturerName = reader.GetString(2);
                                patentsInfo.note = reader.GetString(3);
                                patentsInfo.sphere = reader.GetString(4);
                                patentsInfo.manufacturerWebsite = reader.GetString(5);

                                patentsList.Add(patentsInfo);
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
    public class PatentsInfo
    {
        public String technology;
        public String year;
        public String manufacturerName;
        public String note;
        public String sphere;
        public String manufacturerWebsite;

    }
}
