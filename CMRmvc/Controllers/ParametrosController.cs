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
using System.ComponentModel.Design;
using System.Runtime.InteropServices.ComTypes;

namespace CMRmvc.Controllers
{
    [Authorize]
    public class ParametrosController : BaseController
    {
        private readonly CRMContext _context;
        private readonly List<ParametrosTipo> _listParamTipo;
        private readonly ILogger<ParametrosController> _log;
        IList<SelectListItem> lstParametroTipoDato;
        public ParametrosController(CRMContext context, ILogger<ParametrosController> log) :base(log)
        {
            _context = context;
            _log = log;
            _listParamTipo = _context.ParametrosTipo.ToList();
            //_listParamTipo.Insert(0, new ParametrosTipo { IdParametroTipo=0, TipNombre= "-- SELECCIONAR --" });
            lstParametroTipoDato = Enum.GetValues(typeof(Enums.ParameterType)).Cast<Enums.ParameterType>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
            //lstParametroTipoDato.Insert(0, new SelectListItem { Value="0",Text= "-- SELECCIONAR --" });

        }

        public IActionResult Index()
        {
            StartMethod();
            try
            {
                _log.LogInformation("Cargando parametros...");
                List<Parametros> param = _context.Parametros.Include("IdParametroTipoNavigation")
                        .Where(x => x.FecDel == null && x.UsrDel == null).ToList();;
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
        public IActionResult Create([Bind("IdParametroTipo,ParClave,ParNombre,ParValor,ParTipo,ParAdmin")] Parametros parametros)
        {
            StartMethod();
            try
            {
                bool modelStateRol = false;
                if (parametros.IdParametroTipo != 0) modelStateRol = true;
                else { ModelState.AddModelError("IdParametroTipo", "Debe seleccionar un tipo de parametro."); }
                if (parametros.ParTipo != 0) modelStateRol = true;
                else { ModelState.AddModelError("ParTipo", "Debe seleccionar un tipo dato."); }

                _log.LogInformation("Validando ModelState");
                if (ModelState.IsValid)
                {
                    _log.LogInformation("Creando parametro: "+parametros.ParClave);
                    parametros.FecIns = DateTime.Now;
                    parametros.UsrIns = User.Identity.Name;

                    _context.Add(parametros);
                    _log.LogInformation("Guardando en db...");
                    if (_context.SaveChanges() > 0)
                    { _log.LogInformation("GUARDADO: "+ parametros.ParClave); }
                    else
                    {
                        _log.LogWarning("Error al guardar en db.");
                    }
                    return RedirectToAction(nameof(Index));
                }
                else 
                {
                    _log.LogInformation("Modelo no valido");
                    ViewBag.IsReadOnly = false;
                    ViewBag.Action = nameof(Create);
                    ViewBag.ParamTipo = new SelectList(_listParamTipo, "IdParametroTipo", "TipNombre");
                    ViewBag.ParameterType = lstParametroTipoDato;// Enum.GetValues(typeof(Enums.ParameterType)).Cast<Enums.ParameterType>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList(); ;
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
        public  IActionResult Edit([Bind("IdParametro,IdParametroTipo,ParClave,ParNombre,ParValor,ParTipo,ParAdmin")] Parametros parametros)
        {
            StartMethod();
            try
            {
                _log.LogInformation("Validando ModelState");

                if (ModelState.IsValid)
                {
                    var param = _context.Parametros.FirstOrDefault(x => x.IdParametro==parametros.IdParametro);
                    if (param != null)
                    {
                        param.IdParametroTipo = parametros.IdParametroTipo;
                        param.ParNombre = parametros.ParNombre;
                        param.ParClave = parametros.ParClave;
                        param.ParValor = parametros.ParValor;
                        param.ParAdmin = parametros.ParAdmin;
                        param.ParTipo = parametros.ParTipo;
                        param.FecUpd = DateTime.Now;
                        param.UsrUpd = User.Identity.Name;
                        _context.Update(param);
                        if (_context.SaveChanges() > 0)
                        { _log.LogInformation("GUARDADO: " + param.ParClave); }
                        else
                        {
                            _log.LogWarning("Error al guardar en db.");
                        }
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "Error al modificar el parametro.");
                    return View(nameof(Crud));

                }
                else 
                {

                    _log.LogInformation("Modelo invalido");
                    ModelState.AddModelError("", "Error al intentar actualizar el parametro.");
                    ViewBag.IsReadOnly = false;
                    ViewBag.Action = nameof(Edit);
                    ViewBag.ParamTipo = new SelectList(_listParamTipo, "IdParametroTipo", "TipNombre");
                    ViewBag.ParameterType = lstParametroTipoDato;

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
        public IActionResult DeleteConfirmed(long id)
        {
            StartMethod();
            try
            {
                _log.LogInformation("Recuperando parametro ID : "+id);
                var parametros = _context.Parametros.FirstOrDefault(x => x.IdParametro == id);
                if (parametros != null)
                {
                    parametros.FecDel = DateTime.Now;
                    parametros.UsrDel = User.Identity.Name;
                    _log.LogInformation("guardado en db...");
                    _context.Parametros.Update(parametros);

                    if (_context.SaveChanges() > 0)
                    { _log.LogInformation("GUARDADO: " + parametros.ParClave); }
                    else
                    {
                        _log.LogWarning("Error al guardar en db.");
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Error al modificar el parametro.");
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
            Parametros param =null;
            try
            {
                _log.LogInformation(string.Format("INIT CRUD: isreadonly:{0}, myaction:{1}, id:{2}", isreadonly, myaction, id));

                _log.LogInformation("Cargando datos...");
                ViewBag.ParamTipo = new SelectList(_listParamTipo, "IdParametroTipo", "TipNombre");
                IList<SelectListItem> lstParametroTipoDato = Enum.GetValues(typeof(Enums.ParameterType)).Cast<Enums.ParameterType>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();

                ViewBag.Action = myaction;
                ViewBag.IsReadOnly = isreadonly;
                _log.LogInformation("Cargando lista de tipo de dato de param");
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
