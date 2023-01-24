using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClasesNegocio.usuario
{
    [DataContract]
    public class usuarioCN
    {
        [DataMember]
        public Int64 id_usuario { get; set; }
        [DataMember]
        public Int64 id_rol { get; set; }
        [DataMember]
        public String nick { get; set; }
        [DataMember]
        public String clave { get; set; }
        [DataMember]
        public String token { get; set; }
        [DataMember]
        public bool estado { get; set; }

        public usuarioCN()
        {
            this.id_usuario = new Int64();
            this.id_rol = new Int64();
            this.nick = String.Empty;
            this.clave = String.Empty;
            this.token = String.Empty;  
            this.estado = false;
        }
    }
}
