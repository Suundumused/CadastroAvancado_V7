using CadastroFuncionarios.Source.Public.Utils.HeadStyle;
using CadastroFuncionarios.Source.Internal.Class.Pessoa;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroFuncionarios
{
    public class Program
    {
        public static void Main(string[] args) //compatibilidade para versões legadas do dotNet.

        {
            Pessoa Instancia = new Pessoa(); //Instânciando e inicializando classe mestre.
            Instancia.init();
        }    
    }
}











