using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFuncionarios.Source.Public.Utils.FileCHK
{
    public static class Mkdir
    {
        public static void Mkdir_0(string folder) 
        {
            Directory.CreateDirectory(folder.Split("/")[0]);
        }
    }
}
