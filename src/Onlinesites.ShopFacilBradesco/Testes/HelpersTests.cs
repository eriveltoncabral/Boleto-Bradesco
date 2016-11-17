using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testes
{
    [TestClass]
    public class HelpersTests
    {
        [TestMethod]
        public void TesteGerardorDeNumeroDePedido()
        {
            var numeroPedido = Onlinesites.ShopFacilBradesco.Utils.Helpers.GerarNumeroPedido(1234, 32, "P", "V");

            Assert.AreEqual(numeroPedido, "P1234_V32", "Número do pedido não era o esperado");
            Assert.IsTrue(Onlinesites.ShopFacilBradesco.Utils.Helpers.IsValidNumeroPedido(numeroPedido),"Númeor do pedido não é válido");
        }
    }
}
