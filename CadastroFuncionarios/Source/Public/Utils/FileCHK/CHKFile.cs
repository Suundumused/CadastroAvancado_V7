using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFuncionarios.Source.Public.Utils.FileCHK
{
    public static class CHKFile
    {
        public static bool CHKFile_0(string folder) 
        {
            Console.WriteLine(File.Exists(folder));
            return File.Exists(folder);
        }
    }
}
