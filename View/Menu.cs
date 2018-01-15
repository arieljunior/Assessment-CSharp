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
                Console.Clear();

                Console.Write("Aniversáriantes de hoje: ");
                var amigos = business.getAniversariantes();
                foreach (var amigo in amigos)
                {
                    Console.Write(amigo+", ");
                }

                Console.WriteLine("\n\n[1] Cadastrar novos amigos");
                Console.WriteLine("[2] Apagar amigo");
                Console.WriteLine("[3] Editar amigo");
                Console.WriteLine("[4] Buscar amigo");
                Console.WriteLine("[5] Listar amigos");
                Console.WriteLine("[6] Finalizar programa");
                Console.Write("\nDigite uma opção: ");
                int option = 0;
                try
                {
                    option = Convert.ToInt32(Console.ReadLine());
                }catch(Exception ex)
                {

                }
                switch (option)
                {
                    case 1:
                        CadastrarOption();
                        break;
                    case 2:
                        DeletarOption();
                        break;
                    case 3:
                        EditarAmigo();
                        break;
                    case 4:
                        Buscar();
                        break;
                    case 5:
                        ListarAmigos();
                        AguardarUsuario();
                        break;
                    case 6:
                        runing = false;
                        Console.WriteLine("Aperte qualquer tecla para fechar");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        AguardarUsuario();
                        break;
                }
                
            } while (runing);
            
        }

        private static void CadastrarOption()
        {
            PessoaModel pessoaTemp;

            Console.Write("\nDigite o nome do amigo:");
            string nome = Console.ReadLine();
            Console.Write("Digite o sobrenome do amigo:");
            string sobreNome = Console.ReadLine();
            Console.Write("Digite a data de nascimento do amigo:");
            
            try
            {
                DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

                if (sobreNome == null || sobreNome.Equals(""))
                {
                    pessoaTemp = new PessoaModel(nome, dataNascimento);
                }
                else
                {
                    pessoaTemp = new PessoaModel(nome, dataNascimento, sobreNome);
                }

                if (business.CriarAmigo(pessoaTemp))
                {
                    Console.WriteLine("Amigo salvo com sucesso!");
                    AguardarUsuario();
                }
                else
                {
                    Console.WriteLine("Erro ao salvar amigo");
                    AguardarUsuario();
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Dados incorretos!");
                AguardarUsuario();
            }

            
        }

        private static void DeletarOption()
        {
            if (ListarAmigos())
            {
                Console.Write("\nDigite o ID do amigo a ser deletado: ");

                try
                {
                    var idParaDeletar = Int32.Parse(Console.ReadLine());
                    business.DeletarAmigo(idParaDeletar);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ID incorreto");
                }
                AguardarUsuario();
            }
        }

        private static bool ListarAmigos()
        {
            var listaAmigos = business.GetAmigos();
            bool notEmpty = false;
            if (listaAmigos.Count > 0 && listaAmigos != null)
            {
                foreach (var amigo in listaAmigos)
                {
                    Console.WriteLine(
                        "ID: {0}, Nome: {1}, Sobrenome: {2}, Nascimento: {3} Tempo para o próximo aniversário: {4} dia(s)",
                        amigo.Id,
                        amigo.Nome,
                        amigo.Sobrenome,
                        amigo.Nascimento,
                        business.CalcularAniversario(amigo.Nascimento)
                    );
                }
                notEmpty = true;
                
            }
            else
            {
                Console.WriteLine("Nenhum amigo cadastrado");
                
            }
            return notEmpty;
        }

        private static void EditarAmigo()
        {
            if (ListarAmigos())
            {
                Console.Write("\nDigite o ID do amigo a ser editado: ");
                try
                {
                    var id = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o nome do amigo a ser editado: ");
                    var nome = Console.ReadLine();
                    Console.WriteLine("Digite o sobrenome do amigo a ser editado: ");
                    var sobreNome = Console.ReadLine();
                    Console.WriteLine("Digite a data de nascimento do amigo a ser editado:");
                    DateTime dataNascimento = DateTime.Parse(Console.ReadLine());
                    business.AtualizarAmigo(id, nome, sobreNome, dataNascimento);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Dados incorretos");
                }
            }
            AguardarUsuario();
        }

        private static void Buscar()
        {
            Console.Write("Digite o nome do amigo que deseja achar:");
            var nome = Console.ReadLine();
            var listaBusca = business.ProcurarPorNome(nome); ;

            if (listaBusca.Count > 0)
            {
                foreach (var amigo in listaBusca)
                {
                    Console.WriteLine(
                        "ID: {0}, Nome: {1}, Sobrenome: {2}, Nascimento: {3}",
                        amigo.Id,
                        amigo.Nome,
                        amigo.Sobrenome,
                        amigo.Nascimento
                    );
                }
            }
            else
            {
                Console.WriteLine("Nenhum amigo encontrado");
            }

            AguardarUsuario();
        }

        private static void AguardarUsuario()
        {
            Console.WriteLine("\nPrescione uma tecla para voltar ao menu");
            Console.ReadKey();
        }
    }
}
