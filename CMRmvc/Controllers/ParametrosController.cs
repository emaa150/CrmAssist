using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMRmvc.Data;
using CMRmvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CMRmvc.Controllers
{
    public class ParametrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParametrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parametros
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parametros.ToListAsync());
        }

        // GET: Parametros/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametros = await _context.Parametros
                .FirstOrDefaultAsync(m => m.IdParametro == id);
            if (parametros == null)
            {
                return NotFound();
            }

            return View(parametros);
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
            return View(parametros);
        }

        // GET: Parametros/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametros = await _context.Parametros.FindAsync(id);
            if (parametros == null)
            {
                return NotFound();
            }
            return View(parametros);
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
                return RedirectToAction(nameof(Index));
            }
            return View(parametros);
        }

        // GET: Parametros/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parametros = await _context.Parametros
                .FirstOrDefaultAsync(m => m.IdParametro == id);
            if (parametros == null)
            {
                return NotFound();
            }

            return View(parametros);
        }

        // POST: Parametros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var parametros = await _context.Parametros.FindAsync(id);
            _context.Parametros.Remove(parametros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParametrosExists(long id)
        {
            return _context.Parametros.Any(e => e.IdParametro == id);
        }
    }
}
