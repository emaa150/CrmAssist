using AutoMapper;
using CMRmvc.Models;
using CMRmvc.ViewModel;
using System.Collections.Generic;

namespace CMRmvc.AutoMapper
{
    public class RolesMapping : Profile
    {
        public RolesMapping() 
        {
            #region ROLES        
            CreateMap<Role, RoleViewModel>();
            CreateMap<RoleViewModel, Role>();
            CreateMap<List<Role>, List<RoleViewModel>>();
            CreateMap<List<RoleViewModel>, List<Role>>();
            #endregion
        }

    }
}
