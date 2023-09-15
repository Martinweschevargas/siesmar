using Marina.Siesmar.AccesoDatos.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav
{
    public class ImpresionPublicacionAyudaNavegacion
    {
        ImpresionPublicacionAyudaNavegacionDAO impresionPublicacionAyudaNavegacionDAO = new();

        public List<ImpresionPublicacionAyudaNavegacionDTO> ObtenerLista(int? CargaId = null)
        {
            return impresionPublicacionAyudaNavegacionDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ImpresionPublicacionAyudaNavegacionDTO impresionPublicacionAyudaNavegacion)
        {
            return impresionPublicacionAyudaNavegacionDAO.AgregarRegistro(impresionPublicacionAyudaNavegacion);
        }

        public ImpresionPublicacionAyudaNavegacionDTO BuscarFormato(int Codigo)
        {
            return impresionPublicacionAyudaNavegacionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ImpresionPublicacionAyudaNavegacionDTO impresionPublicacionAyudaNavegacionDTO)
        {
            return impresionPublicacionAyudaNavegacionDAO.ActualizaFormato(impresionPublicacionAyudaNavegacionDTO);
        }

        public bool EliminarFormato(ImpresionPublicacionAyudaNavegacionDTO impresionPublicacionAyudaNavegacionDTO)
        {
            return impresionPublicacionAyudaNavegacionDAO.EliminarFormato( impresionPublicacionAyudaNavegacionDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return impresionPublicacionAyudaNavegacionDAO.InsertarDatos(datos);
        }
    }
}
