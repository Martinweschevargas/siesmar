using Marina.Siesmar.AccesoDatos.Formatos.Dirciten;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirciten
{
    public class PoblacionCentroIntruccionTNaval
    {
        PoblacionCentroIntruccionTNavalDAO poblacionCentroIntruccionTNavalDAO = new();

        public List<PoblacionCentroIntruccionTNavalDTO> ObtenerLista()
        {
            return poblacionCentroIntruccionTNavalDAO.ObtenerLista();
        }

        public string AgregarRegistro(PoblacionCentroIntruccionTNavalDTO poblacionCentroIntruccionTNavalDTO)
        {
            return poblacionCentroIntruccionTNavalDAO.AgregarRegistro(poblacionCentroIntruccionTNavalDTO);
        }

        public PoblacionCentroIntruccionTNavalDTO EditarFormato(int Codigo)
        {
            return poblacionCentroIntruccionTNavalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PoblacionCentroIntruccionTNavalDTO poblacionCentroIntruccionTNavalDTO)
        {
            return poblacionCentroIntruccionTNavalDAO.ActualizaFormato(poblacionCentroIntruccionTNavalDTO);
        }

        public bool EliminarFormato(PoblacionCentroIntruccionTNavalDTO poblacionCentroIntruccionTNavalDTO)
        {
            return poblacionCentroIntruccionTNavalDAO.EliminarFormato(poblacionCentroIntruccionTNavalDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return poblacionCentroIntruccionTNavalDAO.InsertarDatos(datos);
        }

    }
}
