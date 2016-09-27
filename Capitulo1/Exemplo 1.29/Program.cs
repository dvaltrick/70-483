using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Usando GetConsumingEnumerable em uma BlockingCollection
namespace Exemplo_1._29
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
                //Utiliza método GetConsumingEnumerable para consumir o item da coleção
                foreach (string v in col.GetConsumingEnumerable())
                    Console.WriteLine(v); 
            });

            Task write = Task.Run(() =>
            {
                while (true)
                {
                    string s = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(s)) break;
                    col.Add(s);//Adiciona elemento a coleção
                }
            });

            write.Wait();
        }
    }
}
