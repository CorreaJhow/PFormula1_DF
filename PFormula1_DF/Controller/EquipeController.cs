using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace PFormula1_DF.Controller
{
    public class EquipeController : IEquipeController
    {
        public EquipeController()
        {
        }      
        public void CadastrarEquipe()
        {
            Equipe equipe = new Equipe();
            using (var context = new F1Entities())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Cadastro de Equipes ###");
                Console.WriteLine("Informe o nome da equipe: ");
                equipe.nome = Console.ReadLine().ToLower();
                var veriryName = context.Equipes.FirstOrDefault(t => t.nome == equipe.nome);
                if (veriryName == null)
                {
                    context.Equipes.Add(equipe);
                    context.SaveChanges();
                    Console.WriteLine("### Equipe salva com sucesso! ###");
                    Program.PressContinue();
                }
                else
                {
                    Console.WriteLine("Esse nome já existe em nosso banco de dados, volte e insira outro!!");
                    Program.PressContinue();
                }
            }
        }
        public void EditarEquipe()
        {
            var equipe = new Equipe();  
            using (var context = new F1Entities())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Edit Equipe ###");
                Console.WriteLine("Informe o nome para consultar os dados de equipe: ");
                equipe.nome = Console.ReadLine().ToLower();
                var find = context.Equipes.FirstOrDefault(t => t.nome == equipe.nome);
                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Program.PressContinue();
                    Console.WriteLine("Voce deseja alterar o nome da equipe? \n[1] Sim \n[2] Não");
                    int opc = int.Parse(Console.ReadLine());
                    while(opc < 1 || opc > 2)
                    {
                        Console.WriteLine("Opção invalida, informe novamente: ");
                        opc = int.Parse(Console.ReadLine());
                    }
                    switch (opc)
                    {
                        case 1:
                            Console.WriteLine("Informe o  novo nome para equipe: ");
                            find.nome = Console.ReadLine().ToLower();          
                            context.Entry(find).State = EntityState.Modified;
                            context.SaveChanges();
                            Console.WriteLine("\n### Nome de equipe atualizado! ###");
                            Console.WriteLine(find.ToString());
                            Program.PressContinue();
                            break;
                        case 2:
                            Console.WriteLine("Obrigado, retornando ao menu!");
                            Program.PressContinue();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Registro nao encontrado, volte e tente novamente!!");
                    Program.PressContinue();
                }
            }
        }
        public void ConsultarEquipe()
        {
            Console.Clear();
            Program.PhoneBooksImage();
            Console.WriteLine("### Consulta de Equipes ###");
            Console.WriteLine("Voce deseja consultar: \n[1] Equipe especifica \n[2] Todas");
            int op = int.Parse(Console.ReadLine());
            while(op < 1|| op > 2)
            {
                Console.WriteLine("Opção inválida, informa novamente: ");
                op = int.Parse(Console.ReadLine());
            }
            switch (op)
            {
                case 1:
                    var equipe = new Equipe();
                    using (var context = new F1Entities())
                    {
                        Console.Clear();
                        Program.PhoneBooksImage();
                        Console.WriteLine("### Consult One ###");
                        Console.WriteLine("Informe o nome da equipe para consultar: ");
                        equipe.nome = Console.ReadLine().ToLower();
                        var find = context.Equipes.FirstOrDefault(t => t.nome == equipe.nome); ;
                        if (find != null)
                        {
                            Console.WriteLine(find.ToString());
                            Console.WriteLine("");
                            Program.PressContinue();
                        }
                        else
                        {
                            Console.WriteLine("\nDesculpe, cadastro não encontrado!");
                            Console.WriteLine("");
                            Program.PressContinue();
                        }
                    }
                        break;
                case 2:
                    var telephone = new F1Entities().Equipes.ToList();
                    if (telephone.Count == 0)
                    {
                        Console.WriteLine("\n ### Nao possuem contatos cadastrados ### \n");
                        Program.PressContinue();
                    }
                    else
                    {
                        foreach (var item in telephone)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Program.PressContinue();
                    }
                    break;
                default:
                    break;
            }
        }
        public void DeletarEquipe()
        {
            var equipe = new Equipe();
            using (var context = new F1Entities())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Delete ###");
                Console.WriteLine("Informe o nome para buscar o cadastro: ");
                equipe.nome = Console.ReadLine().ToLower();
                var find = context.Equipes.FirstOrDefault(t => t.nome == equipe.nome);
                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("Deseja realmente deletar essa equipe? \n[1] Sim \n[2] Não");
                    int op = int.Parse(Console.ReadLine());
                    while (op < 1 || op > 2)
                    {
                        Console.WriteLine("Opção inválida, informe novamente: ");
                        op = int.Parse(Console.ReadLine());
                    }
                    if (op == 1)
                    {
                        context.Entry(find).State = EntityState.Deleted;
                        context.Equipes.Remove(find);
                        context.SaveChanges();
                        Console.WriteLine(" ### Equipe deletada com sucesso! ### \n");
                        Program.PressContinue();
                    }
                    else
                    {
                        Console.WriteLine("\nOperação cancelada!");
                        Program.PressContinue();
                    }
                }
                else
                {
                    Console.WriteLine("\n### Contato não encontrado! ###");
                    Program.PressContinue();
                }
            }
        }
    }
}
