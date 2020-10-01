using AutoMapper;
using CMRmvc.Models;
using CMRmvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            #region PARAMETROS            
            CreateMap<Parametros, ParametrosViewModel>();
            CreateMap<ParametrosViewModel, Parametros>();
            CreateMap<List<Parametros>, List<ParametrosViewModel>>();
            CreateMap<List<ParametrosViewModel>, List<Parametros>>();
            #endregion

            //#region USUARIOS        
            //CreateMap<Parametros, ParametrosViewModel>();
            //CreateMap<ParametrosViewModel, Parametros>();
            //CreateMap<List<Parametros>, List<ParametrosViewModel>>();
            //CreateMap<List<ParametrosViewModel>, List<Parametros>>();
            //#endregion

        }

    }
   
}
