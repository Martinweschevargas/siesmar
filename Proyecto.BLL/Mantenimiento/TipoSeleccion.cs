using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TipoSeleccion
    {
        readonly TipoSeleccionDAO tipoSeleccionDAO = new();

        public List<TipoSeleccionDTO> ObtenerTipoSeleccions()
        {
            return tipoSeleccionDAO.ObtenerTipoSeleccions();
        }

        public string AgregarTipoSeleccion(TipoSeleccionDTO tipoSeleccionDto)
        {
            return tipoSeleccionDAO.AgregarTipoSeleccion(tipoSeleccionDto);
        }

        public TipoSeleccionDTO BuscarTipoSeleccionID(int Codigo)
        {
            return tipoSeleccionDAO.BuscarTipoSeleccionID(Codigo);
        }

        public string ActualizarTipoSeleccion(TipoSeleccionDTO tipoSeleccionDTO)
        {
            return tipoSeleccionDAO.ActualizarTipoSeleccion(tipoSeleccionDTO);
        }

        public bool EliminarTipoSeleccion(TipoSeleccionDTO tipoSeleccionDTO)
        {
            return tipoSeleccionDAO.EliminarTipoSeleccion(tipoSeleccionDTO);
        }

    }
}
