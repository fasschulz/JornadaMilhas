using JornadaMilhasV1.Gerencidor;
using JornadaMilhasV1.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test;

public class GerenciadorDeOfertasCarregarOfertas
{
    [Fact]
    public void RetornaListaDeOfertasCadastradasNoSistemaQuandoInvocadoCarregarOfertas()
    {
        var listaDeOfertas = new List<OfertaViagem>();
        var gerenciador = new GerenciadorDeOfertas(listaDeOfertas);

        gerenciador.CarregarOfertas();

        Assert.Equal(3, listaDeOfertas.Count());
    }

    [Fact]
    public void RetornaNoConsoleTodasOfertasCadastradasQuandoInvocadoExibirTodasAsOfertas()
    {
        var listaDeOfertas = new List<OfertaViagem>();
        var gerenciador = new GerenciadorDeOfertas(listaDeOfertas);
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        gerenciador.CarregarOfertas();
        gerenciador.ExibirTodasAsOfertas();

        Assert.Equal("\nTodas as ofertas cadastradas: \r\n" +
                     "Origem: São Paulo, Destino: Curitiba, Data de Ida: 15/01/2024, Data de Volta: 20/01/2024, Preço: R$ 500,00\r\n" +
                     "Origem: Recife, Destino: Rio de Janeiro, Data de Ida: 10/02/2024, Data de Volta: 15/02/2024, Preço: R$ 700,00\r\n" +
                     "Origem: Acre, Destino: Brasília, Data de Ida: 05/03/2024, Data de Volta: 10/03/2024, Preço: R$ 600,00\r\n",
                     writer.ToString());
    }
}
