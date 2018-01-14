using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    interface IAmigo
    {
        void CriarAmigo(PessoaModel pessoa);
        void DeletarAmigo(int id);
        List<PessoaModel> GetAmigos();
        void AtualizarAmigo(string nome, string sobrenome, DateTime nascimento, int id_amigo);
        List<String> getAniversariantes();
    }
}
