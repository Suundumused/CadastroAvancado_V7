using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CadastroFuncionarios.Source.Public.Utils.Pessoas;

namespace CadastroFuncionarios.Source.Public.Interfaces.Instancia.iPessoa
{
    public interface iPessoa //tipo da classe mestre de cadastro usado em Public/interfaces/Pessoa.cs
    {
        public abstract void init();

        //public abstract List<string> Pessoas { get; set; } 

    }
}
