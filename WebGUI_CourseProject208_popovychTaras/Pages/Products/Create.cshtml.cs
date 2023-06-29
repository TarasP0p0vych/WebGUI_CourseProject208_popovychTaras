using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebGUI_CourseProject208_popovychTaras.Pages.Clients;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Products
{
    public class CreateModel : PageModel
    {
        public MicrochipsInfo microchipsInfo = new MicrochipsInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            microchipsInfo.chipName = Request.Form["chipName"];
            microchipsInfo.subtypeName = Request.Form["subtypeName"];
            microchipsInfo.manufacturerName = Request.Form["manufacturerName"];
            microchipsInfo.voltage = Request.Form["voltage"];
            microchipsInfo.pinConfig = Request.Form["pinConfig"];
            microchipsInfo.capacity = Request.Form["capacity"];
            microchipsInfo.capacityType = Request.Form["capacityType"];
            microchipsInfo.accessTime = Request.Form["accessTime"];
            microchipsInfo.nanometers = Request.Form["nanometers"];
            microchipsInfo.writeInfo = Request.Form["writeInfo"];
            microchipsInfo.readInfo = Request.Form["readInfo"];
            microchipsInfo.baseSpeed = Request.Form["baseSpeed"];
            microchipsInfo.releaseDate = Request.Form["releaseDate"];
            microchipsInfo.manufacturerWeb = Request.Form["manufacturerWeb"];
            microchipsInfo.userRating = Request.Form["userRating"];

            if (microchipsInfo.chipName.Length == 0 || microchipsInfo.subtypeName.Length == 0 ||
microchipsInfo.manufacturerName.Length == 0 || microchipsInfo.voltage.Length == 0 ||
microchipsInfo.pinConfig.Length == 0 || microchipsInfo.capacity.Length == 0 ||
microchipsInfo.capacityType.Length == 0 || microchipsInfo.accessTime.Length == 0 ||
microchipsInfo.nanometers.Length == 0 || microchipsInfo.writeInfo.Length == 0 ||
microchipsInfo.readInfo.Length == 0 || microchipsInfo.baseSpeed.Length == 0 ||
microchipsInfo.releaseDate.Length == 0 || microchipsInfo.manufacturerWeb.Length == 0 ||
microchipsInfo.userRating.Length == 0)
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
                    String sql = "INSERT INTO [dbo].[Microschemes] " + "([TypeID], [ChipName], [Capacity], [CapacityType], [ReleaseDate], [AccessTime], [Nanometers], [isWidelyUsed], [WriteInfo], [ReadInfo], [Note])"
                        + " VALUES " + "(@subtypeName, @chipName, @capacity, @capacityType, @releaseDate, @accessTime, @nanometers, 1, @writeInfo, @readInfo, @subtypeName);" +
                        "INSERT INTO [dbo].[ManufacturersAndMicroschemes] " + "([ManufacturerID] ,[MicroshemeID] ,[ModelDescription] ,[Usage] , [UserRating])" + " VALUES " +
                        "(@manufacturerName, 94, 'New in store chip!', 'Computer Technic', @userRating)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@subtypeName", microchipsInfo.subtypeName);
                        command.Parameters.AddWithValue("@chipName", microchipsInfo.chipName);
                        command.Parameters.AddWithValue("@capacity", microchipsInfo.capacity);
                        command.Parameters.AddWithValue("@capacityType", microchipsInfo.capacityType);
                        command.Parameters.AddWithValue("@releaseDate", microchipsInfo.releaseDate);
                        command.Parameters.AddWithValue("@accessTime", microchipsInfo.accessTime);
                        command.Parameters.AddWithValue("@nanometers", microchipsInfo.nanometers);
                        command.Parameters.AddWithValue("@writeInfo", microchipsInfo.writeInfo);
                        command.Parameters.AddWithValue("@readInfo", microchipsInfo.readInfo);
                        command.Parameters.AddWithValue("@manufacturerName", microchipsInfo.manufacturerName);
                        command.Parameters.AddWithValue("@userRating", microchipsInfo.userRating);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }


            microchipsInfo.chipName = "";
            microchipsInfo.subtypeName = "";
            microchipsInfo.manufacturerName = "";
            microchipsInfo.voltage = "";
            microchipsInfo.pinConfig = "";
            microchipsInfo.capacity = "";
            microchipsInfo.capacityType = "";
            microchipsInfo.accessTime = "";
            microchipsInfo.nanometers = "";
            microchipsInfo.writeInfo = "";
            microchipsInfo.readInfo = "";
            microchipsInfo.baseSpeed = "";
            microchipsInfo.releaseDate = "";
            microchipsInfo.manufacturerWeb = "";
            microchipsInfo.userRating = "";
            successMessage = "New microsheme added successfuly!";
            Response.Redirect("/Products/Index");
        }
    }
}
