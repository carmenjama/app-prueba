using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClasesNegocio.mensaje
{
    [DataContract]
    public class respuesta_usuarioCN
    {
        [DataMember]
        public String estado { get; set; }
        [DataMember]
        public String mensaje { get; set; }

        [DataMember]
        public String nick { get; set; }
        [DataMember]
        public String token { get; set; }
        [DataMember]
        public String rol { get; set; }

        public respuesta_usuarioCN()
        {
            this.estado = String.Empty;
            this.mensaje = String.Empty;
            this.nick = String.Empty;
            this.token = String.Empty;
        }
    }
}
