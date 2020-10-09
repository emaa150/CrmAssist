using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CMRmvc.Helpers;
using CMRmvc.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace CMRmvc.Controllers
{
    public class EmailController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        public EmailController(ILogger<HomeController> logger) : base(logger)
        {
            _logger = logger;
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
                return View(EmailHelper.ObtenerInstancia().RetunList().FirstOrDefault(x => x.Id == idmail));
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

        public ActionResult Inbox(TypeCorreo mytype = TypeCorreo.Recibido)
        {
            StartMethod(); 
            try
            {
                
                ViewBag.TitleName = mytype;
                ViewBag.CountRecibidos = EmailHelper.ObtenerInstancia().RetunList().Where(x => x.TypeCorreo == TypeCorreo.Recibido && x.FecDel == null).Count();
                ViewBag.CountEnviados = EmailHelper.ObtenerInstancia().RetunList().Where(x => x.TypeCorreo == TypeCorreo.Enviado && x.FecDel == null).Count();

                var mails = EmailHelper.ObtenerInstancia().RetunList().Where(x => x.TypeCorreo == mytype && x.FecDel == null).OrderByDescending(y => y.Fec);
   

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
        public ActionResult Create([Bind("Destinatario,Asunto,Mensaje,Adjuntos")] EmailViewModel vm)
        {
            try
            {
                _logger.LogInformation("Enviando Mail:" + vm.ToString());
                if (ModelState.IsValid)
                {
                    _logger.LogInformation("Se enviara el mail.");
                    EmailViewModel email = new EmailViewModel();
                    email = vm;
                    email.Fec = DateTime.Now;
                    email.TypeCorreo = TypeCorreo.Enviado;
                    email.Etiqueta = EtiquetaCorreo.Ninguna;
                    _logger.LogInformation("Correo creado.");
                    EmailHelper.ObtenerInstancia().AddEmail(email);
                    return RedirectToAction(nameof(Inbox));
                }
                ModelState.AddModelError("", "Ocurrió un error al enviar el correo, vuelva a intentarlo por favor.");
                _logger.LogInformation("Modelo invalido: " + ModelState.IsValid);

                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError("error: " +ex);
                return View();
            }
            finally
            {
                EndMethod();
            }
        }
       
    }
}
