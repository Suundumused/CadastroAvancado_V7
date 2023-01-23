using CadastroFuncionarios.Source.Public.Interfaces.Instancia.iPessoa;
using CadastroFuncionarios.Source.Public.Utils.HeadStyle;
using CadastroFuncionarios.Source.Public.Utils.Menu;
using CadastroFuncionarios.Source.Public.Utils.Pessoas;
using CadastroFuncionarios.Source.Public.Utils.FileCHK;

using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CadastroFuncionarios.Source.Internal.Class.Pessoa
{
    internal class Pessoa : iPessoa
    {

        private List<string> menu1 = new List<string> { "" }; //declarando variável menu

        public List<string> Pessoas { get; set; } = new List<string>(); //usado para armazenar todos os usuários.

        private static string Path { get;} = "Saves/Pessoas.csv"; //caminho do arquivo de Save.

        public void init() //declaração (é chamada no início).
        {
            if (CHKFolder.VerFile(Path) == false) //Verifica pasta do save.
            {
                Mkdir.Mkdir_0(Path);    //cria pasta do save.
                Console.WriteLine("SemPasta");
            }

            if (CHKFile.CHKFile_0(Path) == false) //verifica arquivo Pessoas.csv
            {
                MkFile.MkFile_0(Path); //cria arquivo Pessoas.csv
                Console.WriteLine("SemArquivo");
            }

            WellComeLine.init(BorderColor: ConsoleColor.Magenta, ConsoleColor.White, 3, @$"CADASTRO DE FUNCIONÁRIOS "); // Saudações.

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Pressione qualquer tecla para contunuar.");
            Console.WriteLine();

            Console.ResetColor();                //Limpa e interrompe o terminal enquanto aguarda o usuário.

            Console.Write("> ");

            Console.ReadKey();
        
        Thread.Sleep(333);

        Menu(); //Chama o método construtor do menu.

        }

        public void Menu() //declaração do menu.
        {
            menu1 = new List<string> { "0 - Criar novo usuário ", "1 - Consultar usuário  ", "2 - Listar usuários    ", "3 - Apagar usuário     ", "4 - Zerar              ", "5 - Sair               " }; //definindo confiurações do menu inicial e criando.

            var X = BasicMenu.init(ConsoleColor.Green, ConsoleColor.White, 2, @$"  Escolha uma opção: ", menu1);
            var Y = X.KeyChar; //Convertendo a chave em string.

            switch (Y)
            {
                case '0':
                    CreatePersona(); //inicia o cadastro.
                    break;

                case '1':
                    consulta(); //chama o método para consultar usuário escolhido.
                    break;

                case '2':
                    StreamReader ReadPessoas = new StreamReader(Path); //inicia módulo de leitura de arquivo.

                    Console.Clear();                              //Interpretendo opção escolhida, inválido retorna para o menu inicial.

                    Console.ForegroundColor = ConsoleColor.Green;

                    List<string> lines = new List<string>();

                    while (!ReadPessoas.EndOfStream)
                    {
                        lines.Add(ReadPessoas.ReadLine()+"");
                    }

                    foreach (var x in lines)
                    {
                        Console.WriteLine(x); //lista usuários e retorna para o menu.
                    }

                    Console.ResetColor();

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.WriteLine("Pressione qualquer tecla para contunuar.");
                    Console.WriteLine();
                                               
                    Console.ResetColor();

                    Console.Write("> ");

                    Console.ReadKey();

                    ReadPessoas.Close();
                    
                    Menu(); //retorna ao menu inicial.

                    break;

                case '3':
                    Remover(); //chama o método para selecionar e tentar remover usuário escolhido.
                    Menu();
                    break;

                case '4':
                    System.IO.File.WriteAllText(Path, string.Empty);
                    //Pessoas.Clear();  //Limpa todos os usuários salvos.
                    Menu();
                    break;

                case '5':
                    Environment.Exit(0); //sair do programa
                    break;

                default:
                    Menu();  //inválido retorna para o menu inicial
                    break;
            }
        }

        public void CreatePersona() //declaração criar pessoa
        {
            string Nomear() 
            {
                WellComeLine.init(BorderColor: ConsoleColor.Cyan, ConsoleColor.White, 1, @$"Digite o nome da pessoa/empresa. "); //usa a mesma classe de título para fazer perguntas.

                Console.Write("> ");
                PeopleStruct.Name = Console.ReadLine(); //captura o nome digitado no terminal.

                return PeopleStruct.Name+""; //retorna na variável
            }

            string TipoDePessoas() //declaração tipagem de usuário.
            {
                menu1 = new List<string> { "0 - Sim", "1 - Não" }; //definindo um novo menu

                var X = BasicMenu.init(ConsoleColor.Green, ConsoleColor.White, 2, @$"É pessoa física? ", menu1); //criando menu novo
                var Y = X.KeyChar; //convertendo chave do usuário em string.

                switch (Y)
                {
                    case '0':

                        PeopleStruct.PessoaFisica = true;
                        return "É Pessoa física";         //retorna string na variável

                    case '1':

                        PeopleStruct.PessoaFisica = false;
                        return "É Pessoa jurídica"; //retorna string na variável

                    default:
                        return TipoDePessoas();  //inválido retorna a pergunta
                }

            }

            string Datar() //delaração data de nascimento/fundação.
            {
                try 
                {
                    if (PeopleStruct.PessoaFisica == true) //verifica se é pessoa física ou jurídica.
                    {
                        WellComeLine.init(BorderColor: ConsoleColor.Cyan, ConsoleColor.White, 1, @$"Digite a data de nascimento. XX/XX/XX");

                        Console.Write("> ");
                        PeopleStruct.Date = Convert.ToDateTime(Console.ReadLine()); //valida se o formato da data é correto usando DateTime ao invés de string

                        return Convert.ToString(PeopleStruct.Date); //retorna string a variável

                    }
                    else
                    {
                        WellComeLine.init(BorderColor: ConsoleColor.Cyan, ConsoleColor.White, 1, @$"Digite a data de fundação. XX/XX/XX");

                        Console.Write("> ");
                        PeopleStruct.Date = Convert.ToDateTime(Console.ReadLine()); //valida se o formato da data é correto usando DateTime ao invés de string

                        return Convert.ToString(PeopleStruct.Date); //retorna string a variável

                    }
                }
                catch 
                {
                    return Datar(); //erro ou inválido retorna a pergunta.
                }
            }

            string Documentar() 
            {
                try 
                {
                    if (PeopleStruct.PessoaFisica == true) //verifica se é pessoa física ou jurídica.
                    {
                        WellComeLine.init(BorderColor: ConsoleColor.Cyan, ConsoleColor.White, 1, @$"Digite o CPF. XXX.XXX.XXX-XX "); //criando um novo título.

                        Console.Write("> ");

                        PeopleStruct.Document = Console.ReadLine()+"";

                        if (Regex.IsMatch(PeopleStruct.Document, @"^\d{3}.\d{3}.\d{3}-\d{2}$")) //usa o regex para validar o formato do CPF
                        {
                            Console.Clear();
                            return PeopleStruct.Document; //retorna como string
                        }
                        else
                        {
                            return Documentar(); //incorreto retorna a pergunta.
                        }
                    }
                    else 
                    {
                        WellComeLine.init(BorderColor: ConsoleColor.Cyan, ConsoleColor.White, 1, @$"Digite o CPNJ. XX.XXX.XXX/000X-XX"); //criando título.

                        Console.Write("> ");

                        PeopleStruct.Document = Console.ReadLine()+"";

                        if (Regex.IsMatch(PeopleStruct.Document, @"^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$")) //validando formato CPNJ.
                        {
                            Console.Clear();
                            return PeopleStruct.Document; //retorna como string
                        }
                        else 
                        {
                            return Documentar(); //incorreto retorna à pergunta.
                        }

                    }

                }
                catch 
                {
                    return Documentar(); //erro retorna à pergunta.
                }
            }

            StreamReader ReadPessoas = new StreamReader(Path); //inicia módulo de leitura de arquivo.

            string index() 
            {
                string tamanho = Convert.ToString(File.ReadAllLines(Path).Length); //definindo um ID do usuário a partir do tamanho da lista.

                return tamanho; //retorna como string
            }

            ReadPessoas.Close();

            string[] Dados = { index() + " - " + Nomear() + ", " + TipoDePessoas() + ", Data: " + Datar() + ", Documento: " + Documentar() };

            //StreamWriter Pessoas = new StreamWriter(Path); //inicia módulo de escrita de arquivo.

            File.AppendAllLines(Path, Dados); //salvando o usuário com tudo no formato string.

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Pressione qualquer tecla para contunuar."); //aguardando o usuário antes de voltar
            Console.WriteLine();

            Console.ResetColor();

            Console.Write("> ");

            Console.ReadKey();

            //Pessoas.Close();

            Menu(); //voltando ao menu inicial.

        }

        public void consulta() //declaração de consulta de usuário
        {
            StreamReader ReadPessoas = new StreamReader(Path);

            WellComeLine.init(BorderColor: ConsoleColor.Cyan, ConsoleColor.White, 1, @$"Digite o ID do item cadastrado. {0} a {File.ReadAllLines(Path).Length-1}"); //criando título.

            Console.Write("> ");
            var Selecao = Console.ReadLine(); //Capturando seleção do ID de usuário digitada na linha.
            Console.Clear();

            try 
            {
                for (int i = 0; i < Convert.ToInt32(Selecao); i++)
                {
                    if (Convert.ToInt32(Selecao) > File.ReadAllLines(Path).Length) 
                    {
                        throw new Exception();
                    }
                    else 
                    {
                        Console.Clear();
                        ReadPessoas.ReadLine();
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine(ReadPessoas.ReadLine()); //mostando usuário escolhido via ID no terminal
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Pressione qualquer tecla para contunuar."); //aguarando um enter.....
                Console.WriteLine();

                Console.ResetColor();

                Console.Write("> ");

                Console.ReadKey();

                ReadPessoas.Close();

                Menu(); //voltando ao menu inicial.
            }
            catch 
            {
                WellComeLine.init(BorderColor: ConsoleColor.DarkGray, ConsoleColor.Red, 1, @$"Fora dos limites."); //erro gera um título.
                Console.ResetColor();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Pressione qualquer tecla para contunuar."); //aguardando um enter...
                Console.WriteLine();

                Console.ResetColor();

                Console.Write("> ");

                Console.ReadKey();

                ReadPessoas.Close();

                Menu(); //voltando ao menu inicial.
            }
        }

        public void Remover() //declaração de remoção de usuário.
        {
            StreamReader ReadPessoas = new StreamReader(Path);

            WellComeLine.init(BorderColor: ConsoleColor.Cyan, ConsoleColor.White, 1, @$"Digite o ID do item cadastrado. {0} a {File.ReadAllLines(Path).Length-1}"); //gerando título 0 à "Quantidade de usuários".

            Console.Write("> ");
            var Selecao = Console.ReadLine(); //capturando id digitado pelo usuário.
            Console.Clear();

            try
            {
                for (int i = -1; i < Convert.ToInt32(Selecao); i++)
                {
                    if (Convert.ToInt32(Selecao) > File.ReadAllLines(Path).Length)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        if (i+1 == Convert.ToInt32(Selecao))
                        {
                            Pessoas.Add("");
                        }
                        else 
                        {
                            Pessoas.Add(ReadPessoas.ReadLine()+"");
                        }
                    }
                }

                ReadPessoas.Close();

                StreamWriter WritePessoas = new StreamWriter(Path);

                foreach (var x in Pessoas) 
                {
                    WritePessoas.WriteLine(x);
                }

                WritePessoas.Close();
                Pessoas.Clear();

                Console.ForegroundColor = ConsoleColor.Green;

                //Pessoas.RemoveAt(Convert.ToInt32(Selecao)); //removendo usuário.

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Pressione qualquer tecla para contunuar."); //aguarando um enter.
                Console.WriteLine();

                Console.ResetColor();

                Console.Write("> ");

                Console.ReadKey();

                Menu(); //voltando ao menu
            }
            catch //erro
            {
                WellComeLine.init(BorderColor: ConsoleColor.DarkGray, ConsoleColor.Red, 1, @$"Fora dos limites."); //título caso o ID digitado não exista.
                Console.ResetColor();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Pressione qualquer tecla para contunuar."); //aguardando um enter.
                Console.WriteLine();

                Console.ResetColor();

                Console.Write("> ");

                Console.ReadKey();

                ReadPessoas.Close();
                Pessoas.Clear();

                Menu(); //voltando ao menu inicial.
            }
        }
    }
}
