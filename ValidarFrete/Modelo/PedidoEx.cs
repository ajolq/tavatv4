using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidarFrete.Interface
{
    public class PedidoEx
    {
        public int id { get; set; }
        public int idClienteEx { get; set; }
        public int idEntrega { get; set; }
        public double valorTotal { get; set; }
        public ICliente Cliente { get; }
        public IClienteExterior ClienteExterior { get; }
        public IFreteEx FreteEx { get; }

        public PedidoEx(int _id, int _clienteEx, int _idEntrega, double _valorTotal)
        {
            id = _id;
            idClienteEx = _clienteEx;
            idEntrega = _idEntrega;
            valorTotal = _valorTotal;
        }

        public PedidoEx(int _id, int _idClienteEx, IClienteExterior clienteEx, IFreteEx freteEx, int _idEntrega, double _valorTotal)
        {
            id = _id;
            ClienteExterior = clienteEx;
            idClienteEx = _idClienteEx;
            FreteEx = freteEx;
            idEntrega = _idEntrega;
            valorTotal = _valorTotal;
        }

        public double CalcularFreteExterior()
        {
            int zip = ClienteExterior.getZipById(idClienteEx);
            double valorFrete = FreteEx.GetValorFreteEx(zip);
            return valorFrete;
        }
    }

}
