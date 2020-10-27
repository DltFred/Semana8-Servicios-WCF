using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WCFNegocios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        String cadena = "Server=localhost;Database=Negocios2020;Trusted_Connection=True";
        public List<Cliente> cliente()
        {
            List<Cliente> temporal = new List<Cliente>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand("select idcliente, nombrecia,direccion,telefono from tb_clientes",cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Cliente reg = new Cliente();
                        reg.idcliente = dr.GetString(0);
                        reg.nombrecia = dr.GetString(1);
                        reg.direccion = dr.GetString(2);
                        reg.telefono = dr.GetString(3);
                        temporal.Add(reg);
                    }
                    dr.Close();cn.Close();
                }
            }
            return temporal;
        }

        public List<Pedido> pedidos()
        {
            List<Pedido> temporal = new List<Pedido>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                using (SqlCommand cmd = new SqlCommand(
                    "select idpedido, fechapedido, idcliente, direccionDestinatario, ciudadDestinatario from tb_pedidoscabe", cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Pedido pd = new Pedido();
                        pd.idpedido = dr.GetInt32(0);
                        pd.fechapedido = dr.GetDateTime(1);
                        pd.idcliente = dr.GetString(2);
                        pd.direccion = dr.GetString(3);
                        pd.ciudad = dr.GetString(4);
                        temporal.Add(pd);
                    }
                    dr.Close(); cn.Close();
                }
            }
            return temporal;
        }

        public List<Pedido> pedido_anio(int y)
        {
            //pedidos por año de fechapedido
            List<Pedido> temporal = new List<Pedido>();
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                using (SqlCommand cmd =
                    new SqlCommand("select idpedido,fechapedido, idcliente, direccionDestinatario, " +
                    "ciudadDestinatario from tb_pedidoscabe where year(fechapedido)=@y ", connection))
                {
                    cmd.Parameters.AddWithValue("@y", y);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Pedido p = new Pedido
                        {
                            idpedido = dr.GetInt32(0),
                            fechapedido = dr.GetDateTime(1),
                            idcliente = dr.GetString(2),
                            direccion = dr.GetString(3),
                            ciudad = dr.GetString(4)
                        };
                        temporal.Add(p);
                    }
                    dr.Close(); connection.Close();
                }
            }
            return temporal;
        }

        public List<Pedido> pedido_cliente(string idcli)
        {
            //pedidoscabe por idcliente
            List<Pedido> temporal = new List<Pedido>();
            using (SqlConnection connection = new SqlConnection(cadena))
            {
                using (SqlCommand cmd =
                    new SqlCommand("select idpedido,fechapedido, idcliente, " +
                    "direccionDestinatario, ciudadDestinatario from tb_pedidoscabe where idcliente=@cli", connection))

                {
                    cmd.Parameters.AddWithValue("@cli", idcli);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Pedido p = new Pedido
                        {
                            idpedido = dr.GetInt32(0),
                            fechapedido = dr.GetDateTime(1),
                            idcliente = dr.GetString(2),
                            direccion = dr.GetString(3),
                            ciudad = dr.GetString(4)
                        };
                        temporal.Add(p);
                    }
                    dr.Close(); connection.Close();
                }
            }
            return temporal;
        }
    }
}
