using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Ditranav;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Ditranav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Ditranav
{
    public class MantenimientoReparacionVehiculos
    {
        MantenimientoReparacionVehiculosDAO mantenimientoReparacionVehiculosDAO = new();

        public List<MantenimientoReparacionVehiculosDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return mantenimientoReparacionVehiculosDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(MantenimientoReparacionVehiculosDTO mantenimientoReparacionVehiculos, string? fecha)
        {
            return mantenimientoReparacionVehiculosDAO.AgregarRegistro(mantenimientoReparacionVehiculos, fecha);
        }

        public MantenimientoReparacionVehiculosDTO EditarFormato(int Codigo)
        {
            return mantenimientoReparacionVehiculosDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(MantenimientoReparacionVehiculosDTO mantenimientoReparacionVehiculosDTO)
        {
            return mantenimientoReparacionVehiculosDAO.ActualizaFormato(mantenimientoReparacionVehiculosDTO);
        }

        public bool EliminarFormato(MantenimientoReparacionVehiculosDTO mantenimientoReparacionVehiculosDTO)
        {
            return mantenimientoReparacionVehiculosDAO.EliminarFormato(mantenimientoReparacionVehiculosDTO);
        }

        public bool EliminarCarga(MantenimientoReparacionVehiculosDTO mantenimientoReparacionVehiculosDTO)
        {
            return mantenimientoReparacionVehiculosDAO.EliminarCarga(mantenimientoReparacionVehiculosDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return mantenimientoReparacionVehiculosDAO.InsertarDatos(datos, fecha);
        }

    }
}
