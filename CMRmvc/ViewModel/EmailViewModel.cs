using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace CMRmvc.ViewModel
{
    public class EmailViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar destinatario.")]
        public string Destinatario { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
        public DateTime Fec { get; set; }
        public DateTime? FecDel { get; set; }        
        public EtiquetaCorreo Etiqueta { get; set; }
        public TypeCorreo TypeCorreo { get; set; }
        public IFormCollection Adjuntos { get; set; }

        public override string ToString()
        {
            return "Para: " +Destinatario+";\r\n" +
                "Asunto: " + Asunto + ";\r\n" +
                "Mensaje: " + Mensaje + ";\r\n";
        }
    }

    public enum EtiquetaCorreo { Ninguna= 0, Importante=1, Promociones=2, Social=3}
    public enum TypeCorreo { Enviado = 0, Recibido = 1}
}
