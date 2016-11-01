
# Boleto Bradesco

## Desenvolvido por [Onlinesites](http://onlinesites.com.br)

Esta biblioteca foi desenvolvido para facilitar a integração com o serviço de boletos para e-commerce do Bradesco 

## Uso via Nuget
Instalar utilizando nuget
```
Install-Package Onlinesites.ShopFacilBradesco
```

## Exemplo de uso

```csharp
using System;
using Onlinesites.ShopFacilBradesco.Models.Requisicao;
namespace ExemploBoleto {
  public static class ExemploImplementacao{
    public static ExemploBoleto()
    {
      // Fazendo uso das classes de Helpers
      // do projeto de testes dentro da pasta src
      var requisicao = new BoletoRequisicao
      {
        MerchantId = "100006095",
        TokenRequestConfirmacaoPagamento = "abc123456789",
        ConfigBoletoRequisicao = GeraConfigRequisicao(),
        DadosComprador = GeraDadosComprador(),
        Pedido = GeraPedido()
      }
    }
  }  
}
```

## Contribuições
1. Crie um Fork
2. git clone https://github.com/(seu-usuario)/Boleto-Bradesco/
3. git checkout -b (nome-da-sua-funcionalidade) 
4. git add --all && git commit -m "Descrição do que foi feito"
5. git push origin (nome-da-sua-funcionalidade)
6. Crie um pull request

