using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime Nascimento { get; set; }

        public PessoaModel()
        {

        }

        public PessoaModel(string nome, DateTime nascimento, string sobrenome = "NÃO INFORMADO")
        {
            Nome = nome;
            Nascimento = nascimento;
            Sobrenome = sobrenome;
        }
    }
}
