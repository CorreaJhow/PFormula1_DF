using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void DeletePiloto()
        {
            throw new NotImplementedException();
        }

        public void EditarPiloto()
        {
            throw new NotImplementedException();
        }
    }
}
