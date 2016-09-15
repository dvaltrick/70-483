using System;
using System.Threading;
using System.Threading.Tasks;

//Adicionando uma continuação para a Task
namespace Exemplo_1._10
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Define a Task com retorno de resultado normalmente
            Task<int> t = Task.Run(() =>
            {
                return 42;
            }).ContinueWith((i) =>     //Chama o próximo método a ser executado pela Task, passando como
            {                          //parâmetro o objeto resultante da chamada anterior
                return i.Result * 2;   // Manipula resultado do método executado na primeira tarefa
            });

            Console.WriteLine(t.Result);

            Console.ReadKey();
        }
    }
}
