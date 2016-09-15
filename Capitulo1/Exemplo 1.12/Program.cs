using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Anexando Tasks filhas a Tasks pais
namespace Exemplo_1._12
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Define uma Task pai, que irá retornar um array de int
            Task<Int32[]> parent = Task.Run(() =>
            {
                var results = new Int32[3];

                //Anexa uma Task filha a Task pai e executa
                new Task(() =>
                {
                    results[0] = 0;
                },TaskCreationOptions.AttachedToParent).Start();

                //Anexa uma Task filha a Task pai e executa
                new Task(() =>
                {
                    results[1] = 1;
                }, TaskCreationOptions.AttachedToParent).Start();

                //Anexa uma Task filha a Task pai e executa
                new Task(() =>
                {
                    results[2] = 2;
                }, TaskCreationOptions.AttachedToParent).Start();

                return results;
            });

            //Define uma Task para ser executada apenas quando a primeira Task tiver sido encerrada
            //sendo que a Task anterior só será encerrada quando as 3 Tasks filhas tiverem encerradas
            var finalTask = parent.ContinueWith(
                    parentTask => {
                        foreach (int i in parentTask.Result)
                            Console.WriteLine(i);
                    });

            finalTask.Wait();

            Console.ReadKey();
        }
    }
}
