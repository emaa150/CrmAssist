using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Calse encargada de Crear todas las clasesVewModel destinada al Menu y sus roles
/// Contiene: MenuHijoAccionesViewModel, MenuItemHijoViewModel, MenuItemPadreViewModel,RolesAccionesViewModel,PerfilMenuHijoViewModel
/// </summary>
namespace CMRmvc.ViewModel
{    
    public abstract class CheckedProperty
    {
        public bool IsChecked { get; set; }
    }

    public class MenuHijoAccionesViewModel : CheckedProperty
    {
        public MenuHijoAccionesViewModel()
        {
            //RolesAcciones = new HashSet<RolesAcciones>();
        }

        public long IdMenuHijoAccion { get; set; }
        public long IdMenuHijo { get; set; }
        public string MhaKey { get; set; }
        public string MhaIcono { get; set; }
        public string MhaTooltip { get; set; }
        public string MhaClase { get; set; }
        public int? MhaOrden { get; set; }
        public bool? MhaNewTab { get; set; }
        public string MhaUrl { get; set; }
        public string MhaTexto { get; set; }
        [JsonIgnore]
        public MenuItemHijoViewModel IdMenuHijoNavigation { get; set; }
        public List<RolesAccionesViewModel> RolesAcciones { get; set; }

    }

    public class MenuItemHijoViewModel : CheckedProperty
    {
        public MenuItemHijoViewModel()
        {
        }

        public long IdMenuHijo { get; set; }
        public long IdMenuPadre { get; set; }
        public string Nombr { get; set; }
        public string Controlador { get; set; }
        public string Accion { get; set; }
        public string Icono { get; set; }
        [JsonIgnore]
        public virtual MenuItemPadreViewModel IdMenuPadreNavigation { get; set; }
        public virtual List<MenuHijoAccionesViewModel> MenuHijoAcciones { get; set; }
    }

    public class MenuItemPadreViewModel : CheckedProperty
    {
        public MenuItemPadreViewModel()
        {
        }

        public long IdMenuPadre { get; set; }
        public string Nombre { get; set; }
        public string Icono { get; set; }
        public List<MenuItemHijoViewModel> MenuItemHijo { get; set; }
    }

    public class RolesAccionesViewModel
    {
        public long IdPerfilAccion { get; set; }
        public long IdRol { get; set; }
        public long IdMenuHijoAccion { get; set; }
        [JsonIgnore]
        public MenuHijoAccionesViewModel IdMenuHijoAccionNavigation { get; set; }
    }

    public class PerfilMenuHijoViewModel
    {
        public long IdPerfilMenuHijo { get; set; }
        public long IdRol { get; set; }
        public long IdMenuHijo { get; set; }

        public MenuItemHijoViewModel IdMenuHijoNavigation { get; set; }
    }
}
