using CMRmvc.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace CMRmvc.Helpers
{
    public class MenuHelper
    {
        public static List<MenuItemPadre> GenerateMenu(string UserName,ILogger log, CRMContext context)
        {
            log.LogInformation("********** GenerateMenu() START **********");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<MenuItemPadre> _listMenu = null;
            try
            {
                log.LogInformation("GenerateMenu() -> Validando Username: " + UserName);
                if (!string.IsNullOrEmpty(UserName))
                {
                    log.LogInformation("GenerateMenu() ->  Consultando usuario en db...");
                    var user = context.Users.FirstOrDefault(x => x.UserName.ToLower() == UserName.ToLower());
                    log.LogInformation("GenerateMenu() -> Validando usuario consultado...");
                    if(user != null) 
                    {                        
                        log.LogInformation("GenerateMenu() -> Usuario encontrado: " + user.UserName);                            
                        if (Convert.ToBoolean(user.Activo))
                        {
                            log.LogInformation("GenerateMenu() ->  Usuario OK!");
                            log.LogInformation("GenerateMenu() -> Iniciano reconstruccionn del Menu...");

                            log.LogInformation("GenerateMenu() ->  Recuperando roles del usuario...");
                            var rolUser = context.UserRoles.FirstOrDefault(x => x.UserId == user.Id);
                            log.LogInformation("GenerateMenu() ->  Rol perteneciente al usuario: "+rolUser.RoleId);
                            var rol = context.Roles.FirstOrDefault(x => x.Id==rolUser.RoleId);
                            log.LogInformation("GenerateMenu() ->  Rol recuperado: "+ rol.NormalizedName);
                            if (rol != null)
                            {
                                if (rol.IsActive)
                                {
                                    List<MenuItemPadre> menuItemPadre = new List<MenuItemPadre>();
                                    List<MenuItemHijo> menuItemHijo = new List<MenuItemHijo>();
                                    List<MenuHijoAcciones> menuHijoAcciones = new List<MenuHijoAcciones>();

                                    log.LogInformation("GenerateMenu() -> Consultado menuAcciones del rol");
                                    var acciones = context.RolesAcciones.Where(x => x.IdRol == rol.Id).ToList();
                                    log.LogInformation("GenerateMenu() -> RolesAcciones encontrados: "+ acciones.Count);
                                    foreach (var item in acciones)
                                    {
                                        MenuHijoAcciones mAcciones = new MenuHijoAcciones();
                                        mAcciones = context.MenuHijoAcciones.FirstOrDefault(x=>x.IdMenuHijoAccion == item.IdMenuHijoAccion);
                                        menuHijoAcciones.Add(mAcciones);
                                    }

                                    var idMenuHijos = menuHijoAcciones.Select(x=>x.IdMenuHijo).Distinct().ToList();
                                    foreach (var item in idMenuHijos)
                                    {
                                        MenuItemHijo mHijo = new MenuItemHijo();
                                        mHijo = context.MenuItemHijo.FirstOrDefault(x => x.IdMenuHijo == item);
                                        mHijo.MenuHijoAcciones = menuHijoAcciones.Where(x => x.IdMenuHijo == item).ToList();
                                        menuItemHijo.Add(mHijo);
                                    }

                                    var idMenuPadre = menuItemHijo.Select(x => x.IdMenuPadre).Distinct().ToList();
                                    foreach (var item in idMenuPadre)
                                    {
                                        MenuItemPadre mPadre = new MenuItemPadre();
                                        mPadre = context.MenuItemPadre.FirstOrDefault(x => x.IdMenuPadre == item);
                                        mPadre.MenuItemHijo = menuItemHijo.Where(x => x.IdMenuPadre == item).ToList();
                                        menuItemPadre.Add(mPadre);
                                    }
                                    
                                    _listMenu = menuItemPadre;
                                }
                                else
                                { log.LogInformation("GenerateMenu() ->  no se encuentra activado el rol "); }
                            }
                            else
                            { log.LogInformation("GenerateMenu() ->  no se pudo recuperar el ROL "); }
                            

                        }
                        else log.LogInformation("GenerateMenu() -> No se habilito el menu ya que el usuario se encuentra deshabilitado. " + UserName);
                        
                    }
                    else log.LogWarning("GenerateMenu() -> NO SE PUDO CONTRUIR EL MENU. No se encontro el usuario en db. " + UserName);
                }
                else log.LogWarning("GenerateMenu() -> NO SE PUDO CONTRUIR EL MENU. No se obtuvo el Username. " + UserName);
            }
            catch (Exception ex)
            {
                log.LogError("GenerateMenu() -> Error al generar menu." + ex.Message + ex.StackTrace);
                _listMenu = null;
            }
            finally
            {
                if (stopwatch != null)
                {
                    stopwatch.Stop();
                    log.LogInformation("GenerateMenu() -> Tiempo requerido para armar menu: " + stopwatch.ElapsedMilliseconds.ToString());
                }                    
                log.LogInformation("********** GenerateMenu() END **********");
            }
            return _listMenu;
        }
    }
}
