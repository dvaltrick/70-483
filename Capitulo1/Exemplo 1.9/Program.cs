using System;
using System.Threading;
using System.Threading.Tasks;

//Usando Task e retornando valor
namespace Exemplo_1._9
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Define uma Task definindo o tipo que será retornado pelo método referenciado
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });

            //Utiliza a propriedade Result para apresentar o retorno da Task
            //OBS: Se a propriedade Result for chamada, porém a Task não tenha encerrado sua execução
            //O programa ficará parado nesse ponto até que a Task finalize sua execução para que então
            //a propriedade Result possa ser utilizada e o programa continuar novamente 
            Console.WriteLine(t.Result);

            Console.ReadKey();
        }
    }
}
