using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Pegando as excessões geradas em paralelo
namespace Exemplo_1._27
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 20);

            //Utiliza a expressão try-catch para tratamento de excessões
            try
            {
                var parallelResult = numbers.AsParallel().Where(i => IsEven(i));

                parallelResult.ForAll(e => Console.WriteLine(e));
            }
            catch(AggregateException e) //Quando uma excessão ocorrer a variável e recebe a excessão
            {
                //Método para retornar a quantidade excessões que ocorreram
                Console.WriteLine("There were {0} exceptions", e.InnerExceptions.Count);
            }

            Console.ReadKey();
        }

        public static bool IsEven(int i) {
            //Força números divisores de 10 a retornar uma excessão
            if (i % 10 == 0) throw new ArgumentException("i");

            return i % 2 == 0;
        }
    }
}
