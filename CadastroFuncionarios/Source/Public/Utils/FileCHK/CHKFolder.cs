using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFuncionarios.Source.Public.Utils.FileCHK
{
    public static class CHKFolder
    {
        public static bool VerFile(string folder) 
        {
            string folderA = folder.Split("/")[0];
            Console.WriteLine(Directory.Exists(folderA));
            return Directory.Exists(folderA);
        }
    }
}
