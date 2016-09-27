using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Ordenando uma Query processada em paralelo
namespace Exemplo_1._24
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 100);

            //Define array da query, utilizando Ordenação e Filtros
            var parallelResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0).ToArray();

            foreach (int i in parallelResult)
                Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
