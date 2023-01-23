using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFuncionarios.Source.Public.Utils.Pessoas
{
    public static class PeopleStruct //estático usado como enumerador temporário durante o cadastro.
    {
        public static string? Name { get; set; } = "";

        public static bool PessoaFisica { get; set; }

        public static DateTime Date { get; set; }

        public static string ?Document { get; set; } = "";

        public static long id { get; set; }
    }
}
