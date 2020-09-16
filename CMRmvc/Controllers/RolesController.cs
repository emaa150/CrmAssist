using CMRmvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
            StartMethod();
            try
            {
               return View(_roleManager.Roles);
            }
            catch (Exception ex)
            {
                _log.LogError("Error: " + ex);
                return NotFound();
            }
            finally 
            {
                EndMethod();
            }
          
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsActive")] Role rol)
        {
            StartMethod();
            IdentityResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    result = await _roleManager.CreateAsync(rol);
                }
                else
                {
                    return View(nameof(Crud));
                }

                if (result != null && result.Succeeded) return RedirectToAction(nameof(Index));
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(nameof(Crud));
                }
            }
            catch (Exception ex)
            {
                _log.LogError("Error: " + ex);
                return NotFound();
            }
            finally
            {
                EndMethod();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,ConcurrencyStamp,IsActive")] Role rol)
        {
            StartMethod();
            IdentityResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    result = await _roleManager.UpdateAsync(rol);
                }
                else
                {
                    return View(nameof(Crud));
                }

                if (result != null && result.Succeeded) return RedirectToAction(nameof(Index));
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(nameof(Crud));
                }
            }
            catch (Exception ex)
            {
                _log.LogError("Error: " + ex);
                return NotFound();
            }
            finally
            {
                EndMethod();
            }
        }

        public IActionResult Crud(bool isreadonly, string myaction, long? id)
        {
            StartMethod();
            Role role = null;
            try
            {
                ViewBag.IsReadOnly = isreadonly;
                ViewBag.Action = myaction;

                if (id != null && id != 0)
                {
                    _log.LogInformation("Obteniendo Role");

                    role = _context.Roles.Find(id);

                }

                return View(role);
            }
            catch (Exception ex)
            {
                _log.LogError("Error: " + ex);
                return NotFound();
            }
            finally
            {
                EndMethod();
            }
        }
    }
}
