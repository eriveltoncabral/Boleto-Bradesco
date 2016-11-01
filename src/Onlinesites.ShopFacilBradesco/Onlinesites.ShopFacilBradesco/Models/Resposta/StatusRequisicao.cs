using Newtonsoft.Json;

namespace Onlinesites.ShopFacilBradesco.Models.Resposta
{
    public class StatusRequisicao
    {
        /// <summary>
        /// Código da mensagem de retorno - Ver tabela de códigos de retorno na documentação do Bradesco.
        /// </summary>
        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        /// <summary>
        /// Descritivo da mensagem de retorno
        /// </summary>
        [JsonProperty("mensagem")]
        public string Mensagem { get; set; }

        /// <summary>
        /// Apresentado quando houver um erro associado com a geração do boleto, com a finalidade de apresentar maiores
        /// informações a respeito do problema.
        /// </summary>
        [JsonProperty("detalhes")]
        public string Detalhes { get; set; } = string.Empty;
    }
}
