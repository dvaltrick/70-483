using System;
using System.Threading;
using System.Threading.Tasks;

//Usando Task.WaitAll
namespace Exemplo_1._14
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define array para armazenar as tasks
            Task[] tasks = new Task[3];

            //Define tasks 
            tasks[0] = Task.Run(() => 
            {
                Thread.Sleep(10000);
                Console.WriteLine("1");
                return 1;
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(10000);
                Console.WriteLine("2");
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(10000);
                Console.WriteLine("3");
                return 3;
            });

            //Atribui o array de Tasks com todas as tarefas que devem finalizar para que o programa 
            //possa dar continuidade
            Task.WaitAll(tasks);
        }
    }
}
