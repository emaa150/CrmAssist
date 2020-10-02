using AutoMapper;
using CMRmvc.Models;
using CMRmvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.AutoMapper
{
    public class UsersMapping :Profile
    {
        public UsersMapping()
        {
            #region USUARIOS        
            CreateMap<User, UserViewModel>();
            CreateMap<UserViewModel, User>();
            CreateMap<List<User>, List<UserViewModel>>();
            #endregion
        }
    }
}
