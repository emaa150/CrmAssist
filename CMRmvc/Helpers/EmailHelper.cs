using CMRmvc.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMRmvc.Helpers
{
    public class EmailHelper
    {
        private List<EmailViewModel> listEmails;
        private static EmailHelper _Instancia;

        public static EmailHelper ObtenerInstancia()
        {
            if (_Instancia == null) { _Instancia = new EmailHelper(); }
            return _Instancia;
        }

        private EmailHelper()
        { LoadEmails(); }

        private void LoadEmails()
        {
            if (listEmails == null)
            {
                listEmails = new List<EmailViewModel>();
                for (int i = 0; i < 20; i++)
                {
                    EmailViewModel email = new EmailViewModel();
                    email.Id = i;
                    email.Destinatario = string.Format("ejemplo{0}@email.com", i);
                    email.Fec = DateTime.Now.AddDays(-i);

                    if ((i % 2) == 0)
                    {
                        email.Asunto = "El pasaje estándar Lorem Ipsum, usado desde el año 1500.";
                        var mimsg = "Lorem Ipsum is simply dummy text of the printing and typesetting\n industry. Lorem Ipsum has been the industry's standard dummy\ntext ever since the 1500s, when an unknown printer took a galley\n of type and scrambled it to make a type specimen book. It has\n survived not only five centuries, but also the leap into electronic\n typesetting, remaining essentially unchanged. It was popularised in\n the 1960s with the release of Letraset sheets containing Lorem\n Ipsum passages, and more recently with desktop publishing\n software like Aldus PageMaker including versions of Lorem Ipsum";
                        email.Mensaje = mimsg + "  ForID:" + i;
                        email.TypeCorreo = TypeCorreo.Recibido;
                        email.Etiqueta = EtiquetaCorreo.Importante;
                    }
                    else
                    {
                        email.Asunto = "Sección 1.10.33 de Finibus Bonorum et Malorum, escrito por Cicero en el 45 antes de Cristo";
                        var mimsg = "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis\n praesentium voluptatum deleniti atque corrupti quos dolores\n et quas molestias excepturi sint occaecati cupiditate non provident,\n similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga.\nEt harum quidem rerum facilis est et expedita distinctio.Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus.\n Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae\n sint et molestiae non recusandae.Itaque earum rerum hic tenetur a sapiente delectus,\n ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.";
                        email.Mensaje = mimsg + "  ForID:" + i;
                        email.TypeCorreo = TypeCorreo.Enviado;
                        email.Etiqueta = EtiquetaCorreo.Promociones;
                    }
                    listEmails.Add(email);
                }
            }
        }

        public List<EmailViewModel> RetunList()
        {
            return listEmails.ToList();
        }
        public void AddEmail(EmailViewModel email)
        {
            listEmails.Add(email);
        }
    }
}
