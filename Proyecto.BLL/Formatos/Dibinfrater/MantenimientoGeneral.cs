using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dibinfrater
{
    public class MantenimientoGeneral
    {
        MantenimientoGeneralDAO mantenimientoGeneralDAO = new();

        public List<MantenimientoGeneralDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return mantenimientoGeneralDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(MantenimientoGeneralDTO mantenimientoGeneralDTO, string? fecha)
        {
            return mantenimientoGeneralDAO.AgregarRegistro(mantenimientoGeneralDTO, fecha);
        }

        public MantenimientoGeneralDTO EditarFormato(int Codigo)
        {
            return mantenimientoGeneralDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(MantenimientoGeneralDTO mantenimientoGeneralDTO)
        {
            return mantenimientoGeneralDAO.ActualizaFormato(mantenimientoGeneralDTO);
        }

        public bool EliminarFormato(MantenimientoGeneralDTO mantenimientoGeneralDTO)
        {
            return mantenimientoGeneralDAO.EliminarFormato(mantenimientoGeneralDTO);
        }

        public bool EliminarCarga(MantenimientoGeneralDTO mantenimientoGeneralDTO)
        {
            return mantenimientoGeneralDAO.EliminarCarga(mantenimientoGeneralDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return mantenimientoGeneralDAO.InsertarDatos(datos, fecha);
        }

    }
}
