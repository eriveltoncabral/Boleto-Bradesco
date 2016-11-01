using Newtonsoft.Json;

namespace Onlinesites.ShopFacilBradesco.Models.Resposta
{
    public class BoletoResposta
    {
        /// <summary>
        /// Identificador do estabelecimento fornecido pelo Bradesco
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        /// <summary>
        /// código do meio de pagamento
        /// </summary>
        [JsonProperty("meio_pagamento")]
        public string MeioPagamento { get; set; }

        /// <summary>
        /// Dados do boleto retornado pelo webservice
        /// </summary>
        [JsonProperty("boleto")]
        public BoletoBradesco Boleto { get; set; }

        /// <summary>
        /// Dados do status da requisição
        /// </summary>
        [JsonProperty("status")]
        public StatusRequisicao Status { get; set; }
    }
}
