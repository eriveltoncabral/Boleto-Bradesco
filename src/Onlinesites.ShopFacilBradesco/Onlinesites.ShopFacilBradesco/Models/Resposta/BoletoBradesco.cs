using System;
using Newtonsoft.Json;

namespace Onlinesites.ShopFacilBradesco.Models.Resposta
{
    public class BoletoBradesco
    {
        /// <summary>
        /// Valor do título
        /// 1500 se refere ao valor de R$ 15,00
        /// </summary>
        [JsonProperty("valor_titulo")]
        public string Valor { get; set; }

        /// <summary>
        ///  Data de geração do título
        /// Formato ISO 8601
        /// </summary>
        [JsonProperty("data_geracao")]
        public DateTime DataProcessamento { get; set; }

        /// <summary>
        /// Data de atualização do título
        /// Nota: Caso o título tenha sido enviado anteriormente e o mesmo esteja apto a ser gerado, o registro será atualizado
        /// Formato ISO 8601
        /// </summary>
        [JsonProperty("data_atualizacao")]
        public DateTime? DataAtualizacao { get; set; }

        /// <summary>
        /// Linha digitável do boleto
        /// </summary>
        [JsonProperty("linha_digitavel")]
        public string LinhaDigitavel { get; set; }

        /// <summary>
        /// Linha digitável formatada
        /// </summary>
        [JsonProperty("linha_digitavel_formatada")]
        public string LinhaDigitavelFormatada { get; set; }

        /// <summary>
        /// Token identificador do boleto bancário gerado
        /// </summary>
        [JsonProperty("token")]
        public string Token { get; set; }

        /// <summary>
        /// Link de acesso ao boleto bancário
        /// </summary>
        [JsonProperty("url_acesso")]
        public string UrlAcessoBoleto { get; set; }
    }
}
