using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EjercicioEntrenamiento
    {
        readonly EjercicioEntrenamientoDAO ejercicioEntrenamientoDAO = new();

        public List<EjercicioEntrenamientoDTO> ObtenerEjercicioEntrenamientos()
        {
            return ejercicioEntrenamientoDAO.ObtenerEjercicioEntrenamientos();
        }

        public string AgregarEjercicioEntrenamiento(EjercicioEntrenamientoDTO ejercicioEntrenamientoDto)
        {
            return ejercicioEntrenamientoDAO.AgregarEjercicioEntrenamiento(ejercicioEntrenamientoDto);
        }

        public EjercicioEntrenamientoDTO BuscarEjercicioEntrenamientoID(int Codigo)
        {
            return ejercicioEntrenamientoDAO.BuscarEjercicioEntrenamientoID(Codigo);
        }

        public string ActualizarEjercicioEntrenamiento(EjercicioEntrenamientoDTO ejercicioEntrenamientoDto)
        {
            return ejercicioEntrenamientoDAO.ActualizarEjercicioEntrenamiento(ejercicioEntrenamientoDto);
        }

        public string EliminarEjercicioEntrenamiento(EjercicioEntrenamientoDTO ejercicioEntrenamientoDto)
        {
            return ejercicioEntrenamientoDAO.EliminarEjercicioEntrenamiento(ejercicioEntrenamientoDto);
        }

    }
}
