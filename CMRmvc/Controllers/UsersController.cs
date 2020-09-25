using CMRmvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        private readonly CRMContext _context;
        private readonly ILogger<UsersController> _log;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        List<Role> misRoles = new List<Role>();
        public UsersController(CRMContext context, ILogger<UsersController> log, RoleManager<Role> roleManager, UserManager<User> userManager) : base(log)
        {
            _context = context;
            _log = log;
            _roleManager = roleManager;            
            _userManager = userManager;
            misRoles= _context.Roles.ToList();
            misRoles.Insert(0,new Role { NormalizedName = "-- SELECCIONAR --", Id = 0 });
        }

        public IActionResult Index()
        {
            StartMethod();
            try
            {                
                _log.LogInformation("Obteniendo Users...");
                var listUsers = _context.Users.Where(x => x.FecDel == null && x.UsrDel == null).ToList();
                listUsers.ForEach(x =>x.Role = _context.Roles.FirstOrDefault(r => r.Id == x.RoleID));
                _log.LogInformation(string.Format("Users count:{0}", listUsers.Count));
                return View(listUsers);
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
        public async Task<IActionResult> Create([Bind("UserName,PasswordHash,NombreCompleto,Dni,PhoneNumber,Activo,RoleID,Email,Imagen")] User user)
        {
            StartMethod();
            try
            {
                bool modelStateRol = false;
                if (user.RoleID != 0 ) modelStateRol = true;
                else{ ModelState.AddModelError("RoleID", "Debe seleccionar un perfil.");}


                if (ModelState.IsValid && modelStateRol)
                {
                    user.FecIns = DateTime.Now;
                    user.UsrIns = User.Identity.Name;
                    //user.UsrUpd = null;

                    _log.LogInformation("Creando User");

                    IdentityResult rtaCreateUser = await _userManager.CreateAsync(user, user.PasswordHash);

                    _log.LogInformation(string.Format("CreateUser:{0}", rtaCreateUser.Succeeded));

                    if (!rtaCreateUser.Succeeded)
                    {
                        _log.LogInformation("Error al insertar usuario");
                        foreach (var item in rtaCreateUser.Errors)
                        {
                            _log.LogError(string.Format("Error, Codigo:{0}, Descipcion:{1}", item.Code, item.Description));
                        }
                    }
                    else
                    {
                        _log.LogInformation("Usuario insertado con éxito: " + user.ToString());                      
                    }

                    _log.LogInformation("Redirect INDEX");

                    return RedirectToAction(nameof(Index));
                }

                _log.LogInformation("Modelo invalido");

                ViewBag.IsReadOnly = false;
                ViewBag.Action = nameof(Create);
                ViewBag.MyRoles = (IEnumerable<SelectListItem>)misRoles.Select(x => new SelectListItem { Text = x.NormalizedName, Value = x.Id.ToString() }).ToList();
                return View(nameof(Crud));
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
        public IActionResult Edit([Bind("Id,UserName,PasswordHash,NombreCompleto,Dni,PhoneNumber,Activo,RoleID,Email")] User user)
        {
            StartMethod();
            try
            {
                bool modelStateRol = false;
                if (user.RoleID != 0) modelStateRol = true;
                else { ModelState.AddModelError("RoleID", "Debe seleccionar un perfil."); }

                if (ModelState.IsValid && modelStateRol)
                {

                    _log.LogInformation("User editado: " + user.ToString());

                    _log.LogInformation("Recuperando user a editar");

                    var userDB = _context.Users.FirstOrDefault(x => x.Id == user.Id);

                    _log.LogInformation("User: " + userDB.ToString());

                    if (userDB != null)
                    {
                        userDB.UserName = user.UserName;
                        userDB.NombreCompleto = user.NombreCompleto;
                        userDB.Dni = user.Dni;
                        userDB.PhoneNumber = user.PhoneNumber;
                        userDB.Activo = user.Activo;
                        userDB.Email = user.Email;
                        userDB.FecUpd = DateTime.Now;
                        userDB.UsrUpd = User.Identity.Name;
                        _log.LogInformation("Guardando user editado: " + userDB.ToString());
                        _context.Update(userDB);
                        if (_context.SaveChanges() > 0)
                        {
                            _log.LogInformation("Edicion OK");
                            _log.LogInformation("Redirect INDEX");

                            return RedirectToAction(nameof(Index));
                        }
                        _log.LogInformation("No se pudo actualizar el user");
                    }
                    _log.LogInformation("No se pudo encontrar el user");
                    ModelState.AddModelError("", "Error al intentar actualizar el usuario.");
                }
                
                _log.LogInformation("Modelo invalido");
                ViewBag.IsReadOnly = false;
                ViewBag.Action = nameof(Edit);
                ViewBag.MyRoles = (IEnumerable<SelectListItem>)misRoles.Select(x => new SelectListItem { Text = x.NormalizedName, Value = x.Id.ToString() }).ToList();

                return View(nameof(Crud));
            }
            catch (Exception ex)
            {
                _log.LogError("Error: " + ex);
                if (!UserExists(user.Id))
                {
                    _log.LogInformation("UserExists false");
                }
                return NotFound();
            }
            finally
            {
                EndMethod();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            StartMethod();
            try
            {
                _log.LogInformation("Obteniendo user a eliminar..");
                var userDel = _context.Users.Find(id);
                _log.LogInformation("User: " + userDel.ToString());

                _log.LogInformation("Modificando fecha delete y user delete");
                userDel.FecDel = DateTime.Now;
                userDel.UsrDel = User.Identity.Name;

                _log.LogInformation("Update user eliminado");
                _context.Users.Update(userDel);
                await _context.SaveChangesAsync();

                _log.LogInformation("Redirect Index");

                return RedirectToAction(nameof(Index));
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

        private bool UserExists(long id)
        {
            try {
                return _context.Users.Any(e => e.Id == id);
            } catch
            {
                return false;
            }
        }

        public IActionResult Crud(bool isreadonly, string myaction, long? id)
        {
            StartMethod();
            User user = null;
            _log.LogInformation(string.Format("INIT CRUD: isreadonly:{0}, myaction:{1}, id:{2}", isreadonly, myaction, id));

            try
            {
                ViewBag.IsReadOnly = isreadonly;
                ViewBag.Action = myaction;

                _log.LogInformation("Obteniendo roles a mostrar");
               
                
                ViewBag.MyRoles = (IEnumerable<SelectListItem>)misRoles.Select(x => new SelectListItem { Text = x.NormalizedName, Value = x.Id.ToString() }).ToList();

                if (id != null && id != 0)
                {
                    _log.LogInformation("Obteniendo user mediante ID:" + id);
                    user = _context.Users.FirstOrDefault(x => x.Id== id);
                    _log.LogInformation("User:" + user.ToString());

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
            _log.LogInformation("Redirect CRUD VIEW");
            return View(user);
        }
        public ActionResult chooseItemView()
        {
            //    /*MessageBox.Show("Hi");*/
            //    OpenFileDialog openFileDialog = new OpenFileDialog();
            //    openFileDialog.Multiselect = false;
            //    openFileDialog.Filter = "txt files (*.txt)|*.txt| DOC files (*.doc)|*.doc";
            //    openFileDialog.ShowDialog();
            return View(nameof(Crud));
        }
        [HttpPost]
        public async Task<ActionResult> ResetPassword(long id)
        {
            StartMethod();
            try
            {
                string passnew = "assist123";
                _log.LogInformation("Obteniendo user");
                var user = _context.Users.Find(id);
                _log.LogInformation("User:" + user.ToString());
                _log.LogInformation("Hash new password");
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, passnew);
                _context.Users.Update(user);
                _log.LogInformation("Guardando Password editado");
                await _context.SaveChangesAsync();

                _log.LogInformation("Reset password OK");

                return Json(passnew);
            }
            catch (Exception ex)
            {
                _log.LogError("ResetPassword Error: " + ex);
                return Json("Ocurrió un error al resetear su contraseña.");
            }
            finally 
            {
                EndMethod();
            }
        }       
    }
}

