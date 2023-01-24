using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClasesNegocio.usuario
{
    public  class rolCN
    {
        public Int64 id_rol { get; set; }
        [DataMember]
        public String nombre { get; set; }
        [DataMember]
        public String descripcion { get; set; }
        [DataMember]
        public bool estado { get; set; }

        public rolCN()
        {
            this.id_rol = 0;
            this.nombre = String.Empty;
            this.descripcion = String.Empty;
            this.estado = false;
        }
    }
}
