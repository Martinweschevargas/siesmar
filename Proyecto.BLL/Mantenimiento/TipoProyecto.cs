using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoProyecto
    {
        readonly TipoProyectoDAO tipoProyectoDAO = new();

        public List<TipoProyectoDTO> ObtenerTipoProyectos()
        {
            return tipoProyectoDAO.ObtenerTipoProyectos();
        }

        public string AgregarTipoProyecto(TipoProyectoDTO tipoProyectoDto)
        {
            return tipoProyectoDAO.AgregarTipoProyecto(tipoProyectoDto);
        }

        public TipoProyectoDTO BuscarTipoProyectoID(int Codigo)
        {
            return tipoProyectoDAO.BuscarTipoProyectoID(Codigo);
        }

        public string ActualizarTipoProyecto(TipoProyectoDTO tipoProyectoDTO)
        {
            return tipoProyectoDAO.ActualizarTipoProyecto(tipoProyectoDTO);
        }

        public bool EliminarTipoProyecto(TipoProyectoDTO tipoProyectoDTO)
        {
            return tipoProyectoDAO.EliminarTipoProyecto(tipoProyectoDTO);
        }

    }
}
