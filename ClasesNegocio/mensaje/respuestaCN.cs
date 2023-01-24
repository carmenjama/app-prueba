using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClasesNegocio.mensaje
{
    [DataContract]
    public class respuestaCN
    {
        [DataMember]
        public String estado { get; set; }
        [DataMember]
        public String mensaje { get; set; }

        public respuestaCN()
        {
            this.estado = String.Empty;
            this.mensaje = String.Empty;
        }
    }
}
