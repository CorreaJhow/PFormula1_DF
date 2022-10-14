using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
