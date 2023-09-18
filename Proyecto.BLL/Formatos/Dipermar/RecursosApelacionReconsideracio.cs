using Marina.Siesmar.AccesoDatos.Formatos.Dipermar;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dipermar
{
    public class RecursosApelacionReconsideracion
    {
        RecursosApelacionReconsideracionDAO recursosApelacionReconsideracionDAO = new();

        public List<RecursosApelacionReconsideracionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return recursosApelacionReconsideracionDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO, string? fecha)
        {
            return recursosApelacionReconsideracionDAO.AgregarRegistro(recursosApelacionReconsideracionDTO, fecha);
        }

        public RecursosApelacionReconsideracionDTO BuscarFormato(int Codigo)
        {
            return recursosApelacionReconsideracionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO)
        {
            return recursosApelacionReconsideracionDAO.ActualizaFormato(recursosApelacionReconsideracionDTO);
        }

        public bool EliminarFormato(RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO)
        {
            return recursosApelacionReconsideracionDAO.EliminarFormato(recursosApelacionReconsideracionDTO);
        }

        public bool EliminarCarga(RecursosApelacionReconsideracionDTO recursosApelacionReconsideracionDTO)
        {
            return recursosApelacionReconsideracionDAO.EliminarCarga(recursosApelacionReconsideracionDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return recursosApelacionReconsideracionDAO.InsertarDatos(datos, fecha);
        }

    }
}
