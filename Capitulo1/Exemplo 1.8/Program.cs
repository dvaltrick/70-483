using System;
using System.Threading;
using System.Threading.Tasks;

//Trabalhando com "tarefas" Task
namespace Exemplo_1._8
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Define uma Task, referenciando por expressão lamba o método a ser executado
            Task t = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++) {
                    Console.WriteLine("*");
                }
            });

            //O método Wait para a Task tem o mesmo efeito do método Join para Threads, ou seja agurada 
            //o término da execução da Thread
            t.Wait();

            Console.ReadLine();
        }
    }
}
