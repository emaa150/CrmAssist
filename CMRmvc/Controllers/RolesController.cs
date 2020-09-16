using CMRmvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CMRmvc.Controllers
{
    public class RolesController : BaseController
    {
        private readonly ILogger<RolesController> _log;
        private readonly CRMmvcContext _context;
        private readonly RoleManager<Role> _roleManager;

        public RolesController(ILogger<RolesController> log, CRMmvcContext context, RoleManager<Role> roleManager) : base(log) 
        {
            _log = log;
            _context = context;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {       
            return View(_context.Roles.AsAsyncEnumerable());
        }

        public async Task<IActionResult> Create([Bind("Id,Name,IsActive")] Role rol)
        {
            IdentityResult result = null;
            if (ModelState.IsValid)
            {
                result = await _roleManager.CreateAsync(rol);
            }
            else 
            {
                return Crud(false, "Create", null);
            }
           


            return RedirectToAction(nameof(Index));
        }


        public IActionResult Crud(bool isreadonly, string myaction, long? id)
        {
            ViewBag.IsReadOnly = isreadonly;
            ViewBag.Action = myaction;

            IdentityRole<long> role=null;

            if (id != null && id != 0)
            {
                _log.LogInformation("Obteniendo user");

                role = _context.Roles.Find(id);

            }

            return View(role);
        }
    }
}
