using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EjercicioEntrenamientoComfoe
    {
        readonly EjercicioEntrenamientoComfoeDAO ejercicioEntrenamientoComfoeDAO = new();

        public List<EjercicioEntrenamientoComfoeDTO> ObtenerEjercicioEntrenamientoComfoes()
        {
            return ejercicioEntrenamientoComfoeDAO.ObtenerEjercicioEntrenamientoComfoes();
        }

        public string AgregarEjercicioEntrenamientoComfoe(EjercicioEntrenamientoComfoeDTO ejercicioEntrenamientoComfoeDto)
        {
            return ejercicioEntrenamientoComfoeDAO.AgregarEjercicioEntrenamientoComfoe(ejercicioEntrenamientoComfoeDto);
        }

        public EjercicioEntrenamientoComfoeDTO BuscarEjercicioEntrenamientoComfoeID(int Codigo)
        {
            return ejercicioEntrenamientoComfoeDAO.BuscarEjercicioEntrenamientoComfoeID(Codigo);
        }

        public string ActualizarEjercicioEntrenamientoComfoe(EjercicioEntrenamientoComfoeDTO ejercicioEntrenamientoComfoeDto)
        {
            return ejercicioEntrenamientoComfoeDAO.ActualizarEjercicioEntrenamientoComfoe(ejercicioEntrenamientoComfoeDto);
        }

        public string EliminarEjercicioEntrenamientoComfoe(EjercicioEntrenamientoComfoeDTO ejercicioEntrenamientoComfoeDto)
        {
            return ejercicioEntrenamientoComfoeDAO.EliminarEjercicioEntrenamientoComfoe(ejercicioEntrenamientoComfoeDto);
        }

    }
}
