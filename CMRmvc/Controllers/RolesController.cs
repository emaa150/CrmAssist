using CMRmvc.Models;
using CRMmvc.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.Controllers
{
    public class RolesController : BaseController
    {
        private readonly ILogger<RolesController> _log;
        private readonly CRMContext _context;
        private readonly RoleManager<Role> _roleManager;
        public RolesController(ILogger<RolesController> log, CRMContext context, RoleManager<Role> roleManager) : base(log) 
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
                    var rolUpdate = await _roleManager.FindByIdAsync(rol.Id.ToString());
                    rolUpdate.Name = rol.Name;
                    rolUpdate.IsActive = rol.IsActive;
                    result = await _roleManager.UpdateAsync(rolUpdate);
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
                ViewBag.IdRolView = 0;
                RecuperarMenuItems();

                if (id != null && id != 0)
                {
                    ViewBag.IdRolView = id;
                    var listRoles = _context.UserRoles.Where(x => x.RoleId == id);
                    var listusers = new List<User>();

                    foreach (var item in listRoles) 
                    {
                        listusers.Add(_context.Users.Find(item.UserId));
                    }

                    ViewBag.ListUsers = listusers;

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
        private void RecuperarMenuItems() 
        {
            StartMethod();
            try
            {
                _log.LogInformation("Obteniendo Menu Completo");
                ViewBag.MenuRoles = _context.MenuItemPadre.Include("MenuItemHijo").Include("MenuItemHijo.MenuHijoAcciones").ToList();

                _log.LogInformation("Obteniendo Roles Acciones");
                ViewBag.RolesAcciones = _context.RolesAcciones.ToList();

                _log.LogInformation("Obteniendo Perfil Menu Hijo");
                ViewBag.PerfilMenuHijo = _context.PerfilMenuHijo.ToList();

            }
            catch (Exception ex)
            {
                _log.LogError("Error RecuperarMenuItems: " + ex);
            }
            finally 
            {
                EndMethod();
            }
        }
    }
}
