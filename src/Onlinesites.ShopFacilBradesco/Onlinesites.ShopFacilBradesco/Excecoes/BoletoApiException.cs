using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Onlinesites.ShopFacilBradesco.Excecoes
{
    public class BoletoApiException : Exception
    {
        public HttpStatusCode Codigo { get; set; }
    }
}
