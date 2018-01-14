using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Modelos;

namespace DataAcces
{
    public class DataAcces
    {
        private StreamWriter Escrever;
        private FileStream Arquivo;
        private StreamReader Ler;
        private string LocalArquivo = "C:\\Users\\"+ Environment.UserName + "\\Documents\\dados_at.txt";

        private void CriarArquivo()
        {
            try
            {
                Escrever = File.CreateText(LocalArquivo);
                Escrever.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caminho do arquivo não disponível");
            }

        }

        public bool Salvar(PessoaModel pessoa)
        {
            if (!File.Exists(LocalArquivo))
            {
                CriarArquivo();
            }

            try
            {
                Escrever = File.AppendText(LocalArquivo);

                Escrever.WriteLine("Id:"+pessoa.Id);
                Escrever.WriteLine("Nome:"+pessoa.Nome);
                Escrever.WriteLine("Sobrenome:"+pessoa.Sobrenome);
                Escrever.WriteLine("Nascimento:"+pessoa.Nascimento);
                Escrever.WriteLine("##########");

                Escrever.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao tentar salvar o amigo");

                return false;
            }

        }

        public List<PessoaModel> GetAmigos()
        {
            Ler = File.OpenText(LocalArquivo);
            var Amigos = new List<PessoaModel>();
            int id = 0;
            string nome = null;
            string sobrenome = null;
            DateTime nascimento = new DateTime();

            while (Ler.EndOfStream != true)
            {
                string linha = Ler.ReadLine();
                

                if (linha.Substring(0, 2).Equals("Id"))
                {
                    id = int.Parse(linha.Substring(3));
                }
                else if (linha.Substring(0, 4).Equals("Nome"))
                {
                    nome = linha.Substring(5);
                }
                else if (linha.Substring(0, 9).Equals("Sobrenome"))
                {
                    sobrenome = linha.Substring(10);
                }
                else if (linha.Substring(0, 10).Equals("Nascimento"))
                {
                    nascimento = DateTime.Parse(linha.Substring(11));

                }
                else if (linha.Equals("##########"))
                {
                    var Amigo = new PessoaModel(nome, nascimento, sobrenome);
                    Amigo.Id = id;
                    Amigos.Add(Amigo);
                }
            }

            Ler.Close();

            return Amigos;
        }

        public bool AtualizarDados(List<PessoaModel> Amigos)
        {
            CriarArquivo();

            try
            {
                Escrever = File.AppendText(LocalArquivo);

                foreach (var amigo in Amigos)
                {
                    Escrever.WriteLine("Id:" + amigo.Id);
                    Escrever.WriteLine("Nome:" + amigo.Nome);
                    Escrever.WriteLine("Sobrenome:" + amigo.Sobrenome);
                    Escrever.WriteLine("Nascimento:" + amigo.Nascimento);
                    Escrever.WriteLine("##########");
                }

                Escrever.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
