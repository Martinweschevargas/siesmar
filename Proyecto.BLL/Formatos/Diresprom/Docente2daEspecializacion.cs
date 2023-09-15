using Marina.Siesmar.AccesoDatos.Formatos.Diresprom;
using Marina.Siesmar.Entidades.Formatos.Diresprom;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diresprom
{
    public class Docente2daEspecializacion
    {
        Docente2daEspecializacionDAO docente2daEspecializacionDAO = new();

        public List<Docente2daEspecializacionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return docente2daEspecializacionDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(Docente2daEspecializacionDTO docente2daEspecializacionDTO, string? fecha = null)
        {
            return docente2daEspecializacionDAO.AgregarRegistro(docente2daEspecializacionDTO, fecha);
        }

        public Docente2daEspecializacionDTO EditarFormado(int Codigo)
        {
            return docente2daEspecializacionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(Docente2daEspecializacionDTO docente2daEspecializacionDTO)
        {
            return docente2daEspecializacionDAO.ActualizaFormato(docente2daEspecializacionDTO);
        }

        public bool EliminarFormato(Docente2daEspecializacionDTO docente2daEspecializacionDTO)
        {
            return docente2daEspecializacionDAO.EliminarFormato(docente2daEspecializacionDTO);
        }

        public bool EliminarCarga(Docente2daEspecializacionDTO docente2daEspecializacionDTO)
        {
            return docente2daEspecializacionDAO.EliminarCarga(docente2daEspecializacionDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return docente2daEspecializacionDAO.InsertarDatos(datos, fecha);
        }

    }
}
