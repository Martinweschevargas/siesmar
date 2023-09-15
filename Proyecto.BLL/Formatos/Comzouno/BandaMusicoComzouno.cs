using Marina.Siesmar.AccesoDatos.Formatos.Comzouno;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Comzouno;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzouno
{
    public class BandaMusicoComzouno
    {
        BandaMusicoComzounoDAO bandaMusicoComzounoDAO = new();

        public List<BandaMusicoComzounoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return bandaMusicoComzounoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(BandaMusicoComzounoDTO bandaMusicoComzouno, string? fecha=null)
        {
            return bandaMusicoComzounoDAO.AgregarRegistro(bandaMusicoComzouno, fecha);
        }

        public BandaMusicoComzounoDTO EditarFormado(int Codigo)
        {
            return bandaMusicoComzounoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(BandaMusicoComzounoDTO bandaMusicoComzounoDTO)
        {
            return bandaMusicoComzounoDAO.ActualizaFormato(bandaMusicoComzounoDTO);
        }

        public bool EliminarFormato(BandaMusicoComzounoDTO bandaMusicoComzounoDTO)
        {
            return bandaMusicoComzounoDAO.EliminarFormato( bandaMusicoComzounoDTO);
        }

        public bool EliminarCarga(BandaMusicoComzounoDTO bandaMusicoComzounoDTO)
        {
            return bandaMusicoComzounoDAO.EliminarCarga(bandaMusicoComzounoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return bandaMusicoComzounoDAO.InsertarDatos(datos, fecha);
        }

    }
}
