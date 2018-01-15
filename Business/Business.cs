using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;

namespace Business
{
    public class BusinessClass : IAmigo
    {
        private DataAcces.DataAcces dt = new DataAcces.DataAcces();

        public bool CriarAmigo(PessoaModel pessoa)
        {
            int ano = DateTime.Today.Year;
            bool salvo = false;
            if (!(pessoa.Nome == null) && pessoa.Nascimento.Year <= ano)
            {
                //Dados Ok

                pessoa.Id = dt.GetAmigos().Count() + 1;

                if (dt.Salvar(pessoa))
                {
                    salvo = true;
                }
            }
            else
            {
                Console.WriteLine("Nome ou sobrenome muito grande ou ano de nascimento maior que o ano atual.");
            }

            return salvo;
        }

        public void DeletarAmigo(int id)
        {
            var Amigos = dt.GetAmigos();

            if (Amigos.Count != 0)
            {
                foreach (var amigo in Amigos)
                {
                    if (amigo.Id == id)
                    {
                        Amigos.Remove(amigo);
                        break;
                    }
                }

                if (dt.AtualizarDados(Amigos))
                {
                    Console.WriteLine("Amigo excluído com sucesso");
                }
                else
                {
                    Console.WriteLine("Não foi possível excluir seu amigo");
                }
            }
            else
            {
                Console.WriteLine("Nenhum amigo cadastrado");
            }
            
        }

        public List<PessoaModel> GetAmigos()
        {
            return dt.GetAmigos();
        }

        public void AtualizarAmigo(int id_amigo, string nome, string sobrenome, DateTime nascimento)
        {

            List<PessoaModel> Amigos = dt.GetAmigos();
            bool exist = false;

            if(Amigos.Count != 0)
            {
                foreach (var amigo in Amigos)
                {
                    if (amigo.Id == id_amigo)
                    {
                        amigo.Nome = nome;
                        amigo.Sobrenome = sobrenome;
                        amigo.Nascimento = nascimento;
                        exist = true;
                        break;
                    }
                }

                if (dt.AtualizarDados(Amigos) && exist)
                {
                    Console.WriteLine("Amigo atualizado com sucesso");
                }
                else
                {
                    Console.WriteLine("Não foi possível atualizar seu amigo");
                }
            }
            else
            {
                Console.WriteLine("Nenhum amigo cadastrado");
            }

        }

        public List<String> getAniversariantes()
        {
            List<String> Aniversariantes = new List<String>();

            var Amigos = dt.GetAmigos();
            int DiaAtual = DateTime.Today.Day;
            int MesAtual = DateTime.Today.Month;

            if (Amigos.Count > 0)
            {
                foreach (var amigo in Amigos)
                {
                    if (amigo.Nascimento.Day == DiaAtual && amigo.Nascimento.Month == MesAtual)
                    {
                        Aniversariantes.Add(amigo.Nome);
                    }
                }
            }

            return Aniversariantes;
        }

        public List<PessoaModel> ProcurarPorNome(string nome)
        {
            var Amigos = dt.GetAmigos();
            List<PessoaModel> AmigosPorNome = new List<PessoaModel>();

            if (Amigos.Count != 0)
            {
                foreach (var amigo in Amigos)
                {
                    if (amigo.Nome.ToLower().Equals(nome.ToLower()))
                    {
                        AmigosPorNome.Add(amigo);
                    }
                }
            }

            return AmigosPorNome;
        }

        public int CalcularAniversario(DateTime dataNascimento)
        {
            DateTime dataAtual = DateTime.Today;

            string dia = (dataNascimento.Day).ToString();
            string mes = (dataNascimento.Month).ToString();
            string ano = (DateTime.Today.Year).ToString();

            TimeSpan tempo = new TimeSpan();

            if (dataNascimento.Month == dataAtual.Month)
            {
                if (dataNascimento.Day == dataAtual.Day)
                {
                    // variavel tempo fica null
                }
                else if (dataNascimento.Day > dataAtual.Day)
                {
                    tempo = dataAtual.Subtract(DateTime.Parse(dia + "/" + mes + "/" + ano));
                }
            }
            else if (dataNascimento.Month > dataAtual.Month)
            {
                tempo = dataAtual.Subtract(DateTime.Parse(dia + "/" + mes + "/" + ano));
            }
            else
            {
                int anoSeguinte = int.Parse(ano) + 1;
                tempo = dataAtual.Subtract(DateTime.Parse(dia + "/" + mes + "/" + anoSeguinte));
            }

            return tempo.Days*(-1);
        }
    }
}
