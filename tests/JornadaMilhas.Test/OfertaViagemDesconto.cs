using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test;

public class OfertaViagemDesconto
{
    [Fact]
    public void RetornaPrecoAtualizadoQuandoAplicadoDesconto()
    {
        Rota rota = new Rota("SaoPaulo", "Salvador");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double precoOriginal = 100.00;
        double desconto = 20.00;
        double precoComDesconto = precoOriginal - desconto;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
        oferta.Desconto = desconto;

        Assert.Equal(precoComDesconto, oferta.Preco);
    }

    [Fact]
    public void RetornaDescontoMaximoQuandoValorDescontoMaiorQuePreco()
    {
        Rota rota = new Rota("SaoPaulo", "Salvador");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double precoOriginal = 100.00;
        double desconto = 120.00;
        double precoComDesconto = 30;

        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
        oferta.Desconto = desconto;

        Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
    }
}
