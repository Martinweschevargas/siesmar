using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dintemar
{
    public class EstudioSeguridadInfraestructura
    {
        EstudioSeguridadInfraestructuraDAO estudioSeguridadInfraestructuraDAO = new();

        public List<EstudioSeguridadInfraestructuraDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return estudioSeguridadInfraestructuraDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO)
        {
            return estudioSeguridadInfraestructuraDAO.AgregarRegistro(estudioSeguridadInfraestructuraDTO);
        }

        public EstudioSeguridadInfraestructuraDTO EditarFormato(int Codigo)
        {
            return estudioSeguridadInfraestructuraDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO)
        {
            return estudioSeguridadInfraestructuraDAO.ActualizaFormato(estudioSeguridadInfraestructuraDTO);
        }

        public bool EliminarFormato(EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO)
        {
            return estudioSeguridadInfraestructuraDAO.EliminarFormato(estudioSeguridadInfraestructuraDTO);
        }

        public bool EliminarCarga(EstudioSeguridadInfraestructuraDTO estudioSeguridadInfraestructuraDTO)
        {
            return estudioSeguridadInfraestructuraDAO.EliminarCarga(estudioSeguridadInfraestructuraDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return estudioSeguridadInfraestructuraDAO.InsertarDatos(datos, fecha);
        }

    }
}
