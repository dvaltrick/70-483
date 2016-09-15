using System;
using System.Threading;

//Trabalhando com Thread Pool
namespace Exemplo_1._7
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Uma ThreadPool é utilizada para que não seja necessário criar uma Thread e reutilizar 
            //a mesma Thread, dessa forma é possível por exemplo evitar que atinja o limite de Threads
            //evitando assim que ocorram erros
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Trabalhando em uma Thread com ThreadPool... ");
            });

            Console.ReadLine();
        }
    }
}
