using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Onlinesites.ShopFacilBradesco.Api;
using Onlinesites.ShopFacilBradesco.Models.Requisicao;
using bradescoB = Onlinesites.ShopFacilBradesco;

namespace Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesteDeCompradorCpf()
        {
            var compradorTeste = new bradescoB.Models.Requisicao.DadosCompradorBoleto
            {
                Documento = "31925789632",
                Endereco = new EnderecoCompradorBoleto
                {
                    Bairro = "Jardim Santo Elias",
                    Cep = "02010700",
                    Cidade = "Sao Paulo",
                    Complemento = "",
                    Logradouro = "Rua Domingos Sergio dos Anjos",
                    Numero = "277",
                    Uf = "SP"
                },
                Ip = "127.0.0.1",
                Nome = "Nome do comprador",
                UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36"
            };

            var jsonStr = JsonConvert.SerializeObject(compradorTeste);


            var strEsperado =
                "{\"nome\":\"Nome do comprador\",\"documento\":\"31925789632\",\"ip\":\"127.0.0.1\",\"user_agent\":\"Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36\",\"endereco\":{\"cep\":\"02010700\",\"logradouro\":\"Rua Domingos Sergio dos Anjos\",\"numero\":\"277\",\"complemento\":\"\",\"bairro\":\"Jardim Santo Elias\",\"cidade\":\"Sao Paulo\",\"uf\":\"SP\"}}";
            
            var compradorRecuperado = JsonConvert.DeserializeObject<bradescoB.Models.Requisicao.DadosCompradorBoleto>(jsonStr);

            //Verifica se os jsons são iguais
            Assert.AreEqual(strEsperado, jsonStr,"Formato do Json diferente esperado");

            //Verifica se o objeto de retorno é válido
            Assert.IsTrue(compradorRecuperado.Valido, "Não foi possível válidar o comprador");
        }

        [TestMethod]
        public void TesteDeCompradorCnpj()
        {
            var compradorTeste = new bradescoB.Models.Requisicao.DadosCompradorBoleto
            {
                Documento = "42975664000116",
                Endereco = new EnderecoCompradorBoleto
                {
                    Bairro = "Jardim Santo Elias",
                    Cep = "02010700",
                    Cidade = "Sao Paulo",
                    Complemento = "",
                    Logradouro = "Rua Domingos Sergio dos Anjos",
                    Numero = "277",
                    Uf = "SP"
                },
                Ip = "127.0.0.1",
                Nome = "Nome do comprador",
                UserAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36"
            };

            var jsonStr = JsonConvert.SerializeObject(compradorTeste);


            var strEsperado =
                "{\"nome\":\"Nome do comprador\",\"documento\":\"42975664000116\",\"ip\":\"127.0.0.1\",\"user_agent\":\"Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36\",\"endereco\":{\"cep\":\"02010700\",\"logradouro\":\"Rua Domingos Sergio dos Anjos\",\"numero\":\"277\",\"complemento\":\"\",\"bairro\":\"Jardim Santo Elias\",\"cidade\":\"Sao Paulo\",\"uf\":\"SP\"}}";

            var compradorRecuperado = JsonConvert.DeserializeObject<bradescoB.Models.Requisicao.DadosCompradorBoleto>(jsonStr);

            //Verifica se os jsons são iguais
            Assert.AreEqual(strEsperado, jsonStr, "Formato do Json diferente esperado");

            //Verifica se o objeto de retorno é válido
            Assert.IsTrue(compradorRecuperado.Valido, "Não foi possível válidar o comprador");
        }

        [TestMethod]
        public void TesteBoletoBasico()
        {
            var jsonEntrada = "{\"beneficiario\":\"Scopus\",\"carteira\":\"25\",\"nosso_numero\":\"99123456789\",\"data_emissao\":\"2016-03-01\",\"data_vencimento\":\"2016-03-05\",\"valor_titulo\":15000,\"url_logotipo\":\" http://scopus.com.br/img/scopus.png\",\"mensagem_cabecalho\":\"mensagem de cabecalho\",\"tipo_renderizacao\":\"2\",\"instrucoes\":{\"instrucao_linha_1\":\"instrucao 01\",\"instrucao_linha_2\":\"instrucao 02\",\"instrucao_linha_3\":\"instrucao 03\"}}";

            var objetoValidado = JsonConvert.DeserializeObject<bradescoB.Models.Requisicao.BoletoConfigRequisicao>(jsonEntrada);

            Assert.IsTrue(objetoValidado.Valido);            
        }


        [TestMethod]
        public void TesteRegistroBoleto()
        {
            const string jsonEntrada =
                "{\"agencia_pagador\": \"00014\",\"razao_conta_pagador\": \"07050\",\"conta_pagador\": \"12345679\",\"controle_participante\": \"Segurança arquivo remessa\",\"aplicar_multa\": true,\"valor_percentual_multa\": 1000,\"valor_desconto_bonificacao\": 1200,\"debito_automatico\": false,\"rateio_credito\": false,\"endereco_debito_automatico\": \"1\",\"tipo_ocorrencia\": \"02\",\"especie_titulo\": \"01\",\"primeira_instrucao\": \"00\",\"segunda_instrucao\": \"00\",\"valor_juros_mora\": 1000,\"data_limite_concessao_desconto\": \"2016-03-07\",\"valor_desconto\": 200,\"valor_iof\": 0,\"valor_abatimento\": 0,\"tipo_inscricao_pagador\": \"01\",\"sequencia_registro\": \"00001\"}";

            var objetoValidado = JsonConvert.DeserializeObject<bradescoB.Models.Requisicao.RegistroBoleto>(jsonEntrada);

            Assert.IsTrue(objetoValidado.Valido);
        }


        [TestMethod]
        public void TesteBoletoRequisicao()
        {
            const string jsonEntrada = "{\"merchant_id\":\"999888777\",\"meio_pagamento\":\"300\",\"pedido\":{\"numero\":\"0-9_A-Z_.MAX-27-CH99\",\"valor\":15000,\"descricao\":\"Descritivo do pedido\"},\"comprador\":{\"nome\":\"Nome do comprador/sacado\",\"documento\":\"42975664000116\",\"endereco\":{\"cep\":\"02010700\",\"logradouro\":\"Rua Domingos Sergio dos Anjos\",\"numero\":\"277\",\"complemento\":\"\",\"bairro\":\"Jardim Santo Elias\",\"cidade\":\"Sao Paulo\",\"uf\":\"SP\"},\"ip\":\"127.0.0.1\",\"user_agent\":\"User agent/browser do comprador\"},\"boleto\":{\"beneficiario\":\"Scopus\",\"carteira\":\"25\",\"nosso_numero\":\"99123456789\",\"data_emissao\":\"2016-03-01\",\"data_vencimento\":\"2016-03-05\",\"valor_titulo\":15000,\"url_logotipo\":\" http://scopus.com.br/img/scopus.png\",\"mensagem_cabecalho\":\"mensagem de cabecalho\",\"tipo_renderizacao\":\"2\",\"instrucoes\":{\"instrucao_linha_1\":\"instrucao 01\",\"instrucao_linha_2\":\"instrucao 02\",\"instrucao_linha_3\":\"instrucao 03\"},\"registro\":{\"agencia_pagador\":\"00014\",\"razao_conta_pagador\":\"07050\",\"conta_pagador\":\"12345679\",\"controle_participante\":\"Segurança arquivo remessa\",\"aplicar_multa\":true,\"valor_percentual_multa\":1000,\"valor_desconto_bonificacao\":1200,\"debito_automatico\":false,\"rateio_credito\":false,\"endereco_debito_automatico\":\"1\",\"tipo_ocorrencia\":\"02\",\"especie_titulo\":\"01\",\"primeira_instrucao\":\"00\",\"segunda_instrucao\":\"00\",\"valor_juros_mora\":1000,\"data_limite_concessao_desconto\":\"2016-03-07\",\"valor_desconto\":200,\"valor_iof\":0,\"valor_abatimento\":0,\"tipo_inscricao_pagador\":\"01\",\"sequencia_registro\":\"00001\"}},\"token_request_confirmacao_pagamento\":\"21323dsd23434ad12178DDasY\"}";

            var objetoValidado = JsonConvert.DeserializeObject<bradescoB.Models.Requisicao.BoletoRequisicao>(jsonEntrada);

            Assert.IsTrue(objetoValidado.Valido, "Não foi possível válidar o objeto");
        }


        [TestMethod]
        public void TesteRetornoBradesco()
        {
            const string jsonEntrada = "{\"merchant_id\":\"90000\",\"meio_pagamento\":\"800\",\"pedido\":{\"numero\":\"0-9_A-Z_.MAX-27-CH99\",\"valor\":15000,\"descricao\":\"Descritivo do pedido\"},\"boleto\":{\"valor_titulo\":15000,\"data_geracao\":\"2016-04-22T08:10:43\",\"data_atualizacao\":null,\"linha_digitavel\":\"23790000255123456789223000000002867240000015000\",\"linha_digitavel_formatada\":\"23790.00025 51234.567892 23000.000002 8 67240000015000\",\"token\":\"c3ZtRGVKRDFoUlRESmxRNnhKQnpJalFrb0VueXdVdUxnT2FVMG45cm1qMFMyRDcwRWZ0cFVBS0o0\nMFAxOHY0aTdJK3E1MXVjUVJjNEpBdUxvcE15T1E9PQ == \",\"url_acesso\":\"http://localhost:9080/boleto/titulo?token=c3ZtRGVKRDFoUlRESmxRNnhKQnpJalFrb0VueXdVdUxnT2FVMG45cm1qMFMyRDcwRWZ0cFVBS0o0\nMFAxOHY0aTdJK3E1MXVjUVJjNEpBdUxvcE15T1E9PQ ==\"},\"status\":{\"codigo\":0,\"mensagem\":\"OPERACAO REALIZADA COM SUCESSO\",\"detalhes\":null}}";

            var objetoValidado = JsonConvert.DeserializeObject<bradescoB.Models.Resposta.BoletoResposta>(jsonEntrada);

            Assert.AreEqual("90000", objetoValidado.MerchantId);
            Assert.AreEqual("800", objetoValidado.MeioPagamento);
            Assert.AreEqual("23790000255123456789223000000002867240000015000", objetoValidado.Boleto.LinhaDigitavel);
            Assert.AreEqual("23790.00025 51234.567892 23000.000002 8 67240000015000", objetoValidado.Boleto.LinhaDigitavelFormatada);
            Assert.AreEqual("http://localhost:9080/boleto/titulo?token=c3ZtRGVKRDFoUlRESmxRNnhKQnpJalFrb0VueXdVdUxnT2FVMG45cm1qMFMyRDcwRWZ0cFVBS0o0\nMFAxOHY0aTdJK3E1MXVjUVJjNEpBdUxvcE15T1E9PQ ==", objetoValidado.Boleto.UrlAcessoBoleto);

            Assert.AreEqual("15000", objetoValidado.Boleto.Valor);
            Assert.IsNull(objetoValidado.Boleto.DataAtualizacao);
            Assert.IsNotNull(objetoValidado.Boleto.DataProcessamento);

            Assert.AreEqual("0", objetoValidado.Status.Codigo);
            Assert.AreEqual("OPERACAO REALIZADA COM SUCESSO", objetoValidado.Status.Mensagem);
            Assert.IsNull(objetoValidado.Status.Detalhes);




        }

        
        //  Caso queira fazer um teste de uso com a api este teste abaixo está configurado para fazer a requisição.
        //  Basta adaptar o que é gerado para refletir as necessidades.

        //[TestMethod]
        //public void TesteApiCliente()
        //{
        //    var chaveSegura = "chave segura do painel";
        //    var apiCliente = new ClienteBoletoBradescoApi(chaveSegura);

            
        //    var boletoRequisicao = Helpers.GeraRequisicaoBoleto();

        //    var retorno = apiCliente.Solicitar(boletoRequisicao);

        //    var json = JsonConvert.SerializeObject(boletoRequisicao);

        //    Assert.IsNotNull(retorno);

        //    Assert.AreEqual("200",retorno.Status.Codigo);
        //}
    }
}
