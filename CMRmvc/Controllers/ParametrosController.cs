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

namespace CMRmvc.Controllers
{
    [Authorize]
    public class ParametrosController : BaseController
    {
        private readonly CRMmvcContext _context;
        private readonly List<ParametrosTipo> _listParamTipo;
        private readonly ILogger<ParametrosController> _log;

        public ParametrosController(CRMmvcContext context, ILogger<ParametrosController> log) :base(log)
        {
            _context = context;
            _log = log;
            _listParamTipo = _context.ParametrosTipo.ToList();
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parametros.Where(x => x.FecDel == null && x.UsrDel == null).ToListAsync());
        }

        public async Task<IActionResult> Create()
        {
            var list = await _context.ParametrosTipo.ToListAsync();
            ViewBag.ParamTipo = new SelectList(list, "IdParametroTipo", "IdParametroTipo");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParametroTipo,ParClave,ParNombre,ParValor,ParTipo,ParAdmin")] Parametros parametros)
        {
            if (ModelState.IsValid)
            {
                var itemsParam = await _context.Parametros.OrderByDescending(x => x.IdParametro).ToListAsync();

                parametros.IdParametro = itemsParam[0].IdParametro + 1;
                parametros.FecIns = DateTime.Now;
                parametros.UsrIns = User.Identity.Name;

                _context.Add(parametros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return Crud(true, "Create", null);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("IdParametro,IdParametroTipo,ParClave,ParNombre,ParValor,ParTipo,ParAdmin,FecIns,FecUpd,FecDel,UsrIns,UsrUpd,UsrDel")] Parametros parametros)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    parametros.FecUpd = DateTime.Now;
                    parametros.UsrUpd = User.Identity.Name;
                    _context.Update(parametros);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParametrosExists(parametros.IdParametro))
                    {
                        return NotFound();
                    }
                }
            }

            return Crud(false, "Edit", parametros.IdParametro);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var parametros = await _context.Parametros.FindAsync(id);
            parametros.FecDel = DateTime.Now;
            parametros.UsrDel = User.Identity.Name;
            _context.Parametros.Update(parametros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Crud(bool isreadonly, string myaction, long? id)
        {
            StartMethod();
            Parametros param =null;
            try
            {
                _log.LogInformation("Cargando datos...");
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

        private bool ParametrosExists(long id)
        {
            return _context.Parametros.Any(e => e.IdParametro == id);
        }
    }
}
