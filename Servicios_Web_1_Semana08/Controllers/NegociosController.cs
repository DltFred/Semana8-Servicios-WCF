using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicios_Web_1_Semana08.ReferenciaWCFNegocios;

namespace Servicios_Web_1_Semana08.Controllers
{
    public class NegociosController : Controller
    {
        // Instancia el servicioClient
        Service1Client servicio = new Service1Client();
        public ActionResult ListadoClientes()
        {
            return View(servicio.cliente());
        }
        public ActionResult ListaPedidos()
        {
            return View(servicio.pedidos());
        }
        public ActionResult ListPedidosYear(int? y = null)
        {
            if (y == null)
                return View(new List<Pedido>());
            else
                return View(servicio.pedido_anio((int)y));
        }
        public ActionResult ListPedidosCliente(string cli = "")
        {
            //listar los clientes en un SelectList
            ViewBag.clientes = new SelectList(servicio.cliente(), "idcliente", "nombrecia", cli);
            //enviar
            return View(servicio.pedido_cliente(cli));

        }
    }
}