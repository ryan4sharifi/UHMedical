using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Medical.Models;
using Medical.Data;

public class AdminRegisterModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly team12Context _team12Context;

    public AdminRegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, team12Context team12Context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _team12Context = team12Context;
    }

    [BindProperty]
    public Admin Admin { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = Admin.Email, Email = Admin.Email };
            var result = await _userManager.CreateAsync(user, Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");

                // Save the Admin details in your Database
                _team12Context.Add(Admin);
                await _team12Context.SaveChangesAsync();

                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToPage("/Admin/Dashboard", new { area = "Identity" });



            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return Page();
    }
}

