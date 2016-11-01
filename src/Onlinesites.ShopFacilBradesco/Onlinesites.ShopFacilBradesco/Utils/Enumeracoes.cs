using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlinesites.ShopFacilBradesco.Utils
{
    public static class Enumeracoes
    {
        enum TipoRenderizacao : byte
        {
            Html = 0,
            TelaComLinkPdf = 1,
            Pdf = 2
        }

        enum EndDebitoAutomatico : byte
        {
            EmiteAviso = 1,
            NaoEmiteAviso = 2
        }
    }
}
