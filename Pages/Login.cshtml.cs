using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SafeVault.Services;

public class LoginModel : PageModel {
    [BindProperty]
    public string Username { get; set; }
    [BindProperty]
    public string Password { get; set; }
    public string Message { get; set; }

    public void OnPost() {
        var userService = new UserService("YourConnectionStringHere");

        if (userService.Authenticate(Username, Password)) {
            var role = userService.GetUserRole(Username);
            if (RBAC.IsAuthorized(role, "admin")) {
                Response.Redirect("/AdminDashboard");
            } else {
                Message = "Access denied: Admins only.";
            }
        } else {
            Message = "Invalid credentials.";
        }
    }
}