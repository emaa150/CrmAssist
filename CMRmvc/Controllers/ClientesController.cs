﻿using AutoMapper;
using CMRmvc.Models;
using CMRmvc.ViewModel;
using CRMmvc.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
                CreateViewBagItems(isreadonly, myaction);

                ClienteViewModel client = null;

                if (id != null && id != 0) 
                {
                    _logger.LogInformation("Obteniendo cliente mendiante ID: " + id);
                    client = _mapper.Map<ClienteViewModel>(_context.Clientes.FirstOrDefault(x => x.IdCliente == id));
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
        public IActionResult Edit([Bind("IdCliente,IdDocumentoTipo,NroDocumento,NombreUsuario,Clave,Nombre,Apellido,Mail,Activo,IdLocalidad,Sexo")] ClienteViewModel client)
        {
            StartMethod();
            try
            {
                if (ModelState.IsValid) 
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

                        _context.Update(clientDB);

                        if (_context.SaveChanges() > 0) 
                        {
                            _logger.LogInformation("User editado con exito");
                            _logger.LogInformation("Redirect Index");
                            return RedirectToAction(nameof(Index));
                        }

                        ModelState.AddModelError("", "Ocurrió un error al guardar el cliente");

                    }
                          
                
                }

                CreateViewBagItems(false, nameof(Edit));
                return View(nameof(Crud));
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
        public IActionResult Create([Bind("IdDocumentoTipo,NroDocumento,NombreUsuario,Clave,Nombre,Apellido,Mail,Activo,IdLocalidad,Sexo")] ClienteViewModel client)
        {
            StartMethod();
            try
            {
                _logger.LogInformation(string.Format("Insertando cliente: Nombre:{0},Apellido:{1},UserName:{2},Documento:{3},Email:{4}, ", client.Nombre, client.Apellido, client.NombreUsuario, client.NroDocumento, client.Mail));

                if (ModelState.IsValid) 
                {
                    _logger.LogInformation("Modelo valido: " + ModelState.IsValid);

                    _logger.LogInformation("Mapeando Cliente..");
                    var cliente = _mapper.Map<Clientes>(client);
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
                CreateViewBagItems(false, nameof(Create));

                return View(nameof(Crud));
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
    
        public IActionResult Delete()
        {
            StartMethod();
            try
            {

                return View(nameof(Index));
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
        public async Task<ActionResult> ResetPassword(long id)
        {
            StartMethod();
            try
            {
                return null;
            }
            catch (Exception ex)
            {
               
                return Json("Ocurrió un error al resetear su contraseña.");
            }
            finally
            {
                EndMethod();
            }
        }

        private void CreateViewBagItems(bool isreadonly, string myaction) 
        {
            ViewBag.IsReadOnly = isreadonly;
            ViewBag.Action = myaction;

            var docTipo = _context.DocumentoTipo.ToList();
            docTipo.Insert(0, new DocumentoTipo { IdDocTipo=0, Nombre="SELECCIONAR" });
            ViewBag.DocumentoTipos = new SelectList(docTipo, "IdDocTipo", "Nombre");

            ViewBag.Generos = Enum.GetValues(typeof(Enums.Genero)).Cast<Enums.Genero>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();

            var prov = _context.Provincias.ToList();
            prov.Insert(0, new Provincias { IdProvincia = 0, Nombre = "SELECCIONAR" });
            ViewBag.Provincias = new SelectList(prov, "IdProvincia", "Nombre");

        }
    }
}
