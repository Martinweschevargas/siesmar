using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class VehiculoServicioGrupo
    {
        readonly VehiculoServicioGrupoDAO vehiculoServicioGrupoDAO = new();

        public List<VehiculoServicioGrupoDTO> ObtenerVehiculoServicioGrupos()
        {
            return vehiculoServicioGrupoDAO.ObtenerVehiculoServicioGrupos();
        }

        public string AgregarVehiculoServicioGrupo(VehiculoServicioGrupoDTO vehiculoServicioGrupoDto)
        {
            return vehiculoServicioGrupoDAO.AgregarVehiculoServicioGrupo(vehiculoServicioGrupoDto);
        }

        public VehiculoServicioGrupoDTO BuscarVehiculoServicioGrupoID(int Codigo)
        {
            return vehiculoServicioGrupoDAO.BuscarVehiculoServicioGrupoID(Codigo);
        }

        public string ActualizarVehiculoServicioGrupo(VehiculoServicioGrupoDTO vehiculoServicioGrupoDTO)
        {
            return vehiculoServicioGrupoDAO.ActualizarVehiculoServicioGrupo(vehiculoServicioGrupoDTO);
        }

        public bool EliminarVehiculoServicioGrupo(VehiculoServicioGrupoDTO vehiculoServicioGrupoDTO)
        {
            return vehiculoServicioGrupoDAO.EliminarVehiculoServicioGrupo(vehiculoServicioGrupoDTO);
        }

    }
}
