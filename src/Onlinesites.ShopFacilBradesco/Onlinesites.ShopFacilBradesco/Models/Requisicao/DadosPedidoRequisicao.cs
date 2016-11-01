using Newtonsoft.Json;
using Onlinesites.ShopFacilBradesco.Models.Contratos;
using Onlinesites.ShopFacilBradesco.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onlinesites.ShopFacilBradesco.Models.Requisicao
{
    public class DadosPedidoRequisicao : IModelo
    {
        /// <summary>
        /// Identificador do pedido na loja.
        /// Formato Alfanúmerico
        /// Ex.:  P8976_A98
        /// </summary>
        [JsonProperty("numero")]
        public string Numero { get; set; }

        /// <summary>
        /// Valor do pedido
        /// Exemplo: 1500 Refere-se ao valor de R$ 15,00
        /// </summary>
        [JsonProperty("valor")]
        public string Valor { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }


        //(^[A-Za-z0-9\\._]*\\d+[A-Zaz0-9\\._-]*$)
        #region Validações

        [JsonIgnore]
        public bool Valido => IsValid();

        private bool IsValid()
        {

            if (string.IsNullOrEmpty(Numero))
            {
                throw new Exception("Número do pedido não pode estar vazio");
            }

            if (!Helpers.IsValidNumeroPedido(Numero))
            {
                throw new Exception("Número do pedido não é válido. Consulte a documentação para mais informações");
            }

            if (string.IsNullOrEmpty(Valor))
            {
                throw new Exception("Valor do pedido não pode estar vazio");
            }

            int valorInt;

            if (!int.TryParse(Valor, out valorInt))
            {
                throw new Exception("Valor do produto deve ser um número");
            }

            if (string.IsNullOrEmpty(Descricao) || Descricao.Length > 255)
            {
                throw new Exception("Descrição do pedido não pode estar vazia nem pode conter mais do que 255 caracteres");
            }


            return true;

        }

        #endregion
    }
}
