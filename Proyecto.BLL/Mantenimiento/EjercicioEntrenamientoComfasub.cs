using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EjercicioEntrenamientoComfasub
    {
        readonly EjercicioEntrenamientoComfasubDAO ejercicioEntrenamientoComfasubDAO = new();

        public List<EjercicioEntrenamientoComfasubDTO> ObtenerEjercicioEntrenamientoComfasubs()
        {
            return ejercicioEntrenamientoComfasubDAO.ObtenerEjercicioEntrenamientoComfasubs();
        }

        public string AgregarEjercicioEntrenamientoComfasub(EjercicioEntrenamientoComfasubDTO ejercicioEntrenamientoComfasubDto)
        {
            return ejercicioEntrenamientoComfasubDAO.AgregarEjercicioEntrenamientoComfasub(ejercicioEntrenamientoComfasubDto);
        }

        public EjercicioEntrenamientoComfasubDTO BuscarEjercicioEntrenamientoComfasubID(int Codigo)
        {
            return ejercicioEntrenamientoComfasubDAO.BuscarEjercicioEntrenamientoComfasubID(Codigo);
        }

        public string ActualizarEjercicioEntrenamientoComfasub(EjercicioEntrenamientoComfasubDTO ejercicioEntrenamientoComfasubDto)
        {
            return ejercicioEntrenamientoComfasubDAO.ActualizarEjercicioEntrenamientoComfasub(ejercicioEntrenamientoComfasubDto);
        }

        public string EliminarEjercicioEntrenamientoComfasub(EjercicioEntrenamientoComfasubDTO ejercicioEntrenamientoComfasubDto)
        {
            return ejercicioEntrenamientoComfasubDAO.EliminarEjercicioEntrenamientoComfasub(ejercicioEntrenamientoComfasubDto);
        }

    }
}
