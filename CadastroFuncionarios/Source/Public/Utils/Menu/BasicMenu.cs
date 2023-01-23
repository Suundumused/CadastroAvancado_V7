using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFuncionarios.Source.Public.Utils.Menu
{
    public static class BasicMenu
    {
        private static double w = Console.WindowWidth;

        public static System.ConsoleKeyInfo init(ConsoleColor BorderColor, ConsoleColor TextColor, long LinesBetween, string Title, List<string> Options) // Configurações de entrada do menu.
        {
            System.ConsoleKeyInfo optionSelected; //gerando variável para armazenar chave do teclado.

            void SpawnBorderA() //Declaração do Gerador de bordas |=========| com base na largura do console.
            {
                Console.ForegroundColor = BorderColor;

                Console.Write("|");

                for (long i = 0; i < w - 2; i = i + 1)
                {
                    Console.Write("=");
                }
                Console.Write("|");
                Console.WriteLine();

            }

            void SpawnClearBorderA() //Declaração do gerador de bordas |         | com base na largura do console.
            {
                Console.ForegroundColor = BorderColor;

                Console.Write("|");

                for (long i = 0; i < w - 2; i = i + 1)
                {
                    Console.Write(" ");
                }
                Console.Write("|");
                Console.WriteLine();

            }

            long TextSize = Title.Length; // Obtendo o tamanho do título customizado.

            Console.Clear();

            for (long i = 0; i < LinesBetween; i = i + 1) //gerando bordas...
            {
                SpawnBorderA();
            }

            SpawnClearBorderA(); //gerando borda com espaço...

            Console.Write("|");

            for (long i = 0; i < w / 2 - ((TextSize + 5) / 2); i = i + 1)
            {
                Console.Write(@$"="); //Continuação da linha
            }

            Console.ForegroundColor = TextColor;

            Console.Write(" " + Title + " "); //TÍTULO DO MENU

            Console.ForegroundColor = BorderColor;

            for (long i = 0; i < w / 2 - ((TextSize + 5) / 2); i = i + 1)
            {
                Console.Write(@$"="); //Continuação da linha, gerando borda em volta do texto.
            }

            Console.Write(@$"|");

            Console.WriteLine(@$"");

            SpawnClearBorderA(); //gerando borda com espaço...
            SpawnClearBorderA();


            foreach (var X in Options) //distribuindo linhas de opções no container...
            {
                long MenuTextSize = X.Length;

                Console.Write(@$"|");

                for (long i = 0; i < w/2 - ((MenuTextSize+5) / 2); i = i + 1)
                {
                    Console.Write(@$"="); //Continuação da linha
                }

                Console.ForegroundColor = TextColor;

                Console.Write(" " + X + " "); //Texto da opção atual

                Console.ForegroundColor = BorderColor;

                for (long i = 0; i < w/2 - ((MenuTextSize+5) / 2); i = i + 1)
                {
                    Console.Write(@$"="); //Continuação da linha
                }

                Console.Write(@$"|");
                SpawnClearBorderA();

            }


            for (long i = 0; i < LinesBetween; i = i + 1) //gerando boradas...
            {
                SpawnBorderA();
            }

            Console.WriteLine("");

            Console.ResetColor();

            Console.Write("> ");

            optionSelected = Console.ReadKey(); //capturando e salvando chave pressionada pelo usuário.

            return optionSelected; //retornando chave na variável.

        }

    }
}
