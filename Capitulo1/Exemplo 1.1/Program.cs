using System;
using System.Threading; 

//Criando uma Thread com a classe Thread
namespace Exemplo_1._1
{
    public static class Program
    {
        //Método para ser utilizado pela thread secundária
        public static void ThreadMethod() {
            for (int i = 0; i <= 10; i++) {
                Console.WriteLine("Thread Proc {0}",i);
                Thread.Sleep(0); //Sinaliza o Windows que a Thread encerrou sua execução
            }
        }

        public static void Main(string[] args)
        {
            //Define uma thread t, passando como parâmetro para o Start o método criado anteriormente
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();

            //Executa código da thread principal
            for (int i =0 ; i < 4; i++) {
                Console.WriteLine("Main Thread: Do some work {0}", i);
                Thread.Sleep(0); //Sinaliza o Windows que a Thread encerrou sua execução
            }

            //O método Join() é utilizado para informar o bloco principal para aguardar o 
            //término da execução do bloco principal 
            t.Join(); 

            Console.ReadLine();
        }
    }
}
