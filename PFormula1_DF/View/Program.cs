using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFormula1_DF.Controller;
using PFormula1_DF.Service;

namespace PFormula1_DF
{
    internal class Program
    {
        public static EquipeService equipe = new EquipeService();
        public static PilotoService piloto = new PilotoService();
        public static CarroService carro = new CarroService();
        static void Main(string[] args)
        {
            Menu();
        }
        static void Cadastrar()
        {
            Console.Clear();
            PhoneBooksImage();
            Console.WriteLine("\n### Menu de Cadastro ### \n");
            Console.WriteLine("[0] Voltar ao Menu\n[1] Cadastrar Equipe \n[2] Cadastrar Piloto \n[3] Cadastrar Carro");
            int op = int.Parse(Console.ReadLine());
            while (op < 0 || op > 3)
            {
                Console.WriteLine("Opção inválida, informe novamente: ");
                op = int.Parse(Console.ReadLine());
            }
            switch (op)
            {
                case 0:
                    Menu();
                    break;
                case 1: //cadastroEquipe 
                    equipe.CadastrarEquipe();
                    Cadastrar();
                    break;
                case 2: //Cadstro Piloto
                    piloto.CadastrarPiloto();
                    Cadastrar();
                    break;
                case 3: //Cadastro Carro 
                    carro.CadastroCarro();
                    Cadastrar();
                    break;
                default:
                    break;
            }
        }
        static void Editar()
        {
            Console.Clear();
            PhoneBooksImage();
            Console.WriteLine("\n### Menu de Edição de Dados ### \n");
            Console.WriteLine("[0] Voltar ao Menu\n[1] Editar Equipe \n[2] Editar Piloto \n[3] Editar Carro");
            int op = int.Parse(Console.ReadLine());
            while (op < 0 || op > 3)
            {
                Console.WriteLine("Opção inválida, informe novamente: ");
                op = int.Parse(Console.ReadLine());
            }
            switch (op)
            {
                case 0:
                    Menu();
                    break;
                case 1:
                    equipe.EditarEquipe();
                    Editar();
                    break;
                case 2:
                    piloto.EditarPiloto();
                    Editar();
                    break;
                case 3:

                    Editar(); 
                    break;
                default:
                    break;
            }
        }
        static void Consultar()
        {
            Console.Clear();
            PhoneBooksImage();
            Console.WriteLine("\n### Menu de Consultar ### \n");
            Console.WriteLine("[0] Voltar ao Menu\n[1] Consultar Equipe \n[2] Consultar Piloto \n[3] Consultar Carro");
            int op = int.Parse(Console.ReadLine());
            while (op < 0 || op > 3)
            {
                Console.WriteLine("Opção inválida, informe novamente: ");
                op = int.Parse(Console.ReadLine());
            }
            switch (op)
            {
                case 0:
                    Menu();
                    break;
                case 1:
                    equipe.ConsultarEquipe();
                    Consultar();
                    break;
                case 2:
                    piloto.ConsultarPiloto();
                    Consultar();
                    break;
                case 3: 
                    
                    Consultar();
                    break;
                default:
                    break;
            }
        }
        static void Deletar()
        {
            Console.Clear();
            PhoneBooksImage();
            Console.WriteLine("\n### Menu de Deletar ### \n");
            Console.WriteLine("[0] Voltar ao Menu\n[1] Deletar Equipe \n[2] Deletar Piloto \n[3] Deletar Carro");
            int op = int.Parse(Console.ReadLine());
            while (op < 0 || op > 3)
            {
                Console.WriteLine("Opção inválida, informe novamente: ");
                op = int.Parse(Console.ReadLine());
            }
            switch (op)
            {
                case 0:
                    Menu();
                    break;
                case 1:
                    equipe.DeletarEquipe();
                    Deletar();
                    break;
                case 2:
                    piloto.DeletePiloto();
                    Deletar(); 
                    break;
                case 3:

                    Deletar(); 
                    break;
                default:
                    break;
            }
        }
        public static void Menu()
        {
            Console.Clear();
            PhoneBooksImage();
            Console.WriteLine(" ### Menu Principal ###");
            Console.WriteLine("\nEscolha uma opção: \n");
            Console.WriteLine("[0] Sair \n[1] Cadastrar \n[2] Editar \n[3] Consultar \n[4] Deletar");
            int op = int.Parse(Console.ReadLine());
            while (op < 0 || op > 4)
            {
                Console.WriteLine("Opção inválida, digite novamente:");
                op = int.Parse(Console.ReadLine());
            }
            switch (op)
            {
                case 0:
                    SairPrograma();
                    break;
                case 1:
                    Cadastrar();
                    Menu();
                    break;
                case 2:
                    Editar();
                    Menu();
                    break;
                case 3:
                    Consultar();
                    Menu();
                    break;
                case 4:
                    Deletar();
                    Menu();
                    break;
                default:
                    break;
            }
        }
        private static void SairPrograma()
        {
            Console.Clear();
            PhoneBooksImage();
            Console.WriteLine("Obrigado a visita, volte sempre e nos contratem!");
            Console.WriteLine("");
            PressContinue();
            Environment.Exit(0);
        }
        public static void PhoneBooksImage()
        {
            Console.WriteLine(" +--------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine(" |                                                  Sistema|Anotações F1                                              |");
            Console.WriteLine(" +--------------------------------------------------------------------------------------------------------------------+");
        }
        public static void PressContinue()
        {
            Console.WriteLine("-=-=-=-=-= Pressione alguma tecla para prosseguir -=-=-=-=-=");
            Console.ReadKey();
        }
    }
}
