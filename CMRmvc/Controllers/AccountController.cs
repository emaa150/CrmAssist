using System.Threading.Tasks;
using CMRmvc.Data;
using CMRmvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMRmvc.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AccountController> _log;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        [TempData]
        public string ErrorMessage { get; set; }
        public AccountController(ApplicationDbContext context, ILogger<AccountController> _logger, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _log = _logger;
        }

        public IActionResult Index()
        {
            return Redirect("/Views/Account/Login.cshtml");
        }

        public IActionResult Login()
        {
            return View();
        }
            [HttpPost]
        public async Task<IActionResult> Login(User user)
        {

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, 
                // set lockoutOnFailure: true

                var result = await _signInManager.PasswordSignInAsync(user.UsrLogin, user.UsrClave, user.usrRememberMe, false);
                if (result.Succeeded)
                {
                    _log.LogInformation("User logged in.");
                    Response.Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    ViewData["Error"] = "La combinación de usuario y contraseña no es válida.";
                }
            }


            return View();
        }

        public IActionResult Register()
        {
          return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User usu)
        {
            if (ModelState.IsValid)
            {
     
                var user = new IdentityUser { UserName = usu.UsrLogin };

                var result = await _userManager.CreateAsync(user, usu.UsrClave);
                if (result.Succeeded)
                {
                    _log.LogInformation("User created a new account with password.");
                    var resultLo = await _signInManager.PasswordSignInAsync(usu.UsrLogin, usu.UsrClave, false, false);
                    if (resultLo.Succeeded)
                    {
                        _log.LogInformation("User logged in.");
                        Response.Redirect("/");
                    }

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                if (User.Identity.IsAuthenticated)
                {
                   return RedirectToAction(nameof(AccountController.Index), "Home");
                }
            }
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
           await _signInManager.SignOutAsync();

            if (!User.Identity.IsAuthenticated) _log.LogInformation("User logged out ==> OK");
                else _log.LogInformation("User logged out ==> FAIL");

            return RedirectToAction(nameof(AccountController.Index), "Home");
        }
    }
}
