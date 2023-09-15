using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class UsoPaginaWebInstitucional
    {
        UsoPaginaWebInstitucionalDAO usoPaginaWebInstitucionalDAO = new();

        public List<UsoPaginaWebInstitucionalDTO> ObtenerLista(int? CargaId = null)
        {
            return usoPaginaWebInstitucionalDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(UsoPaginaWebInstitucionalDTO usoPaginaWebInstitucionalDTO)
        {
            return usoPaginaWebInstitucionalDAO.AgregarRegistro(usoPaginaWebInstitucionalDTO);
        }

        public UsoPaginaWebInstitucionalDTO BuscarFormato(int Codigo)
        {
            return usoPaginaWebInstitucionalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(UsoPaginaWebInstitucionalDTO usoPaginaWebInstitucionalDTO)
        {
            return usoPaginaWebInstitucionalDAO.ActualizaFormato(usoPaginaWebInstitucionalDTO);
        }

        public bool EliminarFormato(UsoPaginaWebInstitucionalDTO usoPaginaWebInstitucionalDTO)
        {
            return usoPaginaWebInstitucionalDAO.EliminarFormato(usoPaginaWebInstitucionalDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return usoPaginaWebInstitucionalDAO.InsertarDatos(datos);
        }

    }
}
