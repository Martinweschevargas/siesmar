using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Formula2CalificativoCentac
    {
        readonly Formula2CalificativoCentacDAO formula2CalificativoCentacDAO = new();

        public List<Formula2CalificativoCentacDTO> ObtenerFormula2CalificativoCentacs()
        {
            return formula2CalificativoCentacDAO.ObtenerFormula2CalificativoCentacs();
        }

        public string AgregarFormula2CalificativoCentac(Formula2CalificativoCentacDTO formula2CalificativoCentacDto)
        {
            return formula2CalificativoCentacDAO.AgregarFormula2CalificativoCentac(formula2CalificativoCentacDto);
        }

        public Formula2CalificativoCentacDTO BuscarFormula2CalificativoCentacID(int Codigo)
        {
            return formula2CalificativoCentacDAO.BuscarFormula2CalificativoCentacID(Codigo);
        }

        public string ActualizarFormula2CalificativoCentac(Formula2CalificativoCentacDTO formula2CalificativoCentacDTO)
        {
            return formula2CalificativoCentacDAO.ActualizarFormula2CalificativoCentac(formula2CalificativoCentacDTO);
        }

        public bool EliminarFormula2CalificativoCentac(Formula2CalificativoCentacDTO formula2CalificativoCentacDTO)
        {
            return formula2CalificativoCentacDAO.EliminarFormula2CalificativoCentac(formula2CalificativoCentacDTO);
        }

    }
}
