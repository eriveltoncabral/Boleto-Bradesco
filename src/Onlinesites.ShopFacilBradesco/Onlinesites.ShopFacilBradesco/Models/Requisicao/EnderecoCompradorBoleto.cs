using System;
using Newtonsoft.Json;
using Onlinesites.ShopFacilBradesco.Models.Contratos;

namespace Onlinesites.ShopFacilBradesco.Models.Requisicao
{
    public class EnderecoCompradorBoleto : IModelo
    {
        /// <summary>
        /// Cep apenas números
        /// </summary>
        [JsonProperty("cep")]
        public string Cep { get; set; }

        /// <summary>
        /// Logradouro do comprador
        /// </summary>
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        /// <summary>
        /// Número do endereço
        /// </summary>
        [JsonProperty("numero")]
        public string Numero { get; set; }

        /// <summary>
        /// Campo de complemento para o endereço
        /// </summary>
        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        /// <summary>
        /// Bairro do comprador
        /// </summary>
        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        /// <summary>
        /// Campo cidade do comprador
        /// </summary>
        [JsonProperty("cidade")]
        public string Cidade { get; set; }

        /// <summary>
        /// Uf do comprador
        /// </summary>
        [JsonProperty("uf")]
        public string Uf { get; set; }


        #region Validações

        [JsonIgnore]
        public bool Valido => IsValid();

        private bool IsValid()
        {

            if (Cep.Length != 8)
            {
                throw new Exception("Campo cep do comprador deve ter apenas números e ter comprimento de 8 caracteres");
            }
            if (string.IsNullOrEmpty(Logradouro) || Logradouro.Length > 70)
            {
                throw new Exception("Campo logradouro do comprador não pode estar vazio e deve conter no máximo 70 caracteres");
            }
            if (string.IsNullOrEmpty(Numero) || Numero.Length > 10)
            {
                throw new Exception("Campo número do endereço do comprador não pode estar vazio ou conter mais de 10 caracteres");
            }
            if (!string.IsNullOrEmpty(Complemento) && Complemento.Length > 20)
            {
                throw new Exception("Campo complemento do endereço do comprador não pode conter mais de 20 caracteres");
            }
            if (string.IsNullOrEmpty(Bairro) || Bairro.Length > 50)
            {
                throw new Exception("Campo bairro do comprador não pode estar vazio ou conter mais de 50 caracteres");
            }
            if (string.IsNullOrEmpty(Cidade) || Cidade.Length > 50)
            {
                throw new Exception("Campo cidade do comprador não pode estar vazio ou conter mais de 50 caracteres");
            }
            if (string.IsNullOrEmpty(Uf) || Uf.Length != 2)
            {
                throw new Exception("Campo uf do comprador não pode estar vazio e deve conter 2 caracteres");
            }


            return true;
        }

        #endregion
    }
}
