using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFormula1_DF.Controller;

namespace PFormula1_DF.Service
{
    internal class PilotoService
    {
        private IPilotoController _pilotoController;
        public PilotoService()
        {
            _pilotoController = new PilotoController();
        }
        public void CadastrarPiloto()
        {
            _pilotoController.CadastrarPiloto();
        }
        public void ConsultarPiloto()
        {
            _pilotoController.ConsultarPiloto();
        }
        public void DeletePiloto()
        {
            _pilotoController.DeletePiloto();
        }
        public void EditarPiloto()
        {
            _pilotoController.EditarPiloto();
        }
    }
}
