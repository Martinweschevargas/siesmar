using Marina.Siesmar.AccesoDatos.Formatos.Centac;
using Marina.Siesmar.Entidades.Formatos.Centac;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Centac
{
    public class UsoSalaConferencia
    {
        UsoSalaConferenciaDAO usoSalaConferenciaDAO = new();

        public List<UsoSalaConferenciaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return usoSalaConferenciaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(UsoSalaConferenciaDTO usoSalaConferenciaDTO, string? fecha)
        {
            return usoSalaConferenciaDAO.AgregarRegistro(usoSalaConferenciaDTO, fecha);
        }

        public UsoSalaConferenciaDTO BuscarFormato(int Codigo)
        {
            return usoSalaConferenciaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(UsoSalaConferenciaDTO usoSalaConferenciaDTO)
        {
            return usoSalaConferenciaDAO.ActualizaFormato(usoSalaConferenciaDTO);
        }

        public bool EliminarFormato(UsoSalaConferenciaDTO usoSalaConferenciaDTO)
        {
            return usoSalaConferenciaDAO.EliminarFormato(usoSalaConferenciaDTO);
        }

        public bool EliminarCarga(UsoSalaConferenciaDTO usoSalaConferenciaDTO)
        {
            return usoSalaConferenciaDAO.EliminarCarga(usoSalaConferenciaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return usoSalaConferenciaDAO.InsertarDatos(datos, fecha);
        }

    }
}
