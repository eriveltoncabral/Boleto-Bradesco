using System;
using Newtonsoft.Json;
using Onlinesites.ShopFacilBradesco.ExtensionsJson;
using Onlinesites.ShopFacilBradesco.Models.Contratos;
using System.Collections.Generic;

namespace Onlinesites.ShopFacilBradesco.Models.Requisicao
{
    /// <summary>
    /// Informações do cedente
    /// </summary>
    public class BoletoConfigRequisicao : IModelo
    {
        /// <summary>
        /// Nome do beneficiário / cedente
        /// </summary>
        [JsonProperty("beneficiario")]
        public string Beneficiario { get; set; } //150 chars

        /// <summary>
        /// Codigo da carteira (dois digitos)
        /// Exemplo: 26
        /// </summary>
        [JsonProperty("carteira")]
        public string Carteira { get; set; } // 2 chars

        /// <summary>
        /// Nosso número (identificador do boleto).
        /// O dígito será calculado pela plataforma do Bradesco deve ter 11 dígitos
        /// </summary>
        [JsonProperty("nosso_numero")]
        public string NossoNumero { get; set; } // 11 chars

        /// <summary>
        /// Data de emissão do boleto
        /// </summary>
        [JsonProperty("data_emissao")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DataEmissao { get; set; } //2016-03-01

        /// <summary>
        /// Data de vencimento do boleto
        /// </summary>
        [JsonProperty("data_vencimento")]
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DataVencimento { get; set; } //2016-03-01

        /// <summary>
        /// Valor do boleto para pagamento. Exemplo: 1500 Refere-se ao valor de R$ 15,00
        /// </summary>
        [JsonProperty("valor_titulo")]
        public string Valor { get; set; } 

        /// <summary>
        /// Url do logotio que será exibido no topo do boleto.
        /// Exemplo: https://onlinesites.com.br/downloads/lo1.png
        /// </summary>
        [JsonProperty("url_logotipo")]
        public string UrlLogo { get; set; } //url da logo do cliente limite maximo de 255 chars nao é obrigatorio

        /// <summary>
        /// Mensagem de cabeçalho exibida no topo do boleto
        /// </summary>
        [JsonProperty("mensagem_cabecalho")]
        public string MensagemCabecalho { get; set; } // 255 chars no máximo

        /// <summary>
        /// Tipo de renderização.
        /// Caso não seja enviado um valor será utilizado o valor configurado no Gerenciador do Lojista.
        /// </summary>
        [JsonProperty("tipo_renderizacao")]
        public byte TipoRenderizacao { get; set; }

        /// <summary>
        /// Informações de registro do boleto.
        /// </summary>
        [JsonProperty("registro")]
        public RegistroBoleto Registro { get; set; }

        /// <summary>
        /// Informações de instrução no boleto.
        /// </summary>
        [JsonProperty("instrucoes")]
        public InstrucoesBoleto Instrucoes { get; set; }
        
        #region Validações

        [JsonIgnore]
        public bool Valido => IsValid();

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(Beneficiario))
            {
                throw new Exception("Nome do beneficiário não pode estar vazio");
            }
            if (Beneficiario.Length > 150)
            {
                throw new Exception("Nome do beneficiário maior que 150 characteres");
            }

            if (Carteira.Length != 2)
            {
                throw new Exception("Carteira deve ter dois digitos");
            }

            if (NossoNumero.Length != 11)
            {
                throw new Exception("Nosso número deve ter 11 dígitos");
            }

            if (DataEmissao == null)
            {
                throw new Exception("É necessário informar uma data de emissão do boleto");
            }

            if (DataVencimento == null)
            {
                throw new Exception("É necessário informar uma data de vencimento para o boleto");
            }

            int valorBoleto;
            if (!int.TryParse(Valor, out valorBoleto) || valorBoleto <= 0)
            {
                throw new Exception("Valor do boleto não pode estar vazio ou ter um valor menor ou igual a zero");
            }

            if (!String.IsNullOrEmpty(UrlLogo) && UrlLogo.Length > 255)
            {
                throw new Exception("Url da logo não pode conter mais do que 255 caracteres");
            }

            if (!String.IsNullOrEmpty(MensagemCabecalho) && MensagemCabecalho.Length > 255)
            {
                throw new Exception("Mensagem do cabeçalho não pode conter mais do que 255 caracteres");
            }

            if (TipoRenderizacao > 2)
            {
                throw new Exception("Valor do tipo de renderização é inválido");
            }

         



            return Instrucoes.Valido;

        }

        #endregion
    }
}
