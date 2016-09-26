using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Usando ForAll
namespace Exemplo_1._26
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 50);
            var parallelResult = numbers.AsParallel().Where(i => i % 2 == 0);

            //Utiliza for all para executar uma ação para cada elemento contido na Query
            parallelResult.ForAll(e => Console.WriteLine(e));

            Console.ReadKey();
        }
    }
}
