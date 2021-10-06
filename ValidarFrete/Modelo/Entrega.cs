using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidarFrete.Interface
{
    public class Entrega : IEntrega
    {
        public int idEntrega { get; set; }
        public int idEndereco { get; set; }
        public DateTime agendamento { get; set; }
        public bool ValidaEntrega(IEntrega entrega)
        {
            return true;
        }
    }
}
