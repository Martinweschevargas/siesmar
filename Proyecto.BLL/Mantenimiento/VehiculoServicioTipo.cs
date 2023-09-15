using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class VehiculoServicioTipo
    {
        readonly VehiculoServicioTipoDAO vehiculoServicioTipoDAO = new();

        public List<VehiculoServicioTipoDTO> ObtenerVehiculoServicioTipos()
        {
            return vehiculoServicioTipoDAO.ObtenerVehiculoServicioTipos();
        }

        public string AgregarVehiculoServicioTipo(VehiculoServicioTipoDTO vehiculoServicioTipoDto)
        {
            return vehiculoServicioTipoDAO.AgregarVehiculoServicioTipo(vehiculoServicioTipoDto);
        }

        public VehiculoServicioTipoDTO BuscarVehiculoServicioTipoID(int Codigo)
        {
            return vehiculoServicioTipoDAO.BuscarVehiculoServicioTipoID(Codigo);
        }

        public string ActualizarVehiculoServicioTipo(VehiculoServicioTipoDTO vehiculoServicioTipoDto)
        {
            return vehiculoServicioTipoDAO.ActualizarVehiculoServicioTipo(vehiculoServicioTipoDto);
        }

        public string EliminarVehiculoServicioTipo(VehiculoServicioTipoDTO vehiculoServicioTipoDto)
        {
            return vehiculoServicioTipoDAO.EliminarVehiculoServicioTipo(vehiculoServicioTipoDto);
        }

    }
}
