using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlinesites.ShopFacilBradesco.Excecoes
{
    public class PropriedadeInvalidaException : Exception
    {
        public string Propriedade { get; set; }
        public string Mensagem { get; set; }
    }
}
