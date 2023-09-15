using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GradoPersonal
    {
        readonly GradoPersonalDAO gradoPersonalDAO = new();

        public List<GradoPersonalDTO> ObtenerGradoPersonals()
        {
            return gradoPersonalDAO.ObtenerGradoPersonals();
        }

        public string AgregarGradoPersonal(GradoPersonalDTO gradoPersonalDto)
        {
            return gradoPersonalDAO.AgregarGradoPersonal(gradoPersonalDto);
        }

        public GradoPersonalDTO BuscarGradoPersonalID(int Codigo)
        {
            return gradoPersonalDAO.BuscarGradoPersonalID(Codigo);
        }

        public string ActualizarGradoPersonal(GradoPersonalDTO gradoPersonalDTO)
        {
            return gradoPersonalDAO.ActualizarGradoPersonal(gradoPersonalDTO);
        }

        public bool EliminarGradoPersonal(GradoPersonalDTO gradoPersonalDTO)
        {
            return gradoPersonalDAO.EliminarGradoPersonal(gradoPersonalDTO);
        }

    }
}