using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dintemar
{
    public class CambiosCombinacionSeguridad
    {
        CambiosCombinacionSeguridadDAO cambiosCombinacionSeguridadDAO = new();

        public List<CambiosCombinacionSeguridadDTO> ObtenerLista(int? CargaId = null)
        {
            return cambiosCombinacionSeguridadDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(CambiosCombinacionSeguridadDTO cambiosCombinacionSeguridadDTO)
        {
            return cambiosCombinacionSeguridadDAO.AgregarRegistro(cambiosCombinacionSeguridadDTO);
        }

        public CambiosCombinacionSeguridadDTO EditarFormato(int Codigo)
        {
            return cambiosCombinacionSeguridadDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CambiosCombinacionSeguridadDTO cambiosCombinacionSeguridadDTO)
        {
            return cambiosCombinacionSeguridadDAO.ActualizaFormato(cambiosCombinacionSeguridadDTO);
        }

        public bool EliminarFormato(CambiosCombinacionSeguridadDTO cambiosCombinacionSeguridadDTO)
        {
            return cambiosCombinacionSeguridadDAO.EliminarFormato(cambiosCombinacionSeguridadDTO);
        }
        public string InsertarDatos(DataTable datos)
        {
            return cambiosCombinacionSeguridadDAO.InsertarDatos(datos);
        }

    }
}
