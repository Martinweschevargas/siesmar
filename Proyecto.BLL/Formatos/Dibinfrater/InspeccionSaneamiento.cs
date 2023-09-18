using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dibinfrater
{
    public class InspeccionSaneamiento
    {
        InspeccionSaneamientoDAO inspeccionSaneamientoDAO = new();

        public List<InspeccionSaneamientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return inspeccionSaneamientoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(InspeccionSaneamientoDTO inspeccionSaneamientoDTO, string? fecha)
        {
            return inspeccionSaneamientoDAO.AgregarRegistro(inspeccionSaneamientoDTO, fecha);
        }

        public InspeccionSaneamientoDTO EditarFormato(int Codigo)
        {
            return inspeccionSaneamientoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(InspeccionSaneamientoDTO inspeccionSaneamientoDTO)
        {
            return inspeccionSaneamientoDAO.ActualizaFormato(inspeccionSaneamientoDTO);
        }

        public bool EliminarFormato(InspeccionSaneamientoDTO inspeccionSaneamientoDTO)
        {
            return inspeccionSaneamientoDAO.EliminarFormato(inspeccionSaneamientoDTO);
        }

        public bool EliminarCarga(InspeccionSaneamientoDTO inspeccionSaneamientoDTO)
        {
            return inspeccionSaneamientoDAO.EliminarCarga(inspeccionSaneamientoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return inspeccionSaneamientoDAO.InsertarDatos(datos, fecha);
        }


    }
}
