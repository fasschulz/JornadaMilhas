using JornadaMilhasV1.Gerencidor;
using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test;

public class GerenciadorDeOfertasCadastrarOfertas
{
    [Fact]
    public void RetornaTrueQuandoAdicionaUmaOfertaCriadaNaLista()
    {
        var listaDeOfertas = new List<OfertaViagem>();
        var gerenciador = new GerenciadorDeOfertas(listaDeOfertas);
        Rota rota = new Rota("SaoPaulo", "Salvador");
        Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
        double preco = 100.00;
        
        var ofertaViagem = new OfertaViagem(rota, periodo, preco);

        Assert.True(gerenciador.AdicionarOfertaNaLista(ofertaViagem));
    }

    [Fact]
    public void RetornaFalseQuandoAdicionaUmaOfertaVaziaNaLista()
    {
        var listaDeOfertas = new List<OfertaViagem>();
        var gerenciador = new GerenciadorDeOfertas(listaDeOfertas);
        
        OfertaViagem? ofertaViagem = null;

        Assert.False(gerenciador.AdicionarOfertaNaLista(ofertaViagem));
    }
}
