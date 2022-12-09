using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssessmentNet.Pages.Owners
{
    public class CreateModel : PageModel
    {
        public OwnerInfo ownerInfo = new OwnerInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            ownerInfo.firstName = Request.Form["firstName"];
            ownerInfo.lastName = Request.Form["lastName"];
            ownerInfo.driverLicense = Request.Form["driverLicense"];

            if (ownerInfo.firstName.Length == 0 || ownerInfo.lastName.Length == 0 || ownerInfo.driverLicense.Length == 0)
            {
                errorMessage = "All the fields are requied";
                return;
            }

            // save Owner to DB

            ownerInfo.firstName = ""; ownerInfo.lastName = ""; ownerInfo.driverLicense = "";
            successMessage = "New Owner Added Correctly";
        }
    }
}
