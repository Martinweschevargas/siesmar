using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dintemar
{
    public class EstudioSeguridadInfraestructura
    {
        EstudioSeguridadInfraestructuraDAO estudioSeguridadInfraestructuraDAO = new();

        public List<EstudioSeguridadInfraestructuraDTO> ObtenerLista(int? CargaId = null)
        {
            return estudioSeguridadInfraestructuraDAO.ObtenerLista(CargaId);
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

        public string InsertarDatos(DataTable datos)
        {
            return estudioSeguridadInfraestructuraDAO.InsertarDatos(datos);
        }

    }
}
