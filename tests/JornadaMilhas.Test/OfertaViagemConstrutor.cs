using JornadaMilhasV1.Modelos;

namespace JornadaMilhas.Test
{
    public class OfertaViagemConstrutor
    {
        [Theory]
        [InlineData("", null, "2024-01-01", "2024-01-02", 0, false)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 100, true)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-01", 100, true)]
        [InlineData(null, "S�o Paulo", "2024-01-01", "2024-01-02", -1, false)]
        [InlineData("Vit�ria", "S�o Paulo", "2024-01-01", "2024-01-01", 0, false)]
        [InlineData("Rio de Janeiro", "S�o Paulo", "2024-01-01", "2024-01-02", -500, false)]
        public void RetornaEhValidoDeAcordoComDadosDeEntrada(string origem, string destino,
                                                            string dataIda, string dataVolta,
                                                            double preco, bool validacao)
        {
            //padr�o AAA
            //cen�rio - arrange
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));
            
            //a��o - act
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            //valida��o - assert
            Assert.Equal(validacao, oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDeRotaOuPeriodoInvalidosQuandoRotaNula()
        {
            Rota rota = null;
            Periodo periodo = new Periodo(new DateTime(2024, 2, 1), new DateTime(2024, 2, 5));
            double preco = 100.00;
            
            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A oferta de viagem n�o possui rota ou per�odo v�lidos.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemDeErroDeDataDeIdaInvalidaQuandoDataDeIdaMaiorQueVolta()
        {
            Rota rota = new Rota("SaoPaulo", "Salvador");
            Periodo periodo = new Periodo(new DateTime(2024, 6, 1), new DateTime(2024, 2, 5));
            double preco = 100.00;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("Erro: Data de ida n�o pode ser maior que a data de volta.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RetornaMensagemDeErroDeOrigemNulaOuVaziaDeAcordoComDadosDeEntrada(string origem)
        {
            Rota rota = new Rota(origem, "Salvador");
            Periodo periodo = new Periodo(new DateTime(2024, 1, 1), new DateTime(2024, 2, 5));
            double preco = 100.00;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A rota n�o pode possuir uma origem nula ou vazia.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RetornaMensagemDeErroDeDestinoNuloOuVazioDeAcordoComDadosDeEntrada(string destino)
        {
            Rota rota = new Rota("Sao Paulo", destino);
            Periodo periodo = new Periodo(new DateTime(2024, 1, 1), new DateTime(2024, 2, 5));
            double preco = 100.00;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("A rota n�o pode possuir um destino nulo ou vazio.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Theory]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", -100)]
        [InlineData("OrigemTeste", "DestinoTeste", "2024-02-01", "2024-02-05", 0)]
        public void RetornaMensagemDeErroDePrecoInvalidoDeAcordoComDadosDeEntrada(string origem, string destino,
                                                            string dataIda, string dataVolta,
                                                            double preco)
        {
            Rota rota = new Rota(origem, destino);
            Periodo periodo = new Periodo(DateTime.Parse(dataIda), DateTime.Parse(dataVolta));

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);

            Assert.Contains("O pre�o da oferta de viagem deve ser maior que zero.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]        
        public void RetornaMensagemDeErroDeOfertaInativaQuandoOfertaInativa()
        {
            Rota rota = new Rota("Sao Paulo", "Curitiba");
            Periodo periodo = new Periodo(new DateTime(2024, 1, 1), new DateTime(2024, 2, 5));
            double preco = 100.00;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco, false);

            Assert.Contains("A oferta de viagem est� inativa.", oferta.Erros.Sumario);
            Assert.False(oferta.EhValido);
        }

        [Fact]
        public void RetornaMensagemComADescricaoDaOfertaQuandoInvocadoToString()
        {
            Rota rota = new Rota("Sao Paulo", "Curitiba");
            Periodo periodo = new Periodo(new DateTime(2024, 1, 1), new DateTime(2024, 2, 5));
            double preco = 100.00;

            OfertaViagem oferta = new OfertaViagem(rota, periodo, preco);
            var descricaoOferta = $"Origem: {rota.Origem}, " +
                $"Destino: {rota.Destino}, " +
                $"Data de Ida: {periodo.DataInicial.ToShortDateString()}, " +
                $"Data de Volta: {periodo.DataFinal.ToShortDateString()}, Pre�o: {preco:C}";

            Assert.Contains(descricaoOferta, oferta.ToString());
            Assert.True(oferta.EhValido);
        }
    }
}