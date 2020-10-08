using Deputados;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World");

            var conexao = new Correio.AtendeClienteClient();
            var endereco = conexao.consultaCEPAsync("05868750");

            System.Console.WriteLine();


            //var deputados = new Deputados.DeputadosSoapClient();
            //var deputado = deputados.ObterDeputadosAsync();

            //System.Console.WriteLine(deputado);


            System.Console.ReadKey();


        }
    }
}
