using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Manufacturers
{
    public class IndexModel : PageModel
    {
		public List<ManufacturerInfo> manufacturerList = new List<ManufacturerInfo>();
		public void OnGet()
        {
         try
            {
                String connectionString = "Data Source=NOTEBOOKPRO;Initial Catalog=Beta;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT *  FROM [Beta].[dbo].[Manufacturer]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
							while (reader.Read())
							{
								ManufacturerInfo manufacturerInfo = new ManufacturerInfo();
								manufacturerInfo.manufacturerID ="" + reader.GetInt32(0);
								manufacturerInfo.countryID = "" + reader.GetInt32(1);
								manufacturerInfo.manufacturerName = reader.GetString(2);
								manufacturerInfo.manufacturerRegion = reader.GetString(3);
								manufacturerInfo.manufacturerAddress = reader.GetString(4);
								manufacturerInfo.contactPersonFirstName = reader.GetString(5);
								manufacturerInfo.contactPersonSecondName = reader.GetString(6);
								manufacturerInfo.phoneNumber = reader.GetString(7);
								manufacturerInfo.fax = reader.GetString(8);
								manufacturerInfo.manufacturerEmail = reader.GetString(9);
								manufacturerInfo.manufacturerWebsite = reader.GetString(10);
								manufacturerInfo.productLine = reader.GetString(11);
								manufacturerInfo.establishDate = "" + reader.GetInt16(12);
								manufacturerInfo.description = reader.GetString(13);

								manufacturerList.Add(manufacturerInfo);
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
    public class ManufacturerInfo
	{
		public String manufacturerID;
		public String countryID;
		public String manufacturerName;
		public String manufacturerRegion;
		public String manufacturerAddress;
		public String contactPersonFirstName;
		public String contactPersonSecondName;
		public String phoneNumber;
		public String fax;
		public String manufacturerEmail;
		public String manufacturerWebsite;
		public String productLine;
		public String establishDate;
		public String description;

	}
}

