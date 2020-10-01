using Microsoft.AspNetCore.Mvc;

namespace CMRmvc.Controllers
{
    public class ClientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Crud(bool isreadonly, string myaction, long? id)
        {
            ViewBag.IsReadOnly = isreadonly;
            ViewBag.Action = myaction;



            return View();
        }
    }
}
