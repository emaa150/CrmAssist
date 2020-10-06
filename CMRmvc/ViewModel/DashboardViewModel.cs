using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.ViewModel
{
    public class DashboardViewModel
    {
        public string TotalUsuarios { get; set; }
        public string TotalLogueadosHoy { get; set; }
        public string TotalMasculinos { get; set; }
        public string TotalFemeninos { get; set; }
    }
}
