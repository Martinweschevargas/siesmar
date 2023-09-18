using Marina.Siesmar.AccesoDatos.Formatos.Dicapi;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dicapi
{
    public class ExpDocumentoNaveArtefacto
    {
        ExpDocumentoNaveArtefactoDAO expDocumentoNaveArtefactoDAO = new();

        public List<ExpDocumentoNaveArtefactoDTO> ObtenerLista()
        {
            return expDocumentoNaveArtefactoDAO.ObtenerLista();
        }

        public string AgregarRegistro(ExpDocumentoNaveArtefactoDTO expDocumentoNaveArtefacto)
        {
            return expDocumentoNaveArtefactoDAO.AgregarRegistro(expDocumentoNaveArtefacto);
        }

        public ExpDocumentoNaveArtefactoDTO BuscarFormato(int Codigo)
        {
            return expDocumentoNaveArtefactoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ExpDocumentoNaveArtefactoDTO expDocumentoNaveArtefactoDTO)
        {
            return expDocumentoNaveArtefactoDAO.ActualizaFormato(expDocumentoNaveArtefactoDTO);
        }

        public bool EliminarFormato(ExpDocumentoNaveArtefactoDTO expDocumentoNaveArtefactoDTO)
        {
            return expDocumentoNaveArtefactoDAO.EliminarFormato( expDocumentoNaveArtefactoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return expDocumentoNaveArtefactoDAO.InsertarDatos(datos);
        }

        //public bool InsercionMasiva(IEnumerable<ExpDocumentoNaveArtefactoDTO> expDocumentoNaveArtefactoDTO)
        //{
        //    return expDocumentoNaveArtefactoDAO.InsercionMasiva(expDocumentoNaveArtefactoDTO);
        //}

    }
}
