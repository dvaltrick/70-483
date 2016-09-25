using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//Usando ConfigureAwait para tratar erros 
namespace Exemplo_1._20 //Exemplo 1.20 e 1.21
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Evento de clique do botão
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            //Define um objeto HttpClient
            HttpClient httpClient = new HttpClient();

            //Executa GetStringAsync para buscar HTML da página
            string content = await httpClient.
                GetStringAsync("http://microsoft.com").
                ConfigureAwait(false);

            //--------Trecho referente ao Exemplo 1.21----------------------
            //Define bloco using para escrever o arquivo temporário
            using (FileStream sourceStream = new FileStream("temp.html",
                FileMode.Create, FileAccess.Write, FileShare.None,
                4096, useAsync: true))
            {
                //Codifica no formato de bytes o resultado da variável content
                byte[] encodedText = Encoding.Unicode.GetBytes(content);

                //Escreve no disco, no arquivo criado e referenciado no sourceStream
                await sourceStream.WriteAsync(encodedText, 0, encodedText.Length).
                    ConfigureAwait(false);
            }
            //--------------------------------------------------------------

            //Força erro setando o conteúdo buscado nessa Thread a Label que está
            //definida em outra Thread
            label.Content = content;
        }
    }
}
