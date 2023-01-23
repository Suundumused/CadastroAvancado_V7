using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFuncionarios.Source.Public.Utils.HeadStyle
{
    public static class WellComeLine
    {
        private static double w = Console.WindowWidth;

        public static void init(ConsoleColor BorderColor, ConsoleColor TextColor, long LinesBetween, string Text) //Configurações de entrada da linha customizada.
        {
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

            long TextSize = Text.Length; // Obtendo o tamanho do texto customizado.

            Console.Clear();

            for (long i=0;  i< LinesBetween; i=i+1) //gerando bordas...
            {
                SpawnBorderA();
            }

            SpawnClearBorderA(); //borda com espaço...

            Console.Write(@$"|");
            
            for (long i = 0; i < w/2 - ((TextSize + 6) / 2); i = i + 1)
            {
                Console.Write(@$"="); //Continuação da linha, gerando borda em volta do texto.
            }

            Console.ForegroundColor = TextColor;



            Console.Write(" "+Text+" "); //Texto



            Console.ForegroundColor = BorderColor;

            for (long i = 0; i < w/2 - ((TextSize + 6)/2);i=i+1)
            {
                Console.Write(@$"="); //Continuação da linha, Continuação da linha, gerando borda em volta do texto.
            }
            Console.Write(@$"|");

            Console.WriteLine(@$"");

            SpawnClearBorderA(); //bordas com espaço...


            for (long i = 0; i < LinesBetween; i = i + 1) //gerando bordas inferiores...
            {
                SpawnBorderA();
            }

            Console.WriteLine(""); //saltando para a linha de baixo

            Console.ResetColor();

        }

    }
}
