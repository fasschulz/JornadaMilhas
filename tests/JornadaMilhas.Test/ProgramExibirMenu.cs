using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JornadaMilhas.Test;

public class ProgramExibirMenu
{
    [Fact]
    public void RetornaMensagemDoMenuQuandoInvocadoExibirMenu()
    {
        StringWriter writer = new StringWriter();
        Console.SetOut(writer);

        Program.ExibirMenu();

        Assert.Equal("-------- Painel Administrativo - Jornada Milhas --------\r\n" +
                     "1. Cadastrar Ofertas\r\n" +
                     "2. Mostrar Todas as Ofertas\r\n" +
                     "3. Exibir maiores descontos\r\n" +
                     "4. Sair\r\n", 
                     writer.ToString());
    }
}
