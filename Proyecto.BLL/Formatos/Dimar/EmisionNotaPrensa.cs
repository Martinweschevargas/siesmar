using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class EmisionNotaPrensa
    {
        EmisionNotaPrensaDAO emisionNotaPrensaDAO = new();

        public List<EmisionNotaPrensaDTO> ObtenerLista(int? CargaId = null)
        {
            return emisionNotaPrensaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(EmisionNotaPrensaDTO emisionNotaPrensaDTO)
        {
            return emisionNotaPrensaDAO.AgregarRegistro(emisionNotaPrensaDTO);
        }

        public EmisionNotaPrensaDTO BuscarFormato(int Codigo)
        {
            return emisionNotaPrensaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EmisionNotaPrensaDTO emisionNotaPrensaDTO)
        {
            return emisionNotaPrensaDAO.ActualizaFormato(emisionNotaPrensaDTO);
        }

        public bool EliminarFormato(EmisionNotaPrensaDTO emisionNotaPrensaDTO)
        {
            return emisionNotaPrensaDAO.EliminarFormato(emisionNotaPrensaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return emisionNotaPrensaDAO.InsertarDatos(datos);
        }

    }
}
