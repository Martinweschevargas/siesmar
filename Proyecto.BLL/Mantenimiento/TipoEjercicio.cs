using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoEjercicio
    {
        readonly TipoEjercicioDAO tipoEjercicioDAO = new();

        public List<TipoEjercicioDTO> ObtenerTipoEjercicios()
        {
            return tipoEjercicioDAO.ObtenerTipoEjercicios();
        }

        public string AgregarTipoEjercicio(TipoEjercicioDTO tipoEjercicioDto)
        {
            return tipoEjercicioDAO.AgregarTipoEjercicio(tipoEjercicioDto);
        }

        public TipoEjercicioDTO BuscarTipoEjercicioID(int Codigo)
        {
            return tipoEjercicioDAO.BuscarTipoEjercicioID(Codigo);
        }

        public string ActualizarTipoEjercicio(TipoEjercicioDTO tipoEjercicioDTO)
        {
            return tipoEjercicioDAO.ActualizarTipoEjercicio(tipoEjercicioDTO);
        }

        public string EliminarTipoEjercicio(TipoEjercicioDTO tipoEjercicioDTO)
        {
            return tipoEjercicioDAO.EliminarTipoEjercicio(tipoEjercicioDTO);
        }

    }
}
