using Business;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    
    class Menu
    {
        public static BusinessClass business = new BusinessClass();    
        public void ShowMenu()
        {
            Boolean runing = true;
            do
            {
                Console.WriteLine("Aniversáriantes de hoje:");
                var amigos = business.getAniversariantes();
                foreach (var amigo in amigos)
                {
                    Console.WriteLine(amigo);
                }

                Console.WriteLine("[1] Cadastrar novos amigos");
                Console.WriteLine("[2] Apagar amigo");
                Console.WriteLine("[3] Editar amigo");
                Console.WriteLine("[4] Buscar amigo");
                Console.WriteLine("[5] Finalizar programa");
                string optionRecive = Console.ReadLine();
                int option = Convert.ToInt32(optionRecive);
                switch (option)
                {
                    case 1:
                        CadastrarOption();
                        break;
                    case 2:
                        DeletarOption();
                        break;
                    case 3:
                        Console.WriteLine("Case 2");
                        break;
                    case 4:
                        Console.WriteLine("Case 2");
                        break;
                    case 5:
                        runing = false;
                        Console.WriteLine("Aperte qualquer tecla para fechar");
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
                
            } while (runing);
            
        }

        private static void CadastrarOption()
        {
            PessoaModel pessoaTemp = new PessoaModel();

            Console.WriteLine("Digite o nome do amigo:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o sobrenome do amigo:");
            string sobreNome = Console.ReadLine();
            Console.WriteLine("Digite a data de nascimento do amigo:");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

            pessoaTemp.Nome = nome;
            pessoaTemp.Sobrenome = sobreNome;
            pessoaTemp.Nascimento = dataNascimento;

            business.CriarAmigo(pessoaTemp);
        }

        private static void DeletarOption()
        {
            var listaAmigosDeletar = business.GetAmigos();
            foreach (var amigo in listaAmigosDeletar)
            {
                Console.WriteLine("ID: {0}, Nome: {1}, Sobrenome: {2}", amigo.Id, amigo.Nome, amigo.Sobrenome);
            }
            Console.WriteLine("Digite o ID do amigo a ser deletado: ");
            var idParaDeletar = Int32.Parse(Console.ReadLine());
            business.DeletarAmigo(idParaDeletar);
        }
    }
}
