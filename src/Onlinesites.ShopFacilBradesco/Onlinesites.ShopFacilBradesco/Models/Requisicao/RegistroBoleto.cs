using System;
using Newtonsoft.Json;
using Onlinesites.ShopFacilBradesco.Models.Contratos;

namespace Onlinesites.ShopFacilBradesco.Models.Requisicao
{
    /// <summary>
    /// Funcionalidade de registro. Este atributo pode ser enviado como nulo
    /// </summary>
    public class RegistroBoleto : IModelo
    {
        /// <summary>
        /// Agencia ( c/ dígito) Pgador
        /// Exemplo 14
        /// </summary>
        [JsonProperty("agencia_pagador")]
        public string AgenciaPagador { get; set; }

        /// <summary>
        /// Razão da Conta Corrente Pagador
        /// Exempo: 7050
        /// </summary>
        [JsonProperty("razao_conta_pagador")]
        public string RazaoContaPagador { get; set; }

        /// <summary>
        /// Conta (c/ dígito) Pagador
        /// Exemplo: 123456789
        /// </summary>
        [JsonProperty("conta_pagador")]
        public string ContaPagador { get; set; }


        /// <summary>
        /// Nº Controle do Participante.
        /// A informação que constar do Arquivo Remessa será confirmada no Arquivo Retorno,
        ///  Não será impresso nos boletos de cobrança. Exemplo: Segurança arquivo remessa
        /// </summary>
        [JsonProperty("controle_participante")]
        public string ControleParticipante { get; set; }

        /// <summary>
        /// Informa se deve ser aplicada multa
        /// Default = False
        /// </summary>
        [JsonProperty("aplicar_multa")]
        public bool AplicarMulta { get; set; } = false;

        /// <summary>
        /// Valor do percentual
        /// Exemplo 200 se refere ao valor de 2,00%
        /// </summary>
        [JsonProperty("valor_percentual_multa")]
        public string ValorPercentualMulta { get; set; }

        /// <summary>
        /// Valor de desconto de bonificação
        /// Exemplo 1500 se refere ao valor de R$ 15,00
        /// </summary>
        [JsonProperty("valor_desconto_bonificacao")]
        public string ValorDescontoBonificacao { get; set; }

        /// <summary>
        /// Identifica se emite o boleto para débito automático
        /// </summary>
        [JsonProperty("debito_automatico")]
        public bool DebitoAutomatico { get; set; } = false;

        /// <summary>
        /// Indicador de Rateio de crédito
        /// </summary>
        [JsonProperty("rateio_credito")]
        public bool RateioCredito { get; set; } = false;

        /// <summary>
        /// Endereçamento para aviso do débito automático em contacorrente
        /// 1 = emite aviso, e assume o endereço do Pagador;
        /// 2 = não emite aviso;
        /// Diferente de 1 ou 2 = emite e assume o endereço de cadastro do Banco.
        /// </summary>
        [JsonProperty("endereco_debito_automatico")]
        public byte EnderecoDebitoAutomatico { get; set; }

        /// <summary>
        /// Identificação da ocorrência
        /// </summary>
        [JsonProperty("tipo_ocorrencia")]
        public string TipoOcorrencia { get; set; }

        /// <summary>
        /// Especie do título
        /// </summary>
        [JsonProperty("especie_titulo")]
        public string EspecieTitulo { get; set; }

        /// <summary>
        /// 1º Instrução
        /// 00-Caso não queira protesto do Título ou a baixa por decurso de prazo;
        /// 06= Protestar;
        /// 07=Negativar.
        /// </summary>
        [JsonProperty("primeira_instrucao")]
        public string PrimeiraInstrucao { get; set; }

        /// <summary>
        /// 2º Instrução
        /// 00=Caso não queira protesto do Título ou a baixa por decurso de prazo;
        /// Ou indicar o número de dias a protestar(mínimo 5 dias)
        /// </summary>
        [JsonProperty("segunda_instrucao")]
        public string SegundaInstrucao { get; set; }

        /// <summary>
        /// Juros de mora - Valor a ser cobrado por dias de atraso
        /// Exemplo: 1500 Refere-se ao valor de R$ 15,00
        /// </summary>
        [JsonProperty("valor_juros_mora")]
        public string ValorJurosMora { get; set; }

        /// <summary>
        /// Data limite para conceder desconto
        /// </summary>
        [JsonProperty("data_limite_concessao_desconto")]
        public DateTime DataLimiteConcessaoDesconto { get; set; }

        /// <summary>
        /// Valor do desconto
        /// Exemplo 1500 refere-se ao valor de R$ 15,00
        /// </summary>
        [JsonProperty("valor_desconto")]
        public string ValorDesconto { get; set; }

        /// <summary>
        /// Este campo somente deverá ser preenchido pelas Empresas Beneficiárias, 
        /// cujo ramo de atividade seja Administradora de Seguros.
        /// Exemplo: 1500 Refere-se ao valor de R$ 15,00

        /// </summary>
        [JsonProperty("valor_iof")]
        public string ValorIof { get; set; }

        /// <summary>
        /// Valor do Abatimento a ser concedido ou cancelado
        /// Exemplo: 1500 Refere-se ao valor de R$ 15,00
        /// </summary>
        [JsonProperty("valor_abatimento")]
        public string ValorAbatimento { get; set; }

