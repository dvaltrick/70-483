using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Enumerando uma ConcurrentBag
namespace Exemplo_1._31
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            Task.Run(() =>
            {
                bag.Add(42);
                Thread.Sleep(1000);
                bag.Add(21);
            });

            Task.Run(() =>
            {
                //Quando iniciamos a iteração com a bag os itens adicionados após o inicio não são considerados
                foreach (int i in bag)
                    Console.WriteLine(i);
            }).Wait();

            Console.ReadKey();
        }
    }
}
