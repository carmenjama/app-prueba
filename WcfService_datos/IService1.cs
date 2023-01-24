using ClasesNegocio.datos;
using ClasesNegocio.mensaje;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService_datos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {

        // TODO: agregue aquí sus operaciones de servicio

        [OperationContract]
        respuesta_usuarioCN Autenticar(String usuario, String clave);

        [OperationContract]
        respuestaCN RegistrarUsuario(String usuario, String clave, Int64 id_rol);

        [OperationContract]
        bool Verificar_rol_usuario(String usuario, String token, String rol);

        [OperationContract]
        List<statesCN> Listar_states(String usuario, String token);


        [OperationContract]
        List<usCN> Listar_us(String usuario, String token);

    }

}
