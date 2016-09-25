using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Escalabilidade VS Responsividade
namespace Exemplo_1._19
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Executa();

            Console.ReadKey();
        }

        public static async void Executa()
        {
            await SleepAsyncA(5000);
            await SleepAsyncB(5000);
        }

        public static Task SleepAsyncA(int millisecondsTimeout) {
            //Executa um Sleep parando a execução da Thread
            return Task.Run(() => {
                Thread.Sleep(millisecondsTimeout);
                Console.WriteLine("Task 1");
            });
        }

        public static Task SleepAsyncB(int millisecondsTimeout) {
            //Nesse método por sua vez, a Thread não é ocupada enquanto o timer aguarda o tempo passado
            //O que gera um ganho de escalabilidade

            //Cria controle da Task
            TaskCompletionSource<bool> tcs = null;

            //Define Timer e delega função para ser executada por ele quando atingir o tempo
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);

            //Atribui ao controle o resultado do Timer
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);

            Console.WriteLine("Task 2");

            return tcs.Task; 
        }
    }
}
