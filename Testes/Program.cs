using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;


namespace Testes
{
    class Program
    {
        DataAcces.DataAcces dt = new DataAcces.DataAcces();

        static void Main(string[] args)
        {
            Program start = new Program();

            //start.TestarSalvarAmigo();
            //start.TestarExcluirAmigo(1);
            start.TestarGetAmigos();

            Console.WriteLine("Presciona uma tecla para sair...");
            Console.ReadKey();

        }

        void TestarSalvarAmigo()
        {
            var p1 = new PessoaModel("Ariel", new DateTime(2017, 1, 1), "Junior");
            p1.Id = 1;

            var p2 = new PessoaModel("Maria", new DateTime(2017, 1, 1), "Eduarda");
            p2.Id = 2;

            dt.Salvar(p1);
            dt.Salvar(p2);
        }

        void TestarExcluirAmigo(int id)
        {
            dt.Excluir(id);
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
    }
}
