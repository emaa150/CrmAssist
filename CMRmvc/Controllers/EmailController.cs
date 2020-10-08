using System;
using System.Collections.Generic;
using System.Linq;
using CMRmvc.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMRmvc.Controllers
{
    public class EmailController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private List<EmailViewModel> listEmails;
        public EmailController(ILogger<HomeController> logger) : base(logger)
        {
            _logger = logger;
            listEmails = new List<EmailViewModel>();
            LoadEmails();
        }

        private void LoadEmails()
        {
            for (int i = 0; i < 20; i++) 
            {
                EmailViewModel email = new EmailViewModel();
                email.Id = i;
                email.Destinatario = string.Format("ejemplo{0}@email.com", i);
                email.Asunto = "Asunto del mensaje " + i;
                email.Mensaje = "Cuerpo del mensaje " + i ;
                email.Fec = DateTime.Now.AddDays(-i);

                if ((i % 2) == 0)
                {
                    email.TypeCorreo = TypeCorreo.Recibido;
                    email.Etiqueta = EtiquetaCorreo.Importante;
                }
                else
                {
                    email.TypeCorreo = TypeCorreo.Enviado;
                    email.Etiqueta = EtiquetaCorreo.Promociones;
                }

            
                listEmails.Add(email);
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            StartMethod();
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError("Error: " + e.ToString());
                return NotFound();
            }
            finally
            {
                EndMethod();
            }
        }

        public ActionResult Read(long idmail) 
        {
            StartMethod();
            try
            {
                return View(listEmails.FirstOrDefault(x => x.Id == idmail));
            }
            catch (Exception e)
            {
                _logger.LogError("Error: " + e.ToString());
                return NotFound();
            }
            finally 
            {
                EndMethod();
            }

        }

        public ActionResult Inbox(TypeCorreo mytype)
        {
            StartMethod();
            try
            {
                ViewBag.TitleName = mytype;
                ViewBag.CountRecibidos = listEmails.Where(x => x.TypeCorreo == TypeCorreo.Recibido && x.FecDel == null).Count();
                ViewBag.CountEnviados = listEmails.Where(x => x.TypeCorreo == TypeCorreo.Enviado && x.FecDel == null).Count();

                var mails = listEmails.Where(x => x.TypeCorreo == mytype && x.FecDel == null);
   

                return View(mails);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.ToString());
                return NotFound();
            }
            finally 
            {
                EndMethod();
            }
        }

        [HttpPost]
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
       
    }
}
