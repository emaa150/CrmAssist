using CMRmvc.Models;
using CRMmvc.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

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
                _log.LogInformation("Validando que se selecciono un tipo de parametro y el dato del param.");
                bool modelStateRol = false;
                bool modelStateType = false;
                if (parametros.IdParametroTipo != 0) modelStateRol = true;
                else { ModelState.AddModelError("IdParametroTipo", "Debe seleccionar un tipo de parametro."); }
                if (parametros.ParTipo != 0) modelStateRol = true;
                else { ModelState.AddModelError("ParTipo", "Debe seleccionar un tipo dato."); }
                _log.LogInformation("Validando clave");
                if (_context.Parametros.FirstOrDefault(x => x.ParClave == parametros.ParClave) == null) modelStateRol = true;
                else { ModelState.AddModelError("ParClave", "La clave ingresada ya se encuentra en el sistema."); }
                _log.LogInformation("Validanto tipo de valor");
                int a;
                DateTime b;
                if (parametros.ParTipo == (int)Enums.ParameterType.INT && !int.TryParse(parametros.ParValor, out a))
                { ModelState.AddModelError("ParValor", "El valor ingresado no coincide con el tipo de dato cargado."); }
                else if (parametros.ParTipo == (int)Enums.ParameterType.DATE && !DateTime.TryParse(parametros.ParValor, out b))
                { ModelState.AddModelError("ParValor", "El valor ingresado no coincide con el tipo de dato cargado."); }
                else modelStateType = true;

                _log.LogInformation("Validando ModelState");
                if (ModelState.IsValid && modelStateRol && modelStateType)
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
