﻿using AutoMapper;
using CMRmvc.Models;
using CMRmvc.ViewModel;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.AutoMapper
{
    public class MenuMapping :Profile
    {
        public MenuMapping()
        {
            #region RolesAcciones
            CreateMap<List<RolesAcciones>, List<RolesAccionesViewModel>>();
            CreateMap<List<RolesAccionesViewModel>, List<RolesAcciones>>();
            CreateMap<RolesAcciones, RolesAccionesViewModel>();
            CreateMap<RolesAccionesViewModel, RolesAcciones>();
            #endregion

            #region PerfilMenuHijo
            CreateMap<List<PerfilMenuHijoViewModel>, List<PerfilMenuHijo>>();
            CreateMap<List<PerfilMenuHijo>, List<PerfilMenuHijoViewModel>>();
            CreateMap<PerfilMenuHijoViewModel, PerfilMenuHijo>();
            CreateMap<PerfilMenuHijo, PerfilMenuHijoViewModel>();
            #endregion

            #region MenuItemPadre
            CreateMap<List<MenuItemPadre>, List<MenuItemPadreViewModel>>();
            #endregion

            #region PerfilMenuHijo
            CreateMap<List<PerfilMenuHijo>, List<PerfilMenuHijoViewModel>>();
            #endregion

            #region MenuHijoAcciones
            CreateMap<MenuHijoAcciones, MenuHijoAccionesViewModel>();
            #endregion

            #region MenuItemHijo
            CreateMap<MenuItemHijo, MenuItemHijoViewModel>();
            #endregion

            #region MenuItemPadre
            CreateMap<MenuItemPadre, MenuItemPadreViewModel>();
            #endregion
        }
    }
}