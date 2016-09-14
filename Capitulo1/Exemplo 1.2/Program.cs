using System;
using System.Threading;

//Usando uma Thread em background
namespace Exemplo_1._2
{
    public static class Program
    {
        public static void MetodoDaThread() {
            for (int i = 0; i < 10; i++) {
                Console.WriteLine("Executou: {0}", i);
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            Thread t = new Thread(new ThreadStart(MetodoDaThread));

            //A propriedade IsBackground define se a Thread será executada em background ou em foreground
            //Quando ela está TRUE, ao abrir a rotina imediatamente ela é encerrada
            //Quando ela está FALSE, cada linha da Thread é apresentada com o sleep setado
            t.IsBackground = true;
            t.Start();

        }
    }
}
