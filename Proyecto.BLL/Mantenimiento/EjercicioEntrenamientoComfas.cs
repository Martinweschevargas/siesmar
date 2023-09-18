using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EjercicioEntrenamientoComfas
    {
        readonly EjercicioEntrenamientoComfasDAO ejercicioEntrenamientoComfasDAO = new();

        public List<EjercicioEntrenamientoComfasDTO> ObtenerEjercicioEntrenamientoComfass()
        {
            return ejercicioEntrenamientoComfasDAO.ObtenerEjercicioEntrenamientoComfass();
        }

        public string AgregarEjercicioEntrenamientoComfas(EjercicioEntrenamientoComfasDTO ejercicioEntrenamientoComfasDto)
        {
            return ejercicioEntrenamientoComfasDAO.AgregarEjercicioEntrenamientoComfas(ejercicioEntrenamientoComfasDto);
        }

        public EjercicioEntrenamientoComfasDTO BuscarEjercicioEntrenamientoComfasID(int Codigo)
        {
            return ejercicioEntrenamientoComfasDAO.BuscarEjercicioEntrenamientoComfasID(Codigo);
        }

        public string ActualizarEjercicioEntrenamientoComfas(EjercicioEntrenamientoComfasDTO ejercicioEntrenamientoComfasDto)
        {
            return ejercicioEntrenamientoComfasDAO.ActualizarEjercicioEntrenamientoComfas(ejercicioEntrenamientoComfasDto);
        }

        public string EliminarEjercicioEntrenamientoComfas(EjercicioEntrenamientoComfasDTO ejercicioEntrenamientoComfasDto)
        {
            return ejercicioEntrenamientoComfasDAO.EliminarEjercicioEntrenamientoComfas(ejercicioEntrenamientoComfasDto);
        }

    }
}
