using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<MicrochipsInfo> listChips = new List<MicrochipsInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=NOTEBOOKPRO;Initial Catalog=Beta;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT *  FROM [Beta].[dbo].[AllProductInformation]";
                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MicrochipsInfo microchipsInfo = new MicrochipsInfo();
                                microchipsInfo.microschemeID = "" + reader.GetInt32(0);
                                microchipsInfo.chipName = reader.GetString(1);
                                microchipsInfo.subtypeName = reader.GetString(2);
                                microchipsInfo.manufacturerName = reader.GetString(3);
                                microchipsInfo.voltage = "" + reader.GetByte(4);
                                microchipsInfo.pinConfig = reader.GetString(5);
                                microchipsInfo.capacity = "" + reader.GetInt16(6);
                                microchipsInfo.capacityType = reader.GetString(7);
                                microchipsInfo.accessTime = "" + reader.GetInt16(8);
                                microchipsInfo.nanometers = "" + reader.GetInt16(9);
                                microchipsInfo.writeInfo = "" + reader.GetInt16(10);
                                microchipsInfo.readInfo = "" + reader.GetInt16(11);
                                microchipsInfo.baseSpeed = reader.GetString(12);
                                microchipsInfo.releaseDate = "" + reader.GetInt16(13);
                                microchipsInfo.manufacturerWeb = reader.GetString(14);
                                microchipsInfo.userRating = "" + reader.GetByte(15);

                                listChips.Add(microchipsInfo);
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
    public class MicrochipsInfo
    {
        public String microschemeID;
        public String chipName;
        public String subtypeName;
        public String manufacturerName;
        public String voltage;
        public String pinConfig;
        public String capacity;
        public String capacityType;
        public String accessTime;
        public String nanometers;
        public String writeInfo;
        public String readInfo;
        public String baseSpeed;
        public String releaseDate;
        public String manufacturerWeb;
        public String userRating;
    }
}
