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

    [Theory]
    [InlineData(120, 30)]
    [InlineData(100, 30)]
    public void RetornaDescontoMaximoQuandoValorDescontoMaiorOuIgualPreco(double desconto,
                                                                            double precoComDesconto)
    {
        Rota rota = new Rota("SaoPaulo", "Salvador");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double precoOriginal = 100.00;
        
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
        oferta.Desconto = desconto;

        Assert.Equal(precoComDesconto, oferta.Preco, 0.001);
    }

    [Theory]
    [InlineData(-120)]
    [InlineData(0)]
    public void RetornaPrecoOriginalQuandoValorDescontoMenorOuIgualAZero(double desconto)
    {
        Rota rota = new Rota("SaoPaulo", "Salvador");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double precoOriginal = 100.00;
        
        OfertaViagem oferta = new OfertaViagem(rota, periodo, precoOriginal);
        oferta.Desconto = desconto;

        Assert.Equal(precoOriginal, oferta.Preco, 0.001);
    }
}
