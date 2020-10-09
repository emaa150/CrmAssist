using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
                email.Fec = DateTime.Now.AddDays(-i);

                if ((i % 2) == 0)
                {
                    email.Asunto = "El pasaje estándar Lorem Ipsum, usado desde el año 1500.";
                    var mimsg = "Lorem Ipsum is simply dummy text of the printing and typesetting\n industry. Lorem Ipsum has been the industry's standard dummy\ntext ever since the 1500s, when an unknown printer took a galley\n of type and scrambled it to make a type specimen book. It has\n survived not only five centuries, but also the leap into electronic\n typesetting, remaining essentially unchanged. It was popularised in\n the 1960s with the release of Letraset sheets containing Lorem\n Ipsum passages, and more recently with desktop publishing\n software like Aldus PageMaker including versions of Lorem Ipsum";
                    email.Mensaje = mimsg + "  ForID:" + i;
                    email.TypeCorreo = TypeCorreo.Recibido;
                    email.Etiqueta = EtiquetaCorreo.Importante;
                }
                else
                {
                    email.Asunto = "Sección 1.10.33 de Finibus Bonorum et Malorum, escrito por Cicero en el 45 antes de Cristo";
                    var mimsg = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis\n praesentium voluptatum deleniti atque corrupti quos dolores\n et quas molestias excepturi sint occaecati cupiditate non provident,\n similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga.\nEt harum quidem rerum facilis est et expedita distinctio.Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus.\n Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae\n sint et molestiae non recusandae.Itaque earum rerum hic tenetur a sapiente delectus,\n ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.";
                    email.Mensaje = mimsg + "  ForID:" + i;
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

                var mails = listEmails.Where(x => x.TypeCorreo == mytype && x.FecDel == null).OrderByDescending(y => y.Fec);
   

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
                    listEmails.Add(email);
                    return RedirectToAction(nameof(Inbox));
                }
                ModelState.AddModelError("", "Ocurrió un error al enviar el correo, vuelva a intentarlo por favor.");
                _logger.LogInformation("Modelo invalido: " + ModelState.IsValid);

                return View();
            }
            catch
            {
                return View();
            }
        }
       
    }
}
