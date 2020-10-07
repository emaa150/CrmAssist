﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CMRmvc.Models;
using CMRmvc.ViewModel;
using CRMmvc.Common;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMRmvc.Controllers
{
    public class DashboardController : BaseController
    {
        private readonly ILogger<DashboardController> log;
        private readonly CRMContext context;
        private Dictionary<string, dynamic> data;
        private readonly IMapper mapper;

        public DashboardController(ILogger<DashboardController> logger, CRMContext _context, IMapper _mapper) : base(logger)
        {
            log = logger;
            context = _context;
            mapper = _mapper;
        }
        public IActionResult Index()
        {
            StartMethod();
            try
            {
                log.LogInformation("Cargando datos dashboard...");
                DashboardViewModel datos = new DashboardViewModel();
                var clientes = context.Clientes.Where(x => x.FecDel == null && x.UsrDel == null).ToList();
                log.LogInformation("Total Clientes");
                datos.TotalUsuarios = clientes.Count().ToString();
                log.LogInformation("Total logueados");
                datos.TotalLogueadosHoy = context.Clientes.Where(x => x.FecUltimoLogin.Value.Date == DateTime.Today).Count().ToString();
                log.LogInformation("Total Masculinos");
                datos.TotalMasculinos = clientes.Where(x => x.Sexo == (int)Enums.Genero.MASCULINO).Count().ToString();
                log.LogInformation("Total Femenunos");
                datos.TotalFemeninos = clientes.Where(x => x.Sexo == (int)Enums.Genero.FEMENINO).Count().ToString();
                log.LogInformation("Ultimos 8 registrados");
                var climodel = clientes.Take(8).OrderBy(x => x.FecIns).ToList();
                datos.Clientes = mapper.Map<IEnumerable<ClienteViewModel>>(climodel);
                return View(datos);
            }
            catch (Exception ex)
            {
                log.LogError("Error: " + ex);
                return NotFound();
            }
            finally
            {
                EndMethod();
            }
        }

        [HttpPost]
        public IActionResult LoginClient()
        {
            StartMethod();
            try
            {
                data = new Dictionary<string, dynamic>();
                log.LogInformation("Cargando datos dashboard...");
                log.LogInformation("Cargando dias a partir de hoy...");
                List<string> days = new List<string>();
                List<int> countThisWeek = new List<int>();
                List<int> countLastWeek = new List<int>();
                var culture = new CultureInfo("es-ES");
                for (int i = 7; i > 0; i--)
                {                    
                    days.Add(culture.DateTimeFormat.GetDayName(DateTime.Now.AddDays(-i).DayOfWeek).ToUpper());
                    var day = DateTime.Now.AddDays(-i).Date;
                    countThisWeek.Add(context.Clientes.Where(x => x.FecIns.Value.Date == day).Count());
                    countLastWeek.Add(context.Clientes.Where(x => x.FecIns.Value.Date == day.AddDays(-7)).Count());
                }
                data["days"] = days;
                data["countThisWeek"] = countThisWeek;
                data["countLastWeek"] = countLastWeek;
                if (countLastWeek.Max() > countThisWeek.Max())
                { data["ejeY"] = countLastWeek.Max() * 1.20; }
                else
                { data["ejeY"] = countThisWeek.Max() * 1.20; }
                data["PorcWeek"] = (double)countLastWeek.Sum() ==0 ? 0 : Math.Round((((double)countThisWeek.Sum() / (double)countLastWeek.Sum()) - 1) * 100,1);
                return Json(data);
                    
            }
            catch (Exception ex)
            {
                log.LogError("Error: " + ex);
                return NotFound();
            }
            finally
            {
                EndMethod();
            }
        }
    }
}