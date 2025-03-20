using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Fact]
        public void RetornaOfertaValidaQuandoDadosValidos()
        {
            //padrão AAA
            //cenário - arrange
            Rota rota = new Rota("OrigemTeste", "DestinoTeste");
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.00;
            var validacao = true;

            //ação - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //validação - assert
            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.00;
            
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem não possui rota ou período válidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDeDataDeIdaInvalidaQuandoDataDeIdaMaiorQueVolta()
        {
            Rota rota = new Rota("SaoPaulo", "Salvador");
            Periodo periodo = new Periodo(new DateTime(2024, 6, 1), new DateTime(2024, 2, 5));
            double preco = 100.00;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("Erro: Data de ida não pode ser maior que a data de volta.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDeOrigemNulaOuVaziaQuandoOrigemNula()
        {
            Rota rota = new Rota(null, "Salvador");
            Periodo periodo = new Periodo(new DateTime(2024, 1, 1), new DateTime(2024, 2, 5));
            double preco = 100.00;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A rota não pode possuir uma origem nula ou vazia.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDePrecoInvalidoQuandoPrecoNegativo()
        {
            Rota rota = new Rota("Sao Paulo", "Salvador");
            Periodo periodo = new Periodo(new DateTime(2024, 1, 1), new DateTime(2024, 2, 5));
            double preco = -100.00;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("O preço da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }
    }
}