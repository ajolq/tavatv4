using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidarFrete.Interface
{
    public interface IEntrega
    {
        public bool ValidaEntrega(IEntrega entrega);
    }
}
