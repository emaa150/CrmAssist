using AutoMapper;
using CMRmvc.Models;
using CMRmvc.ViewModel;
using CRMmvc.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.Controllers
{
    public class ClientesController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CRMContext _context;
        private readonly IMapper _mapper;

        public ClientesController(ILogger<HomeController> logger, CRMContext context, IMapper mapper) : base(logger)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            StartMethod();
            try
            {

                return View(_mapper.Map<IEnumerable<ClienteViewModel>>(_context.Clientes.Where(x=> x.FecDel == null && x.UsrDel == null)));
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
        public IActionResult Crud(bool isreadonly, string myaction, long? id)
        {
            StartMethod();
            try
            {
                CreateViewBagItems(isreadonly, myaction,false);

                ClienteViewModel client = null;

                if (id != null && id != 0)
                {
                    _logger.LogInformation("Obteniendo cliente mendiante ID: " + id);
                    client = _mapper.Map<ClienteViewModel>(_context.Clientes.FirstOrDefault(x => x.IdCliente == id));
                    var idprov = _context.Localidades.FirstOrDefault(loc => loc.IdLocalidad == client.IdLocalidad).IdProvincia;
                    client.IdProvincia = idprov ?? 0;
                    _logger.LogInformation(string.Format("Cliente: Nombre:{0}, Apellido:{1}, UserName:{2}, Documento:{3}", client.Nombre, client.Apellido, client.NombreUsuario, client.NroDocumento));
                }


                return View(client);
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
        public IActionResult Edit([Bind("IdCliente,IdDocumentoTipo,NroDocumento,NombreUsuario,Clave,Nombre,Apellido,Mail,Activo,IdLocalidad,IdProvincia,Sexo,Imagen")] ClienteViewModel client)
        {
            StartMethod();
            try
            {
                bool modelStateFoto = true;
                var memory = new MemoryStream();
                _logger.LogInformation(string.Format("Insertando cliente: Nombre:{0},Apellido:{1},UserName:{2},Documento:{3},Email:{4}, ", client.Nombre, client.Apellido, client.NombreUsuario, client.NroDocumento, client.Mail));
                _logger.LogInformation("Verificando imagen");
                if (client.Imagen == null)
                { _logger.LogInformation("no se cargo imagen para el cliente: " + client.NombreUsuario); }
                else
                {
                    if (client.Imagen.Length < 4200000)
                    {
                        _logger.LogInformation("Resize Imagen de usuario" + client.NombreUsuario);
                        using var image = Image.Load(client.Imagen.OpenReadStream());
                        image.Mutate(x => x.Resize(80, 80));
                        image.Save(memory, new JpegEncoder());
                        _logger.LogInformation("Tamaño a guardar: " + memory.Length);
                    }
                    else
                    {
                        ModelState.AddModelError("Imagen", "Debe cargar una imagen max 4mb.");
                        modelStateFoto = false;
                    }

                }
                if (ModelState.IsValid && modelStateFoto)
                {
                  var clientDB = _context.Clientes.FirstOrDefault(x => x.IdCliente == client.IdCliente);
                    if (clientDB != null) 
                    {
                        clientDB.IdDocumentoTipo = client.IdDocumentoTipo;
                        clientDB.NroDocumento = client.NroDocumento;
                        clientDB.NombreUsuario = client.NombreUsuario;
                        clientDB.Clave = client.Clave;
                        clientDB.Nombre = client.Nombre;
                        clientDB.Apellido = client.Apellido;
                        clientDB.Mail = client.Mail;
                        clientDB.Activo = client.Activo;
                        clientDB.IdLocalidad = client.IdLocalidad;
                        clientDB.Sexo = client.Sexo;
                        if (memory.Length > 0)
                        {
                            clientDB.Foto = Convert.ToBase64String(memory.ToArray());
                        }
                        clientDB.FecUpd = DateTime.Now;
                        clientDB.UsrUpd = User.Identity.Name;

                        _context.Update(clientDB);

                        if (_context.SaveChanges() > 0) 
                        {
                            _logger.LogInformation("Cliente editado con exito");
                            _logger.LogInformation("Redirect Index");
                            return RedirectToAction(nameof(Index));
                        }

                        ModelState.AddModelError("", "Ocurrió un error al guardar el cliente");

                    }
                          
                
                }

                CreateViewBagItems(false, nameof(Edit),true);
                return View(nameof(Crud), client);
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
        public IActionResult Create([Bind("IdDocumentoTipo,NroDocumento,NombreUsuario,Clave,Nombre,Apellido,Mail,Activo,IdLocalidad,IdProvincia,Sexo,Imagen")] ClienteViewModel client)
        {
            StartMethod();
            try
            {
                bool modelStateFoto = true;
                var memory = new MemoryStream();
                _logger.LogInformation(string.Format("Insertando cliente: Nombre:{0},Apellido:{1},UserName:{2},Documento:{3},Email:{4}, ", client.Nombre, client.Apellido, client.NombreUsuario, client.NroDocumento, client.Mail));
                _logger.LogInformation("Verificando imagen");
                if (client.Imagen == null)
                { _logger.LogInformation("no se cargo imagen para el cliente: " + client.NombreUsuario); }
                else
                {
                    if (client.Imagen.Length < 4200000)
                    {
                        _logger.LogInformation("Resize Imagen de usuario" + client.NombreUsuario);
                        using var image = Image.Load(client.Imagen.OpenReadStream());
                        image.Mutate(x => x.Resize(80, 80));
                        image.Save(memory, new JpegEncoder());
                        _logger.LogInformation("Tamaño a guardar: " + memory.Length);
                    }
                    else
                    {
                        ModelState.AddModelError("Imagen", "Debe cargar una imagen max 4mb.");
                        modelStateFoto = false;
                    }

                }
                if (ModelState.IsValid && modelStateFoto) 
                {
                    _logger.LogInformation("Modelo valido: " + ModelState.IsValid);

                    _logger.LogInformation("Mapeando Cliente..");
                    var cliente = _mapper.Map<Clientes>(client);
                    if (memory.Length > 0)
                    {
                        cliente.Foto = Convert.ToBase64String(memory.ToArray());
                    }
                    cliente.FecIns = DateTime.Now;
                    cliente.UsrIns = User.Identity.Name;
                    _logger.LogInformation("Insertando cliente...");
                    _context.Clientes.Add(cliente);
                    _logger.LogInformation("Guardando Cambios..");

                    if (_context.SaveChanges() > 0) 
                    {
                        _logger.LogInformation("Usuario creado con exito");
                        _logger.LogInformation("Redirect Index");
                        return RedirectToAction(nameof(Index));
                    }

                    ModelState.AddModelError("", "Ocurrió un error al guardar el cliente");

                }

                _logger.LogInformation("Modelo invalido: " + ModelState.IsValid);
                CreateViewBagItems(false, nameof(Create), true);

                return View(nameof(Crud), client);
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
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            StartMethod();
            try
            {
                _logger.LogInformation("Obteniendo Cliente a eliminar..");
                var clientDel = _context.Clientes.FirstOrDefault(x => x.IdCliente == id);
                _logger.LogInformation("Cliente: " + clientDel.ToString());

                _logger.LogInformation("Modificando fecha delete y user delete");
                clientDel.FecDel = DateTime.Now;
                clientDel.UsrDel = User.Identity.Name;

                _logger.LogInformation("Update Cliente eliminado");
                _context.Clientes.Update(clientDel);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Redirect Index");

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex);
                return NotFound();
            }
            finally
            {
                EndMethod();
            }
        }

        [HttpPost]
        public IActionResult GetLocalidadesByIdProvincia(long idProv) 
        {
            StartMethod();
            try
            {
                _logger.LogInformation("Obteniendo localidades por ID de pronvincia: " + idProv);
                return Json(_context.Localidades.Where(x=> x.IdProvincia == idProv).ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error:" + ex.ToString());
                return Json("Ocurrió un error al recuperar las localidades.");
            }
            finally 
            {
                EndMethod();
            }
       
        }

        [HttpPost]
        public ActionResult ResetPassword(long id)
        {
            StartMethod();
            try
            {
               string passNew = "assist123";
               var cliente = _context.Clientes.FirstOrDefault(cli => cli.IdCliente == id);
               if (cliente != null) 
                 {
                     cliente.Clave = passNew;
                    _context.Clientes.Update(cliente);
                    _context.SaveChanges();
                 }
                return Json(passNew);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: " + ex.ToString());
                return Json("Ocurrió un error al resetear su contraseña.");
            }
            finally
            {
                EndMethod();
            }
        }

        private void CreateViewBagItems(bool isreadonly, string myaction, bool visLoc) 
        {
            ViewBag.IsReadOnly = isreadonly;
            ViewBag.Action = myaction;
            ViewBag.VisLoc = visLoc;

            var docTipo = _context.DocumentoTipo.ToList();
            docTipo.Insert(0, new DocumentoTipo { IdDocTipo=0, Nombre="SELECCIONAR" });
            ViewBag.DocumentoTipos = new SelectList(docTipo, "IdDocTipo", "Nombre");

            var listGen = Enum.GetValues(typeof(Enums.Genero)).Cast<Enums.Genero>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
            listGen.Insert(0, new SelectListItem { Text = "SELECCIONAR", Value = "0" });
            ViewBag.Generos = listGen;

            var prov = _context.Provincias.ToList();
            prov.Insert(0, new Provincias { IdProvincia = 0, Nombre = "SELECCIONAR" });
            ViewBag.Provincias = new SelectList(prov, "IdProvincia", "Nombre");

        }
    }
}
