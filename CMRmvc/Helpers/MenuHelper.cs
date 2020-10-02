﻿using AutoMapper;
using CMRmvc.Models;
using CMRmvc.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace CMRmvc.Helpers
{
    public class MenuHelper
    {
        public static List<MenuItemPadreViewModel> GenerateMenu(string UserName,ILogger log, CRMContext context, out UserViewModel usu,IMapper mapper)
        {
            log.LogInformation("********** GenerateMenu() START **********");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<MenuItemPadreViewModel> _listMenu = null;
            usu = null;
            try
            {
                log.LogInformation("GenerateMenu() -> Validando Username: " + UserName);
                if (!string.IsNullOrEmpty(UserName))
                {
                    log.LogInformation("GenerateMenu() ->  Consultando usuario en db...");
                    var user = mapper.Map<UserViewModel>(context.Users.FirstOrDefault(x => x.UserName.ToLower() == UserName.ToLower()));
                    log.LogInformation("GenerateMenu() -> Validando usuario consultado...");
                    if(user != null) 
                    {                        
                        log.LogInformation("GenerateMenu() -> Usuario encontrado: " + user.UserName);                            
                        if (Convert.ToBoolean(user.Activo))
                        {
                            log.LogInformation("GenerateMenu() ->  Usuario OK!");
                            user.Role = mapper.Map<RoleViewModel>(context.Roles.FirstOrDefault(x => x.Id == user.RoleID));
                            
                            log.LogInformation("GenerateMenu() ->  Rol: "+ user.Role.NormalizedName);

                            if (user.Role != null)
                            {
                                if (user.Role.IsActive)
                                {
                                    usu = user;
                                    log.LogInformation("GenerateMenu() ->  Rol OK!");

                                    List<MenuItemPadreViewModel> menuItemPadre = new List<MenuItemPadreViewModel>();
                                    List<MenuItemHijoViewModel> menuItemHijo = new List<MenuItemHijoViewModel>();
                                    List<MenuHijoAccionesViewModel> menuHijoAcciones = new List<MenuHijoAccionesViewModel>();

                                    log.LogInformation("GenerateMenu() -> Consultado menuAcciones del rol");
                                    var acciones = context.RolesAcciones.Where(x => x.IdRol == user.Role.Id).ToList();
                                   // var acciones = mapper.Map<List<RolesAccionesViewModel>>(acc);
                                    log.LogInformation("GenerateMenu() -> RolesAcciones encontrados: "+ acciones.Count);
                                    foreach (var item in acciones)
                                    {
                                        MenuHijoAccionesViewModel mAcciones = new MenuHijoAccionesViewModel();
                                        var hijo = context.MenuHijoAcciones.FirstOrDefault(x => x.IdMenuHijoAccion == item.IdMenuHijoAccion);
                                        mAcciones =mapper.Map<MenuHijoAccionesViewModel>(hijo);
                                        menuHijoAcciones.Add(mAcciones);
                                    }

                                    var idMenuHijos = menuHijoAcciones.Select(x=>x.IdMenuHijo).Distinct().ToList();
                                    foreach (var item in idMenuHijos)
                                    {
                                        MenuItemHijoViewModel mHijo = new MenuItemHijoViewModel();
                                        mHijo = mapper.Map<MenuItemHijoViewModel>(context.MenuItemHijo.FirstOrDefault(x => x.IdMenuHijo == item));
                                        mHijo.MenuHijoAcciones = menuHijoAcciones.Where(x => x.IdMenuHijo == item).ToList();
                                        menuItemHijo.Add(mHijo);
                                    }

                                    var idMenuPadre = menuItemHijo.Select(x => x.IdMenuPadre).Distinct().ToList();
                                    foreach (var item in idMenuPadre)
                                    {
                                        MenuItemPadreViewModel mPadre = new MenuItemPadreViewModel();
                                        mPadre = mapper.Map<MenuItemPadreViewModel>(context.MenuItemPadre.FirstOrDefault(x => x.IdMenuPadre == item));
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
