using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMRmvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using CRMmvc.Common;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using CRMmvc.Helpers;

namespace CMRmvc.Controllers
{
    [Authorize]
    public class ParametrosController : BaseController
    {
        private readonly CRMContext _context;
        private readonly List<ParametrosTipo> _listParamTipo;
        private readonly ILogger<ParametrosController> _log;
        private readonly CacheHelper cacheHelper;
        public ParametrosController(CRMContext context, ILogger<ParametrosController> log, CacheHelper cache) :base(log)
        {
            _context = context;
            _log = log;
            _listParamTipo = _context.ParametrosTipo.ToList();
            cacheHelper = cache;
            ViewData["Menu"] = cacheHelper.GetMenu();
        }

        public async Task<IActionResult> Index(string sortOrder)
        {
            StartMethod();
            try
            {
                var menu = cacheHelper.GetMenu();
                ViewData["Menu"] = menu;
                
                IList<SelectListItem> lstParametroTipoDato  = Enum.GetValues(typeof(Enums.ParameterType)).Cast<Enums.ParameterType>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
                ViewData["ParamType"] = lstParametroTipoDato.ToList();
                var param = await _context.Parametros.Include("IdParametroTipoNavigation").Where(x => x.FecDel == null && x.UsrDel == null).ToListAsync();

                ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewData["ClaveSortParm"] = sortOrder == "clave_asc" ? "clave_asc" : "clave_desc";
                ViewData["ValueSortParm"] = sortOrder == "value_asc" ? "value_asc" : "value_desc";
                
                switch (sortOrder)
                {
                    case "name_desc":
                        param = param.OrderByDescending(s => s.ParNombre).ToList();
                        break;
                    case "clave_asc":
                        param = param.OrderBy(s => s.ParClave).ToList();
                        break;
                    case "clave_desc":
                        param = param.OrderByDescending(s => s.ParClave).ToList();
                        break;
                    case "value_desc":
                        param = param.OrderByDescending(s => s.ParValor).ToList();
                        break;
                    case "value_asc":
                        param = param.OrderBy(s => s.ParValor).ToList();
                        break;
                    default:
                        param = param.OrderBy(s => s.ParNombre).ToList();
                        break;
                }

                return View(param.ToList());
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
        public async Task<IActionResult> Create([Bind("IdParametroTipo,ParClave,ParNombre,ParValor,ParTipo,ParAdmin")] Parametros parametros)
        {
            StartMethod();
            try
            {
                if (ModelState.IsValid)
                {
                    parametros.FecIns = DateTime.Now;
                    parametros.UsrIns = User.Identity.Name;

                    _context.Add(parametros);

                    await _context.SaveChangesAsync(); 
                    return RedirectToAction(nameof(Index));
                }
                else 
                {
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
        public async Task<IActionResult> Edit([Bind("IdParametro,IdParametroTipo,ParClave,ParNombre,ParValor,ParTipo,ParAdmin,FecIns,FecUpd,FecDel,UsrIns,UsrUpd,UsrDel")] Parametros parametros)
        {
            StartMethod();
            try
            {
                if (ModelState.IsValid)
                {
                    parametros.FecUpd = DateTime.Now;
                    parametros.UsrUpd = User.Identity.Name;
                    _context.Update(parametros);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));                
                }
                else 
                {
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
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            StartMethod();
            try
            {
                var parametros = await _context.Parametros.FindAsync(id);

                parametros.FecDel = DateTime.Now;
                parametros.UsrDel = User.Identity.Name;

                _context.Parametros.Update(parametros);

                await _context.SaveChangesAsync();

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

        public IActionResult Crud(bool isreadonly, string myaction, long? id)
        {
            StartMethod();
            Parametros param =null;
            try
            {
                _log.LogInformation("Cargando datos...");
                ViewData["Menu"] = cacheHelper.GetMenu();
                ViewBag.ParamTipo = new SelectList(_listParamTipo, "IdParametroTipo", "TipNombre");
                ViewBag.Action = myaction;
                ViewBag.IsReadOnly = isreadonly;
                _log.LogInformation("Cargando lista de tipo de dato de param");
                IList<SelectListItem> lstParametroTipoDato = Enum.GetValues(typeof(Enums.ParameterType)).Cast<Enums.ParameterType>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
                ViewBag.ParameterType = lstParametroTipoDato;
                _log.LogInformation("Verificando id a inicializar");
                if (id != null && id != 0)
                {
                    _log.LogInformation("Inicializando parametro id: "+id);
                    param =_context.Parametros.Find(id);
                }
            }
            catch (Exception ex)
            {
                _log.LogError("Error: "+ ex);
                return NotFound();
            }
            finally
            {
                EndMethod();                
            }
            return View(param);
        }
    }
}
