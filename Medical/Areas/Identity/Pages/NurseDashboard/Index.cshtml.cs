using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

[Authorize(Roles = "Nurse")]
public class NurseDashboardModel : PageModel
{
    public void OnGet()
    {
        // Logic to fetch data for the nurse dashboard can go here
    }
}
