using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Trabalhando com PLINQ
//Parallel Language Integrated Query 
namespace Exemplo_1._22 //Exemplos 1.22 e 1.23
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define um array de números
            var numbers = Enumerable.Range(0, 100000);

            //Executa uma clausula WHERE para apenas apresentar números pares
            var parallelResult = numbers.AsParallel().Where(i => i % 2 == 0).ToArray();

            foreach (int i in parallelResult) {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
