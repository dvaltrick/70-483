using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Parando um Looping com Parallel
namespace Exemplo_1._17
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define um objeto Parallel para receber um resultado
            //Executa um For com Parallel
            //Define objeto de estado para encerrar o looping
            ParallelLoopResult result = Parallel.For(0, 1000,
                (int i, ParallelLoopState loopState) =>
                {
                    Console.WriteLine(i);
                    if (i == 500) {
                        Console.WriteLine("Parando o loop..");
                        //Força a parada do Loop
                        loopState.Break();
                    }

                    return;
                });
        }
    }
}
