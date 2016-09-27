using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Usando ConcurrentBag
//Trata-se de uma bolsa de itens
namespace Exemplo_1._30
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define a ConcurrentBag
            ConcurrentBag<int> bag = new ConcurrentBag<int>();

            //Adiciona itens a ConcurrentBag
            bag.Add(42);
            bag.Add(20);

            int result;
            
            //Utiliza TryTake para pegar o último elemento adicionado a BAG e remove-lo da coleção  
            if (bag.TryTake(out result))
                Console.WriteLine(result);

            //Utiliza TryPeek para pegar o último elemento adicionado a BAG sem que a BAG seja alterada.
            if (bag.TryPeek(out result))
                Console.WriteLine("Temos um próximo item {0}", result);

            Console.ReadKey();
        }
    }
}
