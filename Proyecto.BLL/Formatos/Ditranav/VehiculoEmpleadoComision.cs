using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Ditranav;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Ditranav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Ditranav
{
    public class VehiculoEmpleadoComision
    {
        VehiculoEmpleadoComisionDAO vehiculoEmpleadoComisionDAO = new();

        public List<VehiculoEmpleadoComisionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return vehiculoEmpleadoComisionDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(VehiculoEmpleadoComisionDTO vehiculoEmpleadoComision, string? fecha)
        {
            return vehiculoEmpleadoComisionDAO.AgregarRegistro(vehiculoEmpleadoComision, fecha);
        }

        public VehiculoEmpleadoComisionDTO EditarFormato(int Codigo)
        {
            return vehiculoEmpleadoComisionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(VehiculoEmpleadoComisionDTO vehiculoEmpleadoComisionDTO)
        {
            return vehiculoEmpleadoComisionDAO.ActualizaFormato(vehiculoEmpleadoComisionDTO);
        }

        public bool EliminarFormato(VehiculoEmpleadoComisionDTO vehiculoEmpleadoComisionDTO)
        {
            return vehiculoEmpleadoComisionDAO.EliminarFormato(vehiculoEmpleadoComisionDTO);
        }

        public bool EliminarCarga(VehiculoEmpleadoComisionDTO vehiculoEmpleadoComisionDTO)
        {
            return vehiculoEmpleadoComisionDAO.EliminarCarga(vehiculoEmpleadoComisionDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return vehiculoEmpleadoComisionDAO.InsertarDatos(datos, fecha);
        }

    }
}
