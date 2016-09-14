using System;
using System.Threading;

//Usando o atributo ThreadStatic - ThreadStaticAttribute
namespace Exemplo_1._5
{
    public static class Program
    {
        //A definição do atributo ThreadStatic antes da variável _field, garante que o valor dela será 
        //estático dentro da Thread que está sendo executada, ou seja, quando manipulado na Thread B 
        //o valor não é alterado na A, e vice versa;
        [ThreadStatic]
        public static int _field;

        public static void Main(string[] args)
        {
            new Thread(() =>
            {
                for (int i = 0; i <= 10; i++) {
                    _field++;
                    Console.WriteLine("Thread A: {0}", _field);
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i <= 10; i++) {
                    _field++;
                    Console.WriteLine("Thread B: {0}", _field);
                }
            }).Start();

            Console.ReadKey();
        }
    }
}
