using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.ViewModel
{
    public class EmailViewModel
    {
        public string Destinatario { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fec { get; set; }
        public DateTime? FecDel { get; set; }        
        public EtiquetaCorreo Etiqueta { get; set; }
        public TypeCorreo TypeCorreo { get; set; }
    }

    public enum EtiquetaCorreo { Ninguna= 0, Importante=1, Promociones=2, Social=3}
    public enum TypeCorreo { Enviado = 0, Recibido = 1}
}
