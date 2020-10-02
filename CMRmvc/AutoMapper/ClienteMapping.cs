using AutoMapper;
using CMRmvc.Models;
using CMRmvc.ViewModel;
using System.Collections.Generic;

namespace CMRmvc.AutoMapper
{
    public class ClienteMapping : Profile
    {
        public ClienteMapping()
        {
            #region CLIENTES        
            CreateMap<Clientes, ClienteViewModel>();
            CreateMap<ClienteViewModel, Clientes>();
            CreateMap<List<Clientes>, List<ClienteViewModel>>();
            #endregion
        }
    }
}
