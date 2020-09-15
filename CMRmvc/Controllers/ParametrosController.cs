﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMRmvc.Data;
using CMRmvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using CRMmvc.Common;
using Microsoft.Extensions.Logging;

namespace CMRmvc.Controllers
{
    public class ParametrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly List<ParametrosTipo> _listParamTipo;
        private readonly ILogger<ParametrosController> _log;

        public ParametrosController(ApplicationDbContext context, ILogger<ParametrosController> log)
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

        public IActionResult Crud(bool isreadonly,string myaction, long? id) 
        {
            ViewBag.ParamTipo = new SelectList(_listParamTipo, "IdParametroTipo", "TipNombre");
            ViewBag.Action = myaction;
            ViewBag.IsReadOnly = isreadonly;


            IList<SelectListItem> lstParametroTipoDato = Enum.GetValues(typeof(Enums.ParameterType)).Cast<Enums.ParameterType>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
            ViewBag.ParameterType = lstParametroTipoDato;


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
