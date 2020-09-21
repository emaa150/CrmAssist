using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using CMRmvc.Helpers;
using CMRmvc.Models;
using CRMmvc.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CMRmvc.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly CRMContext _context;
        private readonly ILogger<AccountController> _log;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly CacheHelper cacheHelper;
        [TempData]
        public string ErrorMessage { get; set; }
        public AccountController(CRMContext context, ILogger<AccountController> _logger, SignInManager<User> signInManager, UserManager<User> userManager,RoleManager<Role> roleManager, CacheHelper cache) :base(_logger)
        {            
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _log = _logger;
            cacheHelper= cache;
        }

        public IActionResult Index()
        {
            return View(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login([Bind("UserName,PasswordHash,RememberMe")] User user)
        {
            StartMethod();
            try
            {
                ModelState.Remove("Email");
                ModelState.Remove("PhoneNumber");
                ModelState.Remove("NombreCompleto");
                ModelState.Remove("Dni");
            
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, user.PasswordHash, user.RememberMe, false);
                    if (result.Succeeded)
                    {
                        _log.LogInformation("User logged in.");
                        _log.LogInformation("User logged in.");
                        HttpContext.Session.SetString("UserName", user.UserName);
                        var menu = MenuHelper.GenerateMenu(user.UserName, _log, _context);
                        cacheHelper.LoadMenu(menu);

                        // string jsonMenu = JsonConvert.SerializeObject(menu, Formatting.Indented,
                        // new JsonSerializerSettings
                        // {
                        //     PreserveReferencesHandling = PreserveReferencesHandling.Objects
                        // });

                        //HttpContext.Session.SetString("Menu", jsonMenu);                   

                        ViewData["Menu"] = menu;

                        return RedirectToAction(nameof(AccountController.Index), "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        ViewData["Error"] = "La combinación de usuario y contraseña no es válida.";
                    }
                }
                else
                {
                    return View(user);
                }
            }
            catch (Exception ex)
            {
                ViewData["Error"] = "Ocurrió un error al iniciar sesión.";
                _log.LogError("Error: " + ex);
            }
            finally 
            {
                EndMethod();
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
            try
            { 
            
                StartMethod();
                _log.LogInformation("Validando ModelState...");
                if (ModelState.IsValid)
                {

                    var user = new User { UserName = usu.UserName };

                    var result = await _userManager.CreateAsync(user, usu.PasswordHash);
                    if (result.Succeeded)
                    {
                        _log.LogInformation("User created a new account with password.");
                        var resultLo = await _signInManager.PasswordSignInAsync(usu.UserName, usu.PasswordHash, false, false);
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
            }
            catch (Exception ex)
            { _log.LogError("Error: " + ex); }

            EndMethod();
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
