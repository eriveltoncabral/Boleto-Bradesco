using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Onlinesites.ShopFacilBradesco.Excecoes;
using Onlinesites.ShopFacilBradesco.Models.Requisicao;
using Onlinesites.ShopFacilBradesco.Models.Resposta;



namespace Onlinesites.ShopFacilBradesco.Api
{
    public class ClienteBoletoBradescoApi
    {
        public string ChaveSegura { get; private set; }
        public bool IsHomologacao { get; private set; }
        public string UrlRequisicao { get; private set; }

        private HttpClient _cliente;

        private const string UrlHomologacao = "https://homolog.meiosdepagamentobradesco.com.br/api/";
        private const string UrlProducao = "https://meiosdepagamentobradesco.com.br/api/";

        private const string _mediaType = "application/json";
        private const string _charSet = "UTF-8";
        /// <summary>
        /// Inicia o objeto de Cliente API
        /// </summary>
        /// <param name="chaveSegura">Chave de segurança do WebService do Bradesco</param>
        /// <param name="homologacao">Se a requisição será feita na produção ou homologação por padrão sempre é homologação</param>
        public ClienteBoletoBradescoApi(string chaveSegura, bool homologacao = true)
        {
            ChaveSegura = chaveSegura;
            IsHomologacao = homologacao;
            _cliente = new HttpClient();
            UrlRequisicao = IsHomologacao ? UrlHomologacao : UrlProducao;
        }

        
        
        /// <summary>
        /// Faz a solicitação junto a API do Bradesco.
        /// </summary>
        /// <param name="boleto">Requisição do boleto</param>
        /// <returns>Retorna a resposta do webservice</returns>
        public BoletoResposta Solicitar(BoletoRequisicao boleto)
        {
            try
            {
                if (!boleto.Valido)
                {
                    throw new Exception("Boleto não é válido");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Boleto não é válido. Consulte as exceções internas", ex);
            }

            var req = (HttpWebRequest)WebRequest.Create(UrlRequisicao + "transacao");
            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(boleto));
            //Configuracao do cabecalho da requisicao
            req.Method = "POST";
            req.ContentType = _mediaType + ";charset=" + _charSet;
            req.ContentLength = data.Length;
            req.Accept = _mediaType;
            req.Headers.Add(HttpRequestHeader.AcceptCharset, _charSet);
            

            //Credenciais de Acesso
            String header = boleto.MerchantId + ":" + ChaveSegura;
            String headerBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(header));
            req.Headers.Add(HttpRequestHeader.Authorization, "Basic " + headerBase64);
            req.GetRequestStream().Write(data, 0, data.Length);
            var response = (HttpWebResponse)req.GetResponse();
            if (response == null || response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
            {
                throw new BoletoApiException
                {
                    Codigo = response.StatusCode,
                    Source = "Erro na transação"
                };
            }

            var resposta = new BoletoResposta();

            var bodyResposta = response.GetResponseStream();
            //var strBody = bodyResposta.ToString();

            using (var reader = new StreamReader(bodyResposta))
            {
                var jsonretorno = reader.ReadToEnd();

                

                resposta = JsonConvert.DeserializeObject<BoletoResposta>(jsonretorno);
            }


            return resposta;
        }
        
    }
}
