using System;
using System.Threading;

//Parando uma Thread
namespace Exemplo_1._4
{
    public static class Program
    {
        static void Main(string[] args)
        {
            //Define variável para controle de execução da Thread
            bool stopped = false;

            //Define Thread, delegando uma expressão lambda para execução da Thread
            Thread t = new Thread(new ThreadStart(() => 
            {
                //Dessa forma, até que a variuável stopped receba o valor TRUE a Thread continuara 
                //sendo executada
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);

                }
            }));

            t.Start();

            Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadKey();

            stopped = true;
            t.Join();
        }
    }
}
