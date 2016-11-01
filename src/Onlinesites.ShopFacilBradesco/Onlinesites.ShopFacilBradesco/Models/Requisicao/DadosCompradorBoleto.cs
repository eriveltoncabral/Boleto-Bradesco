using System;
using Newtonsoft.Json;
using Onlinesites.ShopFacilBradesco.Models.Contratos;
using Onlinesites.ShopFacilBradesco.Utils;

namespace Onlinesites.ShopFacilBradesco.Models.Requisicao
{
    public class DadosCompradorBoleto : IModelo
    {

        /// <summary>
        /// Nome do pagador/sacado
        /// </summary>
        [JsonProperty("nome")]
        public string Nome { get; set; }

        /// <summary>
        /// CPF ou CNPJ Informar somente números
        /// </summary>
        [JsonProperty("documento")]
        public string Documento { get; set; }

        /// <summary>
        /// Endereço IP do Comprador
        /// </summary>
        [JsonProperty("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// User agent do comprador
        /// </summary>
        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }

        /// <summary>
        /// Dados de endereço do comprador
        /// </summary>
        [JsonProperty("endereco")]
        public EnderecoCompradorBoleto Endereco { get; set; }



        #region Validações

        [JsonIgnore]
        public bool Valido => IsValid();

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(Nome) || Nome.Length > 40)
            {
                throw new Exception("Campo nome do comprador não pode estar vazio ou conter mais de 40 caracteres");
            }
            if (string.IsNullOrEmpty(Documento))
            {
                throw new Exception("Campo Documento do comprador não pode estar vazio");
            }
            int documentoInt;
            if (int.TryParse(Documento, out documentoInt))
            {
                throw new Exception("Campo Documento dcomprador deve conter apenas números");
            }

            if (!Helpers.IsValidCnpj(Documento) && !Helpers.IsValidCpf(Documento))
            {
                throw new Exception("Campo documento do comprador deve ser um cpf ou cnpj válido");
            }

            if (!string.IsNullOrEmpty(Ip) && (Ip.Length < 16 || Ip.Length > 50) && !Helpers.IsValidIPv4(Ip))
            {
                throw new Exception("Campo ip precisa de um IPv4 válido caso preenchido e conter entre 16 e 50 caracteres");
            }

            if (!string.IsNullOrEmpty(UserAgent) && UserAgent.Length > 255)
            {
                throw new Exception("Campo UserAgent não pode conter mais de 255 caracteres");
            }

            return Endereco.Valido;
        }

        #endregion
    }
}
