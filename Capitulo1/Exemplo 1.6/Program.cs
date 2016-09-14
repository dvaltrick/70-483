using System;
using System.Threading;

//Inoicializando dados locais em uma Thread
namespace Exemplo_1._6
{
    public static class Program
    {
        //Define a variável _field utilizando a classe ThreadLocal para que seja possível inicializar
        //o valor conforme o tipo referenciado <int>;
        public static ThreadLocal<int> _field =
            new ThreadLocal<int>(() =>
            {
                //Utiliza o framework .Net para retornar informações da Thread em execução 
                return Thread.CurrentThread.ManagedThreadId;
            });
         
        public static void Main(string[] args)
        {
            new Thread(() =>
            {
                //Utiliza a proprieda .Value que irá retornar o valor conforme o método definido para a 
                //variável
                for (int i = 0; i <= _field.Value; i++)
                {
                    Console.WriteLine("Thread A: {0}", i);
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i <= _field.Value; i++)
                {
                    Console.WriteLine("Thread B: {0}", i);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
