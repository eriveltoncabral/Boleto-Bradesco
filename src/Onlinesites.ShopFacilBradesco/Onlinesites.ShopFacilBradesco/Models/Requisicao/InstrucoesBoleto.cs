using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Onlinesites.ShopFacilBradesco.Models.Contratos;

namespace Onlinesites.ShopFacilBradesco.Models.Requisicao
{
    public class InstrucoesBoleto : IModelo
    {
        #region Instruções Boleto

        /// <summary>
        /// Instrução linha 1
        /// </summary>
        [JsonProperty("instrucao_linha_1")]
        public string InstrucaoBoletoLinha1 { get; set; }

        /// <summary>
        /// Instrução linha 2
        /// </summary>
        [JsonProperty("instrucao_linha_2")]
        public string InstrucaoBoletoLinha2 { get; set; }

        /// <summary>
        /// Instrução linha 3
        /// </summary>
        [JsonProperty("instrucao_linha_3")]
        public string InstrucaoBoletoLinha3 { get; set; }

        /// <summary>
        /// Instrução linha 4
        /// </summary>
        [JsonProperty("instrucao_linha_4")]
        public string InstrucaoBoletoLinha4 { get; set; }

        /// <summary>
        /// Instrução linha 5
        /// </summary>
        [JsonProperty("instrucao_linha_5")]
        public string InstrucaoBoletoLinha5 { get; set; }

        /// <summary>
        /// Instrução linha 6
        /// </summary>
        [JsonProperty("instrucao_linha_6")]
        public string InstrucaoBoletoLinha6 { get; set; }

        /// <summary>
        /// Instrução linha 7
        /// </summary>
        [JsonProperty("instrucao_linha_7")]
        public string InstrucaoBoletoLinha7 { get; set; }

        /// <summary>
        /// Instrução linha 1
        /// </summary>
        [JsonProperty("instrucao_linha_8")]
        public string InstrucaoBoletoLinha8 { get; set; }

        /// <summary>
        /// Instrução linha 9
        /// </summary>
        [JsonProperty("instrucao_linha_9")]
        public string InstrucaoBoletoLinha9 { get; set; }

        /// <summary>
        /// Instrução linha 10
        /// </summary>
        [JsonProperty("instrucao_linha_10")]
        public string InstrucaoBoletoLinha10 { get; set; }

        /// <summary>
        /// Instrução linha 11
        /// </summary>
        [JsonProperty("instrucao_linha_11")]
        public string InstrucaoBoletoLinha11 { get; set; }

        /// <summary>
        /// Instrução linha 1
        /// </summary>
        [JsonProperty("instrucao_linha_12")]
        public string InstrucaoBoletoLinha12 { get; set; }

        #endregion



        #region Validações

        [JsonIgnore]
        public bool Valido => IsValid();

        private bool IsValid()
        {
            #region Instrução boleto

            if (!String.IsNullOrEmpty(InstrucaoBoletoLinha1) && InstrucaoBoletoLinha1.Length > 60)
            {
                throw new Exception("Linha de instrução 1 não pode conter mais de 60 caracteres");
            }

            if (!String.IsNullOrEmpty(InstrucaoBoletoLinha2) && InstrucaoBoletoLinha2.Length > 60)
            {
                throw new Exception("Linha de instrução 2 não pode conter mais de 60 caracteres");
            }

            if (!String.IsNullOrEmpty(InstrucaoBoletoLinha3) && InstrucaoBoletoLinha3.Length > 60)
            {
                throw new Exception("Linha de instrução 3 não pode conter mais de 60 caracteres");
            }

            if (!String.IsNullOrEmpty(InstrucaoBoletoLinha4) && InstrucaoBoletoLinha4.Length > 60)
            {
                throw new Exception("Linha de instrução 4 não pode conter mais de 60 caracteres");
            }

            if (!String.IsNullOrEmpty(InstrucaoBoletoLinha5) && InstrucaoBoletoLinha5.Length > 60)
            {
                throw new Exception("Linha de instrução 5 não pode conter mais de 60 caracteres");
            }

            if (!String.IsNullOrEmpty(InstrucaoBoletoLinha6) && InstrucaoBoletoLinha6.Length > 60)
            {
                throw new Exception("Linha de instrução 6 não pode conter mais de 60 caracteres");
            }

            if (!String.IsNullOrEmpty(InstrucaoBoletoLinha7) && InstrucaoBoletoLinha7.Length > 60)
            {
                throw new Exception("Linha de instrução 7 não pode conter mais de 60 caracteres");
            }

            if (!String.IsNullOrEmpty(InstrucaoBoletoLinha8) && InstrucaoBoletoLinha8.Length > 60)
            {
                throw new Exception("Linha de instrução 8 não pode conter mais de 60 caracteres");
            }

            if (!String.IsNullOrEmpty(InstrucaoBoletoLinha9) && InstrucaoBoletoLinha9.Length > 60)
            {
                throw new Exception("Linha de instrução 9 não pode conter mais de 60 caracteres");
            }

            if (!String.IsNullOrEmpty(InstrucaoBoletoLinha10) && InstrucaoBoletoLinha10.Length > 60)
            {
                throw new Exception("Linha de instrução 10 não pode conter mais de 60 caracteres");
            }

            if (!String.IsNullOrEmpty(InstrucaoBoletoLinha11) && InstrucaoBoletoLinha11.Length > 60)
            {
                throw new Exception("Linha de instrução 11 não pode conter mais de 60 caracteres");
            }

            if (!String.IsNullOrEmpty(InstrucaoBoletoLinha12) && InstrucaoBoletoLinha12.Length > 60)
            {
                throw new Exception("Linha de instrução 12 não pode conter mais de 60 caracteres");
            }

            #endregion

            return true;

        }

        #endregion
    }
}
