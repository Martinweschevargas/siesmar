using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class NivelEntrenamiento
    {
        readonly NivelEntrenamientoDAO nivelEntrenamientoDAO = new();

        public List<NivelEntrenamientoDTO> ObtenerNivelEntrenamientos()
        {
            return nivelEntrenamientoDAO.ObtenerNivelEntrenamientos();
        }

        public string AgregarNivelEntrenamiento(NivelEntrenamientoDTO nivelEntrenamientoDto)
        {
            return nivelEntrenamientoDAO.AgregarNivelEntrenamiento(nivelEntrenamientoDto);
        }

        public NivelEntrenamientoDTO BuscarNivelEntrenamientoID(int Codigo)
        {
            return nivelEntrenamientoDAO.BuscarNivelEntrenamientoID(Codigo);
        }

        public string ActualizarNivelEntrenamiento(NivelEntrenamientoDTO nivelEntrenamientoDto)
        {
            return nivelEntrenamientoDAO.ActualizarNivelEntrenamiento(nivelEntrenamientoDto);
        }

        public string EliminarNivelEntrenamiento(NivelEntrenamientoDTO nivelEntrenamientoDto)
        {
            return nivelEntrenamientoDAO.EliminarNivelEntrenamiento(nivelEntrenamientoDto);
        }

    }
}
