using CMRmvc.Models;
using CMRmvc.ViewModel;
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
        public async Task<IActionResult> Create(RoleViewModel rolView)
        {
            StartMethod();
            IdentityResult result = null;
            try
            {
                if (ModelState.IsValid)
                {
                    result = await _roleManager.CreateAsync(new Role { Name = rolView.Name, ConcurrencyStamp = rolView.ConcurrencyStamp, IsActive = rolView.IsActive });
                }
                else
                {
                    ViewBag.IsReadOnly = false;
                    ViewBag.Action = nameof(Create);
                    return View(nameof(Crud), rolView);
                }

                if (result != null && result.Succeeded)
                {
                    var rolInsertado = _context.Roles.FirstOrDefault(x => x.Name == rolView.Name);
                    if (rolInsertado != null)
                    {
                        foreach (var padre in rolView.Menu)
                        {
                            foreach (var hijo in padre.MenuItemHijo)
                            {
                                //if (hijo.IsChecked) _context.PerfilMenuHijo.Add(new PerfilMenuHijo { IdRol = rolInsertado.Id, IdMenuHijo = hijo.IdMenuHijo });

                                foreach (var accion in hijo.MenuHijoAcciones)
                                {
                                    if (accion.IsChecked) _context.RolesAcciones.Add(new RolesAcciones { IdRol = rolInsertado.Id, IdMenuHijoAccion = accion.IdMenuHijoAccion });
                                }
                            }
                        }
                        _context.SaveChanges();
                    }

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(nameof(Crud), rolView);
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
        public async Task<IActionResult> Edit(RoleViewModel rolView)
        {
            StartMethod();
            IdentityResult result = null;
            Role roleDB = null;
            try
            {
           
                if (ModelState.IsValid)
                {
                    _log.LogInformation("Obteniendo ROL de DB a editar...");
                    roleDB = _context.Roles.FirstOrDefault(x => x.Id == rolView.Id);

                    if (roleDB != null)
                    {
                        _log.LogInformation("ROL obtenido: " + roleDB.Name + " IsActive: " + roleDB.IsActive);

                        roleDB.Name = rolView.Name;
                        roleDB.IsActive = rolView.IsActive;

                        _log.LogInformation("ROL editado: " + roleDB.Name + " IsActive: " + roleDB.IsActive);

                        _log.LogInformation("Actualizando datos del ROL");

                        result = await _roleManager.UpdateAsync(roleDB);

                        _log.LogInformation("UPDATE: " + result.Succeeded);
                    }
                    else 
                    {
                        ViewBag.IsReadOnly = false;
                        ViewBag.Action = nameof(Edit);
                        return View(nameof(Crud), rolView);
                    }
                }
                else
                {
                    ViewBag.IsReadOnly = false;
                    ViewBag.Action = nameof(Edit);
                    return View(nameof(Crud), rolView);
                }


                if (result != null && result.Succeeded)
                {
                    //_log.LogInformation("Eliminando ItemMenuHijos Antiguos para el rolID " + roleDB.Id);
                    //_context.PerfilMenuHijo.RemoveRange(_context.PerfilMenuHijo.Where(x => x.IdRol == roleDB.Id));
                    _log.LogInformation("Eliminando Acciones Antiguas para el rolID" + roleDB.Id);
                    _context.RolesAcciones.RemoveRange(_context.RolesAcciones.Where(x => x.IdRol == roleDB.Id));
                    _log.LogInformation("Guardando Cambios..");
                    int rtaSave = _context.SaveChanges();
                    _log.LogInformation("Cambios guardados RTA: " + rtaSave);

                    _log.LogInformation("Agregando ROL MODIFICADOS");

                    foreach (var padre in rolView.Menu)
                        {
                            foreach (var hijo in padre.MenuItemHijo)
                            {
                            //_log.LogInformation(string.Format("Item Hijo ID:{0}, Nombre: {1}, IDPadre:{2}, IsChecked: {3}", hijo.IdMenuHijo, hijo.Nombr, hijo.IdMenuPadre, hijo.IsChecked));
                            //if (hijo.IsChecked) _context.PerfilMenuHijo.Add(new PerfilMenuHijo { IdRol = roleDB.Id, IdMenuHijo = hijo.IdMenuHijo });

                                foreach (var accion in hijo.MenuHijoAcciones)
                            {
                                _log.LogInformation(string.Format("Item Accion ID:{0}, IDHijo:{1}, IsChecked: {2}", accion.IdMenuHijoAccion, accion.IdMenuHijo, accion.IsChecked));
                                if (accion.IsChecked) _context.RolesAcciones.Add(new RolesAcciones { IdRol = roleDB.Id, IdMenuHijoAccion = accion.IdMenuHijoAccion });
                                }
                            }
                        }
                     _context.SaveChanges();              

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(nameof(Crud), rolView);
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
            try
            {
                ViewBag.IsReadOnly = isreadonly;
                ViewBag.Action = myaction;

                RoleViewModel roleViewModel = RecuperarMenuItems(id);

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

                    var role = _context.Roles.Find(id);
                    roleViewModel.Id = role.Id;
                    roleViewModel.ConcurrencyStamp = role.ConcurrencyStamp;
                    roleViewModel.IsActive = role.IsActive;
                    roleViewModel.Name = role.Name;
                    roleViewModel.NormalizedName = role.NormalizedName;
                }

                return View(roleViewModel);
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
        private RoleViewModel RecuperarMenuItems(long? idRol) 
        {
            StartMethod();
            RoleViewModel roleViewModel = new RoleViewModel();
            try
            {
                _log.LogInformation("Obteniendo Roles Acciones");
                roleViewModel.RolesAcciones = _context.RolesAcciones.ToList();

                _log.LogInformation("Obteniendo Menu Completo");
                roleViewModel.Menu = _context.MenuItemPadre.Include("MenuItemHijo").Include("MenuItemHijo.MenuHijoAcciones").ToList();

                roleViewModel.Menu = VerifyChecked(roleViewModel.Menu, roleViewModel.RolesAcciones, idRol);

                _log.LogInformation("Obteniendo Perfil Menu Hijo");
                roleViewModel.PerfilMenuHijo = _context.PerfilMenuHijo.ToList();

                return roleViewModel;
            }
            catch (Exception ex)
            {
                _log.LogError("Error RecuperarMenuItems: " + ex);

                return null;
            }
            finally 
            {
                EndMethod();
            }
        }

        private List<MenuItemPadre> VerifyChecked(List<MenuItemPadre> menuPadre,List<RolesAcciones> rolesAcciones, long? rolID) 
        {
            if (rolID != null) 
            {
                    menuPadre.ForEach(mp =>
                    {
                        int countPadre = 0;
                            mp.MenuItemHijo.ForEach(mih => 
                            {
                                int countHijo = 0;
                                mih.MenuHijoAcciones.ForEach(mia => 
                                {
                                   if (!rolesAcciones.Where(ra => ra.IdMenuHijoAccion == mia.IdMenuHijoAccion).Any(y => y.IdRol == rolID)) countHijo++;
                                });
                                if (countHijo == 0) mih.IsChecked = true;
                                    else countPadre++;
                            });

                       if (countPadre == 0) mp.IsChecked = true;
                    });
            }
            return menuPadre;
        }
    }
}
