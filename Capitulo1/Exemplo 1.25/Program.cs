using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Utilizando Query Paralela Sequencial
namespace Exemplo_1._25
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 100);

            //Define array da query, utilizando Ordenação, filtros e utilizando 
            //o AsSequential para parar o processamento paralelo
            var parallelResult = numbers.AsParallel().AsOrdered()
                .Where(i => i % 2 == 0).AsSequential();

            //Utiliza Take() para pegar apenas um determinado número de elementos do array
            foreach (int i in parallelResult.Take(5))
                Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
