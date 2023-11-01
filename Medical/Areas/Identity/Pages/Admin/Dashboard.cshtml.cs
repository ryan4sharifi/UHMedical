using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Medical.Areas.Identity.Pages.Admin
{
    [Area("Identity")]
    [Authorize(Roles = "Admin")]
    public class DashboardModel : PageModel
    {
        public void OnGet()
        {
            // Logic to fetch data for the admin dashboard can go here.
            // This method is called when the page is loaded with a GET request.
        }
    }
}
