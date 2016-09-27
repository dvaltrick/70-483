using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Usando BlockingCollection 
namespace Exemplo_1._28
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define uma BlockingCollection para que possa ser utilizada por duas Tasks diferentes, ao mesmo tempo
            //realizando tratamento de concorrência
            BlockingCollection<string> col = new BlockingCollection<string>();

            Task read = Task.Run(() =>
            {
                while (true)
                    Console.WriteLine(col.Take()); //Recebe argumento da coleção definida
            });

            Task write = Task.Run(() =>
            {
                while (true) {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);//Adiciona elemento a coleção
                }
            });

            write.Wait();
        }
    }
}
