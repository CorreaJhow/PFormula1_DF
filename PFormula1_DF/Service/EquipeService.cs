using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFormula1_DF.Controller;

namespace PFormula1_DF.Service
{
    internal class EquipeService
    {
        private EquipeController _equipeController;
        public EquipeService()
        {
            _equipeController = new EquipeController();
        }
        public void CadastrarEquipe()
        {
            _equipeController.CadastrarEquipe();
        }
        //public void EditarEquipe();
        public void ConsultarEquipe()
        {
            _equipeController.ConsultarEquipe();
        }
        //public void DeletarEquipe();
    }
}
