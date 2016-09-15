using System;
using System.Threading.Tasks;

//Agendando continuações para a Task, que podem ser executadas apenas quando algum evento
//ocorra com a Task
 namespace Exemplo_1._11
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            //Agenda continuação para a Task que será executado apenas quando a Task for cancelada
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Cancelado... ");
            },TaskContinuationOptions.OnlyOnCanceled);

            //Agenda continuação para a Task que será executada apenas quando ocorrer um problema
            //na execução da Task
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Problema...");
            },TaskContinuationOptions.OnlyOnFaulted);

            //Agenda continuação para a Task que será executada quando o processamento chegar ao fim
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Completa...");
            },TaskContinuationOptions.OnlyOnRanToCompletion);


            Console.ReadKey();

            t.Wait();
        }
    }
}
