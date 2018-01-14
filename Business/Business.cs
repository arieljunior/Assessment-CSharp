using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Business
{
    public class Business
    {
        private DataAcces.DataAcces dt = new DataAcces.DataAcces();

        public void CriarAmigo(PessoaModel pessoa)
        {
            int ano = DateTime.Today.Year;

            if (pessoa.Nome.Length <= 20 && pessoa.Sobrenome.Length <= 20 && pessoa.Nascimento.Year <= ano)
            {
                //Dados Ok

                pessoa.Id = dt.GetAmigos().Count() + 1;

                if (dt.Salvar(pessoa))
                {
                    Console.WriteLine("Amigo salvo com sucesso");
                }
                else
                {
                    Console.WriteLine("Erro ao salvar");
                }
            }
            else
            {
                Console.WriteLine("Nome ou sobrenome muito grande ou ano de nascimento maior que o ano atual.");
            }
        }

        public void DeletarAmigo(int id)
        {
            var Amigos = new List<PessoaModel>();
        }

        public List<PessoaModel> GetAmigos()
        {
            return dt.GetAmigos();
        }

        public void AtualizarAmigo(string nome, string sobrenome, DateTime nascimento, int id_amigo)
        {

            List<PessoaModel> Amigos = dt.GetAmigos();
            PessoaModel AmigoEncontrado = null;
            foreach (var amigo in Amigos)
            {
                if (amigo.Id == id_amigo)
                {
                    AmigoEncontrado = amigo;
                    break;
                }
            }

            if (AmigoEncontrado != null)
            {
                if (dt.SalvarAmigo(pessoa))
                {
                    Console.WriteLine("Novo amigo salvo com sucesso");
                }
                else
                {
                    Console.WriteLine("Erro ao salvar o amigo");
                }
            }
            else
            {
                Console.WriteLine("Amigo não encontrado");
            }
        }

        public List<String> getAniversariantes()
        {
            List<String> Aniversariantes = null;

            var Amigos = dt.GetAmigos();
            int DiaAtual = DateTime.Today.Day;
            int MesAtual = DateTime.Today.Month;

            foreach (var amigo in Amigos)
            {
                if (amigo.Nascimento.Day == DiaAtual && amigo.Nascimento.Month == MesAtual)
                {
                    Aniversariantes.Add(amigo.Nome);
                }
            }

            return Aniversariantes;
        }
    }
}
