using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CMRmvc.Models;
using CMRmvc.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMRmvc.Controllers
{
    public class EmailController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CRMContext _context;
        private readonly IMapper _mapper;
        private List<EmailViewModel> listEmails;
        public EmailController(ILogger<HomeController> logger, CRMContext context, IMapper mapper) : base(logger)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            LoadEmails();
        }

        private void LoadEmails()
        {
            listEmails = new List<EmailViewModel>();
            EmailViewModel email1 = new EmailViewModel();
            email1.Destinatario = "destino@mail.com";
            email1.Asunto = "Prueba";
            email1.Mensaje = "MENSAJEEEEEEEE";
            email1.TypeCorreo = TypeCorreo.Recibido;
            email1.Etiqueta = EtiquetaCorreo.Ninguna;
            email1.Fec = DateTime.Today;
            listEmails.Add(email1);
        }

        // GET: EmailController
        public ActionResult Index()
        {
            return View();
        }

        // GET: EmailController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmailController/Create
        public ActionResult Create()
        {
            StartMethod();
            return View();
        }

        public ActionResult Inbox()
        {
            StartMethod();
            return View();
        }

        // POST: EmailController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        // GET: EmailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
