using System;
using System.Threading.Tasks;

//Anexando TaskFactory
namespace Exemplo_1._13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inicia uma Task que irá retornar um array de Int
            Task<Int32[]> parent = Task.Run(() => 
            {
                var results = new Int32[3];

                //Define TaskFactory, que permite criar diversar Tasks com a mesma configuração e 
                //anexa-las a um único pai
                TaskFactory tf = new TaskFactory(TaskCreationOptions.AttachedToParent, TaskContinuationOptions.ExecuteSynchronously);

                //Inicia 3 diferentes Task's
                tf.StartNew(() => results[0] = 0);
                tf.StartNew(() => results[1] = 1);
                tf.StartNew(() => results[2] = 2);

                return results;
            });

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
