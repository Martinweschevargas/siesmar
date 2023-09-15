using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GradoEstudioEspecif
    {
        readonly GradoEstudioEspecifDAO gradoEstudioEspecifDAO = new();

        public List<GradoEstudioEspecifDTO> ObtenerGradoEstudioEspecifs()
        {
            return gradoEstudioEspecifDAO.ObtenerGradoEstudioEspecifs();
        }

        public string AgregarGradoEstudioEspecif(GradoEstudioEspecifDTO gradoEstudioEspecifDto)
        {
            return gradoEstudioEspecifDAO.AgregarGradoEstudioEspecif(gradoEstudioEspecifDto);
        }

        public GradoEstudioEspecifDTO BuscarGradoEstudioEspecifID(int Codigo)
        {
            return gradoEstudioEspecifDAO.BuscarGradoEstudioEspecifID(Codigo);
        }

        public string ActualizarGradoEstudioEspecif(GradoEstudioEspecifDTO gradoEstudioEspecifDTO)
        {
            return gradoEstudioEspecifDAO.ActualizarGradoEstudioEspecif(gradoEstudioEspecifDTO);
        }

        public string EliminarGradoEstudioEspecif(GradoEstudioEspecifDTO gradoEstudioEspecifDTO)
        {
            return gradoEstudioEspecifDAO.EliminarGradoEstudioEspecif(gradoEstudioEspecifDTO);
        }

    }
}
