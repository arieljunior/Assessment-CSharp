using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Business
{
    interface IAmigo
    {
        void CriarAmigo(PessoaModel pessoa);
        void DeletarAmigo(int id);
        List<PessoaModel> GetAmigos();
        void AtualizarAmigo(int id_amigo, string nome, string sobrenome, DateTime nascimento);
        List<String> getAniversariantes();
    }
}
