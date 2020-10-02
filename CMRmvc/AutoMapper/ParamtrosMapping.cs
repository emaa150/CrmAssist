using AutoMapper;
using CMRmvc.Models;
using CMRmvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.AutoMapper
{
    public class ParamtrosMapping : Profile
    {
        public ParamtrosMapping()
        {
            #region PARAMETROS            
            CreateMap<Parametros, ParametrosViewModel>();
            CreateMap<ParametrosViewModel, Parametros>();
            CreateMap<List<Parametros>, List<ParametrosViewModel>>();
            #endregion

        }

    }
   
}
