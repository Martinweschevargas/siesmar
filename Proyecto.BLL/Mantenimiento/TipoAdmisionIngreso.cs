using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoAdmisionIngreso
    {
        readonly TipoAdmisionIngresoDAO tipoAdmisionIngresoDAO = new();

        public List<TipoAdmisionIngresoDTO> ObtenerTipoAdmisionIngresos()
        {
            return tipoAdmisionIngresoDAO.ObtenerTipoAdmisionIngresos();
        }

        public string AgregarTipoAdmisionIngreso(TipoAdmisionIngresoDTO tipoAdmisionIngresoDto)
        {
            return tipoAdmisionIngresoDAO.AgregarTipoAdmisionIngreso(tipoAdmisionIngresoDto);
        }

        public TipoAdmisionIngresoDTO BuscarTipoAdmisionIngresoID(int Codigo)
        {
            return tipoAdmisionIngresoDAO.BuscarTipoAdmisionIngresoID(Codigo);
        }

        public string ActualizarTipoAdmisionIngreso(TipoAdmisionIngresoDTO tipoAdmisionIngresoDTO)
        {
            return tipoAdmisionIngresoDAO.ActualizarTipoAdmisionIngreso(tipoAdmisionIngresoDTO);
        }

        public string EliminarTipoAdmisionIngreso(TipoAdmisionIngresoDTO tipoAdmisionIngresoDTO)
        {
            return tipoAdmisionIngresoDAO.EliminarTipoAdmisionIngreso(tipoAdmisionIngresoDTO);
        }

    }
}
