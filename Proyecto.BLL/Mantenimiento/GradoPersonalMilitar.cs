using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GradoPersonalMilitar
    {
        readonly GradoPersonalMilitarDAO gradoPersonalMilitarDAO = new();

        public List<GradoPersonalMilitarDTO> ObtenerGradoPersonalMilitars()
        {
            return gradoPersonalMilitarDAO.ObtenerGradoPersonalMilitars();
        }

        public string AgregarGradoPersonalMilitar(GradoPersonalMilitarDTO gradoPersonalMilitarDto)
        {
            return gradoPersonalMilitarDAO.AgregarGradoPersonalMilitar(gradoPersonalMilitarDto);
        }

        public GradoPersonalMilitarDTO BuscarGradoPersonalMilitarID(int Codigo)
        {
            return gradoPersonalMilitarDAO.BuscarGradoPersonalMilitarID(Codigo);
        }

        public string ActualizarGradoPersonalMilitar(GradoPersonalMilitarDTO gradoPersonalMilitarDTO)
        {
            return gradoPersonalMilitarDAO.ActualizarGradoPersonalMilitar(gradoPersonalMilitarDTO);
        }

        public string EliminarGradoPersonalMilitar(GradoPersonalMilitarDTO gradoPersonalMilitarDTO)
        {
            return gradoPersonalMilitarDAO.EliminarGradoPersonalMilitar(gradoPersonalMilitarDTO);
        }

    }
}