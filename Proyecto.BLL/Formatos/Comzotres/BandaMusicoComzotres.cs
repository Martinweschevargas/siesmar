using Marina.Siesmar.AccesoDatos.Formatos.Comzotres;
using Marina.Siesmar.Entidades.Formatos.Comzotres;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzotres
{
    public class BandaMusicoComzotres
    {
        BandaMusicoComzotresDAO bandaMusicoComzotresDAO = new();

        public List<BandaMusicoComzotresDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return bandaMusicoComzotresDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(BandaMusicoComzotresDTO bandaMusicoComzotres, string? fecha)
        {
            return bandaMusicoComzotresDAO.AgregarRegistro(bandaMusicoComzotres, fecha);
        }

        public BandaMusicoComzotresDTO EditarFormato(int Codigo)
        {
            return bandaMusicoComzotresDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(BandaMusicoComzotresDTO bandaMusicoComzotresDTO)
        {
            return bandaMusicoComzotresDAO.ActualizaFormato(bandaMusicoComzotresDTO);
        }

        public bool EliminarFormato(BandaMusicoComzotresDTO bandaMusicoComzotresDTO)
        {
            return bandaMusicoComzotresDAO.EliminarFormato( bandaMusicoComzotresDTO);
        }

        public bool EliminarCarga(BandaMusicoComzotresDTO bandaMusicoComzotresDTO)
        {
            return bandaMusicoComzotresDAO.EliminarCarga(bandaMusicoComzotresDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return bandaMusicoComzotresDAO.InsertarDatos(datos, fecha);
        }

    }
}
