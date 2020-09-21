using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CMRmvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using CRMmvc.Helpers;
using CMRmvc.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CMRmvc.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly CRMContext context;
        private readonly CacheHelper cacheHelper;
        public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager, CRMContext _context, CacheHelper _cacheHelper):base(logger)
        {
            _logger = logger;
            _signInManager = signInManager;
            context = _context;
            cacheHelper = _cacheHelper;

           // ViewData["Menu"] = JsonConvert.DeserializeObject<List<MenuItemPadre>>(httpContext.Session.GetString("Menu"));

            ViewData["Menu"] = cacheHelper.GetMenu();
        }

        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString("UserName");
            ViewData["Menu"] = cacheHelper.GetMenu();
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