        /// <summary>
        /// Identificação do Tipo de Inscrição do Pagador 
        /// 01=CPF;
        /// 02=CNPJ;
        /// 03=PIS/PASEP;
        /// 98=Não tem;
        /// 99=Outros.
        /// </summary>
        [JsonProperty("tipo_inscricao_pagador")]
        public string TipoInscricaoPagador { get; set; }

        /// <summary>
        /// Número Sequencial do Registro
        /// </summary>
        [JsonProperty("sequencia_registro")]
        public string SequenciaRegistro { get; set; }

        #region Validações

        [JsonIgnore]
        public bool Valido => IsValid();

        private bool IsValid()
        {
            if (!string.IsNullOrEmpty(AgenciaPagador) && AgenciaPagador.Length > 5)
            {
                throw new Exception("Agencia Pagador não pode ter mais de 5 dígitos");
            }
            if (!string.IsNullOrEmpty(RazaoContaPagador) && RazaoContaPagador.Length > 5)
            {
                throw new Exception("Razao conta pagador não pode conter mais de 5 dígitos");
            }
            if (!string.IsNullOrEmpty(ContaPagador) && ContaPagador.Length > 8)
            {
                throw new Exception("Razao conta pagador não pode conter mais de 8 dígitos");
            }
            if (!string.IsNullOrEmpty(ControleParticipante) && ControleParticipante.Length > 25)
            {
                throw new Exception("Número de controle participante não pode conter mais de 25 caracteres");
            }
            int valorPercentualMulta;
            if (!string.IsNullOrEmpty(ValorPercentualMulta)
                && (ValorPercentualMulta.Length > 4 || !int.TryParse(ValorPercentualMulta, out valorPercentualMulta)))
            {
                throw new Exception("Valor do percentual não pode ter mais de 4 dígitos e deve ser um número");
            }

            int valorBonificacaoDesconto;
            if (!string.IsNullOrEmpty(ValorDescontoBonificacao)
                && (ValorDescontoBonificacao.Length > 10 || !int.TryParse(ValorDescontoBonificacao, out valorBonificacaoDesconto)))
            {
                throw new Exception("Valor do desconto bonificação não pode ter mais de 10 dígitos e deve ser um número");
            }

            if (EnderecoDebitoAutomatico > 2)
            {
                throw new Exception("Endereço débito automatico é inválido");
            }

            if (!string.IsNullOrEmpty(TipoOcorrencia) && TipoOcorrencia.Length > 3)
            {
                throw new Exception("Tipo de ocorrência não pode conter mais de 3 dígitos verifique a documentação");
            }

            if (!string.IsNullOrEmpty(EspecieTitulo) && EspecieTitulo.Length > 2)
            {
                throw new Exception("Especie do título não pode conter mais de dois dígitos");
            }
            if (!string.IsNullOrEmpty(PrimeiraInstrucao) && PrimeiraInstrucao.Length > 2)
            {
                throw new Exception("Primeira Instrução não pode conter mais de dois dígitos");
            }
            if (!string.IsNullOrEmpty(SegundaInstrucao) && SegundaInstrucao.Length > 2)
            {
                throw new Exception("Primeira Instrução não pode conter mais de dois dígitos");
            }
            int valorJurosMora;
            if (!string.IsNullOrEmpty(ValorJurosMora)
                && (ValorJurosMora.Length > 13 || !int.TryParse(ValorJurosMora, out valorJurosMora)))
            {
                throw new Exception("Valor de juros e mora não pode conter mais de 13 caracteres e deve ser um número");
            }

            int valorDesconto;
            if (!string.IsNullOrEmpty(ValorDesconto)
                && (ValorDesconto.Length > 13 || !int.TryParse(ValorDesconto, out valorDesconto)))
            {
                throw new Exception("Valor de desconto não pode conter mais de 13 caracteres e deve ser um número");
            }

            int valorIof;
            if (!string.IsNullOrEmpty(ValorIof)
                && (ValorIof.Length > 13 || !int.TryParse(ValorIof, out valorIof)))
            {
                throw new Exception("Valor de desconto não pode conter mais de 13 caracteres e deve ser um número");
            }

            int valorAbatimento;
            if (!string.IsNullOrEmpty(ValorAbatimento)
                && (ValorAbatimento.Length > 13 || !int.TryParse(ValorAbatimento, out valorAbatimento)))
            {
                throw new Exception("Valor de abatimento não pode conter mais de 13 caracteres e deve ser um número");
            }

            if (!string.IsNullOrEmpty(TipoInscricaoPagador) && TipoInscricaoPagador.Length > 2)
            {
                throw new Exception("Tipo de inscrição pagador não pode conter mais de 2 dígitos");
            }

            int sequencialRegistro;
            if (!string.IsNullOrEmpty(SequenciaRegistro)
                && (SequenciaRegistro.Length > 13 || !int.TryParse(SequenciaRegistro, out sequencialRegistro)))
            {
                throw new Exception("Sequencial Registro não pode conter mais de 13 caracteres e deve ser um número");
            }



            return true;
        }

        #endregion
    }
}
