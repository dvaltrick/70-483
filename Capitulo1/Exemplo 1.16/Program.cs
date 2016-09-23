using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Usando a classe Parallel 
namespace Exemplo_1._16
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define um For onde todas as possibilidades são executadas de uma única vez em paralelo
            Parallel.For(0, 10, i => { Thread.Sleep(1000); Console.WriteLine(i); });

            var numbers = Enumerable.Range(0, 10);
            //Define um ForEach onde todas as possibilidades são executadas de uma única vez em paralelo
            Parallel.ForEach(numbers, i => { Thread.Sleep(1000); Console.WriteLine(i); });
        }
    }
}
