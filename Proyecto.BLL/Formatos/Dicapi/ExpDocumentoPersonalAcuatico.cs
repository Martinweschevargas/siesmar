using Marina.Siesmar.AccesoDatos.Formatos.Dicapi;
using Marina.Siesmar.Entidades.Formatos.Dicapi;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dicapi
{
    public class ExpDocumentoPersonalAcuatico
    {
        ExpDocumentoPersonalAcuaticoDAO expDocumentoPersonalAcuaticoDAO = new();

        public List<ExpDocumentoPersonalAcuaticoDTO> ObtenerLista()
        {
            return expDocumentoPersonalAcuaticoDAO.ObtenerLista();
        }

        public string AgregarRegistro(ExpDocumentoPersonalAcuaticoDTO expDocumentoPersonalAcuatico)
        {
            return expDocumentoPersonalAcuaticoDAO.AgregarRegistro(expDocumentoPersonalAcuatico);
        }

        public ExpDocumentoPersonalAcuaticoDTO BuscarFormato(int Codigo)
        {
            return expDocumentoPersonalAcuaticoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ExpDocumentoPersonalAcuaticoDTO expDocumentoPersonalAcuaticoDTO)
        {
            return expDocumentoPersonalAcuaticoDAO.ActualizaFormato(expDocumentoPersonalAcuaticoDTO);
        }

        public bool EliminarFormato(ExpDocumentoPersonalAcuaticoDTO expDocumentoPersonalAcuaticoDTO)
        {
            return expDocumentoPersonalAcuaticoDAO.EliminarFormato( expDocumentoPersonalAcuaticoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return expDocumentoPersonalAcuaticoDAO.InsertarDatos(datos);
        }

        //public bool InsercionMasiva(IEnumerable<ExpDocumentoPersonalAcuaticoDTO> expDocumentoPersonalAcuaticoDTO)
        //{
        //    return expDocumentoPersonalAcuaticoDAO.InsercionMasiva(expDocumentoPersonalAcuaticoDTO);
        //}

    }
}
