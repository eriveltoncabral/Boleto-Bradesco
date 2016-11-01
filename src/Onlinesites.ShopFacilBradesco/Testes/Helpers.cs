using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onlinesites.ShopFacilBradesco.Models.Requisicao;

namespace Testes
{
    public static class Helpers
    {
        public static BoletoRequisicao GeraRequisicaoBoleto()
        {
            var retorno = new BoletoRequisicao
            {
                MerchantId = "100006095",
                TokenRequestConfirmacaoPagamento = "abc123456789",
                ConfigBoletoRequisicao = GeraConfigRequisicao(),
                DadosComprador = GeraDadosComprador(),
                Pedido = GeraPedido()
            };

            return retorno;
        }

        public static BoletoConfigRequisicao GeraConfigRequisicao()
        {
            var retorno = new BoletoConfigRequisicao
            {
                Instrucoes = GeraInstrucoesPagamento() ,
                Registro = GeraInformacoesRegistro(),
                Beneficiario = "Nome Beneficiario",
                NossoNumero = "11122233344",
                DataEmissao = DateTime.Now,
                DataVencimento = DateTime.Now.AddDays(5),
                MensagemCabecalho = "Teste mensagem cabeçalho",
                Valor = "1500",
                Carteira = "26"
            };

            return retorno;
        }

        public static InstrucoesBoleto GeraInstrucoesPagamento()
        {
            var retorno = new InstrucoesBoleto
            {
                InstrucaoBoletoLinha1 = "Linha 01",
                InstrucaoBoletoLinha2 = "Linha 02",
                InstrucaoBoletoLinha3 = "Linha 03",
                InstrucaoBoletoLinha4 = "Linha 04",
                InstrucaoBoletoLinha5 = "Linha 05",
                InstrucaoBoletoLinha6 = "Linha 06",
                InstrucaoBoletoLinha7 = "Linha 07",
                InstrucaoBoletoLinha8 = "Linha 08",
                InstrucaoBoletoLinha9 = "Linha 09",
                InstrucaoBoletoLinha10 = "Linha 10",
                InstrucaoBoletoLinha11 = "Linha 11",
                InstrucaoBoletoLinha12 = "Linha 12",
            };
            return retorno;
        }

        public static RegistroBoleto GeraInformacoesRegistro()
        {
            var retorno = new RegistroBoleto();
         
            return retorno;
        }


        public static DadosPedidoRequisicao GeraPedido()
        {
            var retorno = new DadosPedidoRequisicao
            {
                Valor = "1500",
                Numero = "P8976_A98",
                Descricao = "Pedido na loja Boleto Bradesco"
            };

            return retorno;
        }

        public static DadosCompradorBoleto GeraDadosComprador()
        {
            var retorno = new DadosCompradorBoleto
            {
                UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36",
                Endereco = GeraEnderecoCompradorBoleto(),
                Nome = "Onlinesites Ltda",
                Ip = "127.0.0.1",
                Documento = "cpf ou cnpj"
            };

            return retorno;
        }

        public static EnderecoCompradorBoleto GeraEnderecoCompradorBoleto()
        {
            var retorno = new EnderecoCompradorBoleto
            {
                Numero = "123",
                Cidade = "Divinopolis",
                Logradouro = "Avenida Coronel Julio Ribeiro Gontijo",
                Bairro = "Esplanada",
                Cep = "35501000",
                Uf = "MG"
            };
            return retorno;
        }
    }
}
