using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFNegocios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract] public interface IService1
    {
        [OperationContract] List<Cliente> cliente();
        [OperationContract] List<Pedido> pedidos();
        [OperationContract] List<Pedido> pedido_cliente(String idcli);
        [OperationContract] List<Pedido> pedido_anio(int y);

    }

    [DataContract] public class Pedido
    {
        [DataMember] public int idpedido { get; set; }
        [DataMember] public DateTime fechapedido { get; set; }
        [DataMember] public string idcliente { get; set; }
        [DataMember] public string direccion { get; set; }
        [DataMember] public string ciudad { get; set; }
    }

    [DataContract] public class Cliente
    {
        [DataMember] public string idcliente { get; set; }
        [DataMember] public string nombrecia { get; set; }
        [DataMember] public string direccion { get; set; }
        [DataMember] public string telefono { get; set; }
    }

}
