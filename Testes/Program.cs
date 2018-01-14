using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;


namespace Testes
{
    class Program
    {
        DataAcces.DataAcces dt = new DataAcces.DataAcces();
        Business.Business bs = new Business.Business();

        static void Main(string[] args)
        {
            Program start = new Program();

            //start.TestarSalvarAmigo(3,"Alice", "Sousa", new DateTime(2016,02,05));
            //start.TestarExcluirAmigo(2);
            start.TestarGetAmigos();
            //start.TestarAtualizarAmigo(3, "Teste", "Teste", new DateTime(1996, 05, 17));

            Console.WriteLine("Presciona uma tecla para sair...");
            Console.ReadKey();

        }

        void TestarSalvarAmigo(int id, string nome, string sobrenome, DateTime nasc)
        {
            var p1 = new PessoaModel(nome, nasc, sobrenome);
            p1.Id = id;

            dt.Salvar(p1);
        }

        void TestarExcluirAmigo(int id)
        {
            bs.DeletarAmigo(id);
        }

        void TestarGetAmigos()
        {
            foreach (var x in dt.GetAmigos())
            {
                Console.WriteLine(x.Id);
                Console.WriteLine(x.Nome);
                Console.WriteLine(x.Sobrenome);
                Console.WriteLine(x.Nascimento+"\n");
            }
        }

        void TestarAtualizarAmigo(int id, string nome, string sobrenome, DateTime nasc)
        {
            bs.AtualizarAmigo(id, nome, sobrenome, nasc);
        }
    }
}
