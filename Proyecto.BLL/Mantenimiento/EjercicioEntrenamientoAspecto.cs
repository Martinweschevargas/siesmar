using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EjercicioEntrenamientoAspecto
    {
        readonly EjercicioEntrenamientoAspectoDAO ejercicioEntrenamientoAspectoDAO = new();

        public List<EjercicioEntrenamientoAspectoDTO> ObtenerEjercicioEntrenamientoAspectos()
        {
            return ejercicioEntrenamientoAspectoDAO.ObtenerEjercicioEntrenamientoAspectos();
        }

        public string AgregarEjercicioEntrenamientoAspecto(EjercicioEntrenamientoAspectoDTO ejercicioEntrenamientoAspectoDto)
        {
            return ejercicioEntrenamientoAspectoDAO.AgregarEjercicioEntrenamientoAspecto(ejercicioEntrenamientoAspectoDto);
        }

        public EjercicioEntrenamientoAspectoDTO BuscarEjercicioEntrenamientoAspectoID(int Codigo)
        {
            return ejercicioEntrenamientoAspectoDAO.BuscarEjercicioEntrenamientoAspectoID(Codigo);
        }

        public string ActualizarEjercicioEntrenamientoAspecto(EjercicioEntrenamientoAspectoDTO ejercicioEntrenamientoAspectoDto)
        {
            return ejercicioEntrenamientoAspectoDAO.ActualizarEjercicioEntrenamientoAspecto(ejercicioEntrenamientoAspectoDto);
        }

        public string EliminarEjercicioEntrenamientoAspecto(EjercicioEntrenamientoAspectoDTO ejercicioEntrenamientoAspectoDto)
        {
            return ejercicioEntrenamientoAspectoDAO.EliminarEjercicioEntrenamientoAspecto(ejercicioEntrenamientoAspectoDto);
        }

    }
}
