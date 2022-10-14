using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFormula1_DF.Controller;

namespace PFormula1_DF.Service
{
    internal class CarroService
    {
        new ICarroController carroController;
        public CarroService()
        {
            carroController = new CarroController();
        }
        public void CadastroCarro()
        {
            carroController.CadastroCarro();
        }
        //void EditarCarro();
        //void DeletarCarro();
        //void ConsultarCarro();
    }
}
