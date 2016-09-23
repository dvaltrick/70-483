using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

//Usando métodos asincronos com async e await
namespace Exemplo_1._18
{
    class Program
    {
        static void Main(string[] args)
        {
            //Seta Result da Task retornada pelo método para uma String 
            string result = DownloadContent().Result;
            Console.WriteLine(result);

            Console.ReadKey();
        }

        //Define metodo Task para ser executado de forma asincrona
        public static async Task<String> DownloadContent() {
            //Inicia espaço para conexão HTTP
            using (HttpClient cliente = new HttpClient()) {
                //Utiliza await para aguardar resultado da chamada via Http do site Microsoft
                String result = await cliente.GetStringAsync("http://microsoft.com");
                return result;
            }

        }
    }
}
