using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFormula1_DF.Controller
{
    internal interface IEquipeController
    {
        void CadastrarEquipe();
        void EditarEquipe();
        void ConsultarEquipe();
        void DeletarEquipe();
    }
}
