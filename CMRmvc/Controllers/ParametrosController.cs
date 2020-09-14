using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMRmvc.Data;
using CMRmvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CMRmvc.Controllers
{
    public class ParametrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private List<ParametrosTipo> _listParamTipo;

        public ParametrosController(ApplicationDbContext context)
        {
            _context = context;
            _listParamTipo = _context.ParametrosTipo.ToList();
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parametros.ToListAsync());
        }


        // GET: Parametros/Create
        public async Task<IActionResult> Create()
        {
            var list = await _context.ParametrosTipo.ToListAsync();
            ViewBag.ParamTipo = new SelectList(list, "IdParametroTipo", "IdParametroTipo");
            return View();
        }

        // POST: Parametros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdParametro,IdParametroTipo,ParClave,ParNombre,ParValor,ParTipo,ParAdmin,FecIns,FecUpd,FecDel,UsrIns,UsrUpd,UsrDel")] Parametros parametros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parametros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            

            return Crud(true, "Create", null);
        }


        // POST: Parametros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("IdParametro,IdParametroTipo,ParClave,ParNombre,ParValor,ParTipo,ParAdmin,FecIns,FecUpd,FecDel,UsrIns,UsrUpd,UsrDel")] Parametros parametros)
        {
            if (id != parametros.IdParametro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parametros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParametrosExists(parametros.IdParametro))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Crud(false, "Edit", parametros.IdParametro);
            }
            else
            {
                ViewBag.ParamTipo = new SelectList(_listParamTipo, "IdParametroTipo", "IdParametroTipo");
                ViewBag.Action = "Edit";
            }

            return View(parametros);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var parametros = await _context.Parametros.FindAsync(id);
            _context.Parametros.Remove(parametros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Crud(bool isreadonly,string myaction, long? id) 
        {
            ViewBag.ParamTipo = new SelectList(_listParamTipo, "TipNombre", "TipNombre");
            ViewBag.Action = myaction;
            ViewBag.IsReadOnly = isreadonly;


            /*
             * 
             * 
             * IList<SelectListItem> lstParametroTipoDato = Enum.GetValues(typeof(DataAccess.Common.Enums.ParameterType)).Cast<DataAccess.Common.Enums.ParameterType>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
             * 
             * */



            if (id != null && id != 0) 
            {
                return View(_context.Parametros.Find(id));
            }

            return View();
        }

        private bool ParametrosExists(long id)
        {
            return _context.Parametros.Any(e => e.IdParametro == id);
        }
    }
}
