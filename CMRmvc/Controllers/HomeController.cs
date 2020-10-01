using CMRmvc.Models;
using CMRmvc.ViewModel;
using CRMmvc.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace CMRmvc.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<User> _signInManager;
        private readonly CRMContext context;
        public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager, CRMContext _context):base(logger)
        {
            _logger = logger;
            _signInManager = signInManager;
            context = _context;
        }

        public IActionResult Index()
        {
            StartMethod();
          
            return View();

        }

        public IActionResult Privacy()
        {
            StartMethod();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            StartMethod();
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
