using ValidarFrete.Interface;
using ValidarFrete.Modelo;
using Moq;
using System;
using Xunit;

namespace Teste.ValidarFrete
{
    public class PedidoUnitTest
    {
        private Mock<ICliente> _mockCliente;
        private Mock<IClienteExterior> _mockClienteExterior;

        [Fact]
        public void ValidaEntregaIdZerado()
        {
            // Arrange
            Pedido pedido = new Pedido(1, 12, 0, 15.98);
            bool esperado = false;
            IEntrega entrega = new Entrega();
            Mock<IEntrega> mock = new Mock<IEntrega>();
            mock.Setup(m => m.ValidaEntrega(entrega)).Returns(true);

            //ACT
            var result = pedido.ValidaEntrega(entrega);

            //Assert
            Assert.Equal(result, esperado);
        }

        [Fact]
        public void CalculaFreteTest1()
        {
            //Arrange
            _mockCliente = new Mock<ICliente>();
            Cliente cliente = new Cliente()
            {
                idCliente = 3,
                endereco = "Clarimundo de Melo 857",
                cep = 20123456
            };
            double esperado = 7.26;
            int cep = 20123456;
            _mockCliente.Setup(x => x.getCepById(3)).Returns(cliente.cep);

            Mock<IFrete> _mockFrete = new Mock<IFrete>();
            Frete frete = new Frete()
            {
                idFrete = 25,
                cep = 20123456,
                valorFrete = 7.26
            };
            _mockFrete.Setup(y => y.GetValorFrete(cep)).Returns(frete.valorFrete);

            //ACT
            Pedido pedido = new Pedido(1, 3, _mockCliente.Object, _mockFrete.Object, 5, 25.56);
            double resultado = pedido.CalcularFrete();

            //Assert
            Assert.Equal(esperado, resultado);
        }
        [Fact]
        public void CalculaFreteTest2()
        {
            //Arrange
            _mockClienteExterior = new Mock<IClienteExterior>();
            ClienteExterior clienteExterior = new ClienteExterior()
            {
                idClienteEx = 14,
                pais = "Florida, Estados Unidos",
                zip = 32116
            };
            double esperado = 10.43;
            int zip = 32116;
            _mockClienteExterior.Setup(x => x.getZipById(14)).Returns(clienteExterior.zip);

            Mock<IFreteEx> _mockFreteEx = new Mock<IFreteEx>();
            FreteEx freteEx = new FreteEx()
            {
                idFreteEx = 55,
                zip = 32116,
                valorFreteEx = 10.43
            };
            _mockFreteEx.Setup(y => y.GetValorFreteEx(zip)).Returns(freteEx.valorFreteEx);

            //ACT
            PedidoEx pedidoEx = new PedidoEx(2, 14, _mockClienteExterior.Object, _mockFreteEx.Object, 78, 87.53);
            double resultado = pedidoEx.CalcularFreteExterior();

            //Assert
            Assert.Equal(esperado, resultado);
        }

        [Fact]
        public void CalculaFreteTest3()
        {
            //Arrange
            _mockClienteExterior = new Mock<IClienteExterior>();
            ClienteExterior clienteExterior = new ClienteExterior()
            {
                idClienteEx = 22,
                pais = "Londres, Reino Unido",
                zip = 42256
            };
            double esperado = 20.67;
            int zip = 42256;
            _mockClienteExterior.Setup(x => x.getZipById(22)).Returns(clienteExterior.zip);

            Mock<IFreteEx> _mockFreteEx = new Mock<IFreteEx>();
            FreteEx freteEx = new FreteEx()
            {
                idFreteEx = 66,
                zip = 42256,
                valorFreteEx = 20.67
            };
            _mockFreteEx.Setup(y => y.GetValorFreteEx(zip)).Returns(freteEx.valorFreteEx);

            //ACT
            PedidoEx pedidoEx = new PedidoEx(3, 22, _mockClienteExterior.Object, _mockFreteEx.Object, 97, 120.67);
            double resultado = pedidoEx.CalcularFreteExterior();

            //Assert
            Assert.Equal(esperado, resultado);
        }

    }
}
