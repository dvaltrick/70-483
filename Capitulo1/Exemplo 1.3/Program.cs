using System;
using System.Threading;

//Usando ParameterizedThreadStart 
namespace Exemplo_1._3
{
    public static class Program
    {
        //Recebe um parâmetro no método a ser executado pela Thread
        public static void ThreadMethod(object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("Executou: {0}", i);
                Thread.Sleep(0);
            }
        }

        public static void Main(string[] args)
        {
            //Define a Thread utilizando a classe ParameterizedThreadStart que possibilita a 
            //passagem de parâmetros para o método a ser executado pela Thread
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));

            //Passa os parâmetros necessário para a Thread
            t.Start(5);

            t.Join();

            Console.ReadLine();
        }
    }
}
