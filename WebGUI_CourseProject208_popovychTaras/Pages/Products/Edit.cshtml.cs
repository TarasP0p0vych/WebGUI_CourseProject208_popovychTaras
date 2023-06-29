using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using WebGUI_CourseProject208_popovychTaras.Pages.Clients;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Products
{
    public class EditModel : PageModel
    {
        public MicrochipsInfo microchipsInfo = new MicrochipsInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
            String microschemeID = Request.Query["microschemeID"];
            try
            {
                String connectionString = "Data Source=NOTEBOOKPRO;Initial Catalog=Beta;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT *  FROM [Beta].[dbo].[AllProductInformation] Where MicroschemesID = @microschemeID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@microschemesID", microschemeID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
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

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
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
                    String sql = "UPDATE [dbo].[Microschemes]" + "SET [TypeID] = @subtypeName, [ChipName] = @chipName, [Capacity] = @capacity, [CapacityType] = @capacityType, [ReleaseDate] = @releaseDate, [AccessTime] = @accessTime, [Nanometers] = @nanometers, [isWidelyUsed] = 1, [WriteInfo] = @writeInfo, [ReadInfo] = @readInfo, [Note] = @subtypeName " + "WHERE [MicroshemesID] = 94;"
                    + "UPDATE [dbo].[ManufacturersAndMicroschemes]" + "SET" + "[ManufacturerID] = @manufacturerName, [ModelDescription] = 'New in store chip!', [Usage] = 'Computer Technic', [UserRating] = @userRating " + "WHERE [MicroshemesID] = microschemeID;";

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
             errorMessage += ex.Message;
                return;
            }
            
        }
    }
}
