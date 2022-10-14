using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFormula1_DF.Controller
{
    public class CarroController : ICarroController
    {
        public void CadastroCarro()
        {
            Carro carro = new Carro();
            using (var context = new F1Entities())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Cadastrar Carro ###");
                Console.WriteLine("Informe o modelo do carro: ");
                carro.modelo = Console.ReadLine().ToLower();
                var veriryName = context.Carroes.FirstOrDefault(t => t.modelo == carro.modelo);
                if (veriryName == null)
                {
                    Console.WriteLine("Informe a unidade do carro: ");
                    carro.unidade = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe o ano do carro: ");
                    carro.ano = int.Parse(Console.ReadLine());
                    Console.WriteLine("Informe o ID da equipe deste carro: ");
                    carro.id_equipe = int.Parse(Console.ReadLine());
                    var verifyEquipe = context.Equipes.FirstOrDefault(x => x.id == carro.id_equipe);
                    if (verifyEquipe != null)
                    {
                        context.Carroes.Add(carro);
                        context.SaveChanges();
                        Console.WriteLine("### Carro salvo com sucesso! ###");
                        Program.PressContinue();
                    }
                    else
                    {
                        Console.WriteLine("Essa equipe não existe, por favor, volte e cadastre novamente");
                        Program.PressContinue();
                    }
                }
                else
                {
                    Console.WriteLine("Esse nome de carro já existe em nosso banco de dados, volte e insira outro!!");
                    Program.PressContinue();
                }
            }
        }
        public void EditarCarro() 
        {
            var carro = new Carro();
            using (var context = new F1Entities())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Edit Carro ###");
                Console.WriteLine("Informe o nome para consultar os dados do carro: ");
                carro.id = int.Parse(Console.ReadLine());
                var find = context.Carroes.FirstOrDefault(t => t.id == carro.id);
                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Program.PressContinue();
                    Console.WriteLine("O que voce deseja alterar do carro? \n[1] Modelo \n[2] Ano \n[3] Unidade");
                    int opc = int.Parse(Console.ReadLine());
                    while (opc < 1 || opc > 3)
                    {
                        Console.WriteLine("Opção invalida, informe novamente: ");
                        opc = int.Parse(Console.ReadLine());
                    }
                    switch (opc)
                    {
                        case 1:
                            Console.WriteLine("Informe o novo modelo para o carro: ");
                            find.modelo = Console.ReadLine().ToLower();
                            context.Entry(find).State = EntityState.Modified;
                            context.SaveChanges();
                            Console.WriteLine("\n### Modelo do carro atualizado! ###");
                            Console.WriteLine(find.ToString());
                            Program.PressContinue();
                            break;
                        case 2:
                            Console.WriteLine("Informe o novo ano do carro: ");
                            find.ano = int.Parse(Console.ReadLine());
                            context.Entry(find).State = EntityState.Modified;
                            context.SaveChanges();
                            Console.WriteLine("\n### Ano do carro atualizado! ###");
                            Console.WriteLine(find.ToString());
                            Program.PressContinue();
                            break;
                        case 3:
                            Console.WriteLine("Informe o nova unidade do carro:");
                            find.unidade = int.Parse(Console.ReadLine());
                            context.Entry(find).State = EntityState.Modified;
                            context.SaveChanges();
                            Console.WriteLine("\n### Unidade do carro atualizado! ###");
                            Console.WriteLine(find.ToString());
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
        public void DeletarCarro() 
        {
            var carro = new Carro();
            using (var context = new F1Entities())
            {
                Console.Clear();
                Program.PhoneBooksImage();
                Console.WriteLine("### Delete Carro ###");
                Console.WriteLine("Informe o ID para buscar o cadastro: ");
                carro.id = int.Parse(Console.ReadLine());
                var find = context.Carroes.FirstOrDefault(t => t.id == carro.id);
                if (find != null)
                {
                    Console.WriteLine(find.ToString());
                    Console.WriteLine("Deseja realmente deletar esse carro? \n[1] Sim \n[2] Não");
                    int op = int.Parse(Console.ReadLine());
                    while (op < 1 || op > 2)
                    {
                        Console.WriteLine("Opção inválida, informe novamente: ");
                        op = int.Parse(Console.ReadLine());
                    }
                    if (op == 1)
                    {
                        context.Entry(find).State = EntityState.Deleted;
                        context.Carroes.Remove(find);
                        context.SaveChanges();
                        Console.WriteLine(" ### Carro deletado com sucesso! ### \n");
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
        public void ConsultarCarro() {
            Console.Clear();
            Program.PhoneBooksImage();
            Console.WriteLine("### Consulta de Carros ###");
            Console.WriteLine("Voce deseja consultar: \n[1] Equipe especifica \n[2] Todas");
            int op = int.Parse(Console.ReadLine());
            while (op < 1 || op > 2)
            {
                Console.WriteLine("Opção inválida, informa novamente: ");
                op = int.Parse(Console.ReadLine());
            }
            switch (op)
            {
                case 1:
                    var carro = new Carro();
                    using (var context = new F1Entities())
                    {
                        Console.Clear();
                        Program.PhoneBooksImage();
                        Console.WriteLine("### Consult One ###");
                        Console.WriteLine("Informe o Id do carro para consultar: ");
                        carro.id = int.Parse(Console.ReadLine());
                        var find = context.Carroes.FirstOrDefault(x => x.id == carro.id); ;
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
                    var car = new F1Entities().Carroes.ToList();
                    if (car.Count == 0)
                    {
                        Console.WriteLine("\n ### Nao possuem carros cadastrados ### \n");
                        Program.PressContinue();
                    }
                    else
                    {
                        foreach (var item in car)
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
    }
}
