using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace WebGUI_CourseProject208_popovychTaras.Pages.Storage
{
    public class StorageEditModel : PageModel
    {
        public StorageInfo storageInfo = new StorageInfo();
        public String errorMessage = "";
        public String successMessage = "";

        public void OnGet()
        {
            String storageID = Request.Query["id"];
            try
            {
                String connectionString = "Data Source=NOTEBOOKPRO;Initial Catalog=Beta;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM [Beta].[dbo].[Storage] Where StorageID = @storageID";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@storageID", storageID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                storageInfo.storageID = "" + reader.GetInt32(0);
                                storageInfo.storageNumber = "" + reader.GetInt32(1);
                                storageInfo.consignmentID = "" + reader.GetInt32(2);
                                storageInfo.shelf = reader.GetString(3);
                                storageInfo.countOfSchemes = "" + reader.GetInt32(4);
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
            storageInfo.storageID = Request.Form["id"];
            storageInfo.storageNumber = Request.Form["storageNumber"];
            storageInfo.consignmentID = Request.Form["consignmentID"];
            storageInfo.shelf = Request.Form["shelf"];
            storageInfo.countOfSchemes = Request.Form["countOfSchemes"];

            if (string.IsNullOrEmpty(storageInfo.storageID) ||
    string.IsNullOrEmpty(storageInfo.storageNumber) ||
    string.IsNullOrEmpty(storageInfo.consignmentID) ||
    string.IsNullOrEmpty(storageInfo.shelf) ||
    string.IsNullOrEmpty(storageInfo.countOfSchemes))
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
                    String sql = "UPDATE [Beta].[dbo].[Storage] SET [StorageNumber] = @storageNumber, [ConsignmentID] = @consignmentID, [Shelf] = @shelf, " +
                        "[CountOfSchemes] = @countOfSchemes WHERE [StorageID] = @id;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@storageNumber", storageInfo.storageNumber);
                        command.Parameters.AddWithValue("@consignmentID", storageInfo.consignmentID);
                        command.Parameters.AddWithValue("@shelf", storageInfo.shelf);
                        command.Parameters.AddWithValue("@countOfSchemes", storageInfo.countOfSchemes);
                        command.Parameters.AddWithValue("@id", storageInfo.storageID);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch(Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/Storage/Index");

        }
    }
    }
