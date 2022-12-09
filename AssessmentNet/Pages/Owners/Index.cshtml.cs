using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace AssessmentNet.Pages.Owners
{
    public class IndexModel : PageModel
    {
        public List<OwnerInfo> listOwners = new List<OwnerInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=mycars;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM owners";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OwnerInfo ownerInfo = new OwnerInfo();
                                ownerInfo.id = "" + reader.GetInt32(0);
                                ownerInfo.firstName = reader.GetString(1);
                                ownerInfo.lastName = reader.GetString(2);
                                ownerInfo.driverLicense = reader.GetString(3);
                                ownerInfo.created_at = reader.GetDateTime(4).ToString();

                                listOwners.Add(ownerInfo);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class OwnerInfo
    {
        public String id;
        public String firstName;
        public String lastName;
        public String driverLicense;
        public String created_at;
    }
}
