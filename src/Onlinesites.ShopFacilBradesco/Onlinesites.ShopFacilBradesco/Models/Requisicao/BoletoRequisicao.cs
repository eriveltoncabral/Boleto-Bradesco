using System;
using Newtonsoft.Json;
using Onlinesites.ShopFacilBradesco.Models.Contratos;

namespace Onlinesites.ShopFacilBradesco.Models.Requisicao
{
    /// <summary>
    /// Objeto para requisição junto ao webservice do Bradesco
    /// </summary>
    public class BoletoRequisicao : IModelo
    {
        /// <summary>
        /// Token enviado pela loja para ser utiliado como parametro adicional da url de confirmação do pedido.
        /// A url de confirmação do pedido é configurada no gerenciador do lojista.
        /// Verifique a documentação de integração para mais detalhes.
        /// </summary>
        [JsonProperty("token_request_confirmacao_pagamento")]
        public string TokenRequestConfirmacaoPagamento { get; set; }

        /// <summary>
        /// Identificador do estabelecimento fornecido pelo Bradesco
        /// Exemplo:
        /// 18022016Pedido_100_54878
        /// </summary>
        [JsonProperty("merchant_id")]
        public string MerchantId { get; set; }

        /// <summary>
        /// Valor fixo: 300  conforme especificado na documentação do Bradesco
        /// </summary>
        [JsonProperty("meio_pagamento")]
        public string MeioPagamento { get; set; } = "300";

        /// <summary>
        /// Dados do pedido
        /// </summary>
        [JsonProperty("pedido")]
        public DadosPedidoRequisicao Pedido { get; set; }

        /// <summary>
        /// Dados do pedido para gerar o boleto
        /// </summary>
        [JsonProperty("boleto")]
        public BoletoConfigRequisicao ConfigBoletoRequisicao { get; set; }

        /// <summary>
        /// Dados que identificam o comprador | dados do sacado
        /// </summary>
        [JsonProperty("comprador")]
        public DadosCompradorBoleto DadosComprador { get; set; }

        #region Validações

        [JsonIgnore]
        public bool Valido => IsValid();

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(MerchantId) || MerchantId.Length != 9)
            {
                throw new Exception("Identificador(Merchant Id) não pode ser nulo e deve conter 9 dígitos");
            }

            return Pedido.Valido && DadosComprador.Valido && ConfigBoletoRequisicao.Valido;
        }

        #endregion
    }
}
