using System;
using System.Collections.Generic;
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
        public void EditarCarro() { }
        public void DeletarCarro() { }
        public void ConsultarCarro() { }
    }
}
