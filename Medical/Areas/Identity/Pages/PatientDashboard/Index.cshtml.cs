using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

[Authorize(Roles = "Patient")]
public class PatientDashboardModel : PageModel
{
    public void OnGet()
    {
        // Logic to fetch data for the patient dashboard can go here
    }
}
