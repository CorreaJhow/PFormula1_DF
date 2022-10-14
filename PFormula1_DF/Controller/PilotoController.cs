using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFormula1_DF.Controller
{
    internal class PilotoController : IPilotoController
    {
        public void CadastrarPiloto()
        {
            Piloto piloto = new Piloto();
            using (var context = new F1Entities())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Cadastrar Piloto ###");
                Console.WriteLine("Informe o nome do piloto: ");
                piloto.nome = Console.ReadLine().ToLower();
                var veriryName = context.Pilotoes.FirstOrDefault(t => t.nome == piloto.nome);
                if (veriryName == null)
                {
                    context.Pilotoes.Add(piloto);
                    context.SaveChanges();
                    Console.WriteLine("### Piloto salvo com sucesso! ###");
                    Program.PressContinue();
                }
                else
                {
                    Console.WriteLine("Esse nome já existe em nosso banco de dados, volte e insira outro!!");
                    Program.PressContinue();
                }
            }
        }
        public void ConsultarPiloto()
        {
            Console.Clear();
            Program.PhoneBooksImage();
            Console.WriteLine("### Consulta de Pilotos ###");
            Console.WriteLine("Voce deseja consultar: \n[1] Piloto especifico \n[2] Todos");
            int op = int.Parse(Console.ReadLine());
            while (op < 1 || op > 2)
            {
                Console.WriteLine("Opção inválida, informa novamente: ");
                op = int.Parse(Console.ReadLine());
            }
            switch (op)
            {
                case 1:
                    var piloto = new Piloto();
                    using (var context = new F1Entities())
                    {
                        Console.Clear();
                        Program.PhoneBooksImage();
                        Console.WriteLine("### Consult One ###");
                        Console.WriteLine("Informe o nome do piloto para consultar: ");
                        piloto.nome = Console.ReadLine().ToLower();
                        var find = context.Pilotoes.FirstOrDefault(t => t.nome == piloto.nome); ;
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
                    var telephone = new F1Entities().Pilotoes.ToList();
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
        public void DeletePiloto()
        {
            var piloto = new Piloto();
            using (var context = new F1Entities())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Delete Pilotos ###");
                Console.WriteLine("Informe o nome para buscar o cadastro: ");
                piloto.nome = Console.ReadLine().ToLower();
                var find = context.Pilotoes.FirstOrDefault(t => t.nome == piloto.nome);
                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("Deseja realmente deletar essa piloto? \n[1] Sim \n[2] Não");
                    int op = int.Parse(Console.ReadLine());
                    while (op < 1 || op > 2)
                    {
                        Console.WriteLine("Opção inválida, informe novamente: ");
                        op = int.Parse(Console.ReadLine());
                    }
                    if (op == 1)
                    {
                        context.Entry(find).State = EntityState.Deleted;
                        context.Pilotoes.Remove(find);
                        context.SaveChanges();
                        Console.WriteLine(" ### Piloto deletado com sucesso! ### \n");
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
        public void EditarPiloto()
        {
            var piloto = new Piloto();
            using (var context = new F1Entities())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Edit Piloto ###");
                Console.WriteLine("Informe o nome para consultar os dados do piloto: ");
                piloto.nome = Console.ReadLine().ToLower();
                var find = context.Pilotoes.FirstOrDefault(t => t.nome == piloto.nome);
                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Program.PressContinue();
                    Console.WriteLine("Voce deseja alterar o nome do piloto? \n[1] Sim \n[2] Não");
                    int opc = int.Parse(Console.ReadLine());
                    while (opc < 1 || opc > 2)
                    {
                        Console.WriteLine("Opção invalida, informe novamente: ");
                        opc = int.Parse(Console.ReadLine());
                    }
                    switch (opc)
                    {
                        case 1:
                            Console.WriteLine("Informe o novo nome do piloto: ");
                            find.nome = Console.ReadLine().ToLower();
                            context.Entry(find).State = EntityState.Modified;
                            context.SaveChanges();
                            Console.WriteLine("\n### Nome do piloto atualizado! ###");
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
    }
}
