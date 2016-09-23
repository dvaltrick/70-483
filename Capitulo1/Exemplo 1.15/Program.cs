using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

//Usando Task.WaitAny
namespace Exemplo_1._15
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define array para armazenar as Tasks
            Task<int>[] tasks = new Task<int>[3];

            //Define as Tasks com tempos diferentes para exemplificar
            tasks[0] = Task.Run(() => { Thread.Sleep(2000); return 1; });
            tasks[1] = Task.Run(() => { Thread.Sleep(1000); return 2; });
            tasks[2] = Task.Run(() => { Thread.Sleep(4000); return 3; });

            //Enquanto ainda tiver uma Task para ser executada percorre
            while (tasks.Length > 0) {
                //Identifica o index da Task que terminou de executar
                int i = Task.WaitAny(tasks); 

                //Recebe a Task em uma variável auxiliar
                Task<int> completedTask = tasks[i];

                Console.WriteLine(completedTask.Result);

                //A lista de Tasks para uma variável auxiliar 
                var temp = tasks.ToList();
                //Remove a Task que já executou do array temporário
                temp.RemoveAt(i);
                //Devolve para o array principal o array temporário já sem a Task encerrada
                tasks = temp.ToArray();
            }
        }
    }
}
