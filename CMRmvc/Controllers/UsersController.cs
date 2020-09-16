using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMRmvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Identity;

namespace CMRmvc.Controllers
{
    [Authorize]
    public class UsersController : BaseController
    {
        private readonly CRMmvcContext _context;
        private readonly ILogger<UsersController> _log;
        private readonly RoleManager<Role> _roleManager;

        public UsersController(CRMmvcContext context, ILogger<UsersController> log, RoleManager<Role> roleManager) : base(log)
        {
            _context = context;
            _log = log;
            _roleManager = roleManager;
        }

        // GET: Users
        public IActionResult Index()
        {

            var listUsers = _context.Users.ToList();         

            return View(listUsers);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,IdPerfil,UsrLogin,UsrClave,UsrNombreCompleto,UsrDni,UsrTelefono,UsrImagen,UsrCorreo,UsrActivo,UsrFecUltIngreso,UsrFecClaveVcto,UsrNroLoginNok,FecIns,FecUpd,FecDel,UsrIns,UsrUpd,UsrDel")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return View("Crud");

        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdUsuario,IdPerfil,UsrLogin,UsrClave,UsrNombreCompleto,UsrDni,UsrTelefono,UsrImagen,UsrCorreo,UsrActivo,UsrFecUltIngreso,UsrFecClaveVcto,UsrNroLoginNok,FecIns,FecUpd,FecDel,UsrIns,UsrUpd,UsrDel")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
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

                if (id != null && id != 0) 
                {
                    _log.LogInformation("Obteniendo user");

                    user = _context.Users.Find(id);

                    _log.LogInformation("User: " + user.ToString());

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
            return View(user);
        }
    }
}

