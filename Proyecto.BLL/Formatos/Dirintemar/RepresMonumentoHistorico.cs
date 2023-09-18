using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirintemar
{
    public class RepresMonumentoHistorico
    {
        RepresMonumentoHistoricoDAO represMonumentoHistoricoDAO = new();

        public List<RepresMonumentoHistoricoDTO> ObtenerLista()
        {
            return represMonumentoHistoricoDAO.ObtenerLista();
        }

        public string AgregarRegistro(RepresMonumentoHistoricoDTO represMonumentoHistorico)
        {
            return represMonumentoHistoricoDAO.AgregarRegistro(represMonumentoHistorico);
        }

        public RepresMonumentoHistoricoDTO EditarFormato(int Codigo)
        {
            return represMonumentoHistoricoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RepresMonumentoHistoricoDTO represMonumentoHistoricoDTO)
        {
            return represMonumentoHistoricoDAO.ActualizaFormato(represMonumentoHistoricoDTO);
        }

        public bool EliminarFormato(RepresMonumentoHistoricoDTO represMonumentoHistoricoDTO)
        {
            return represMonumentoHistoricoDAO.EliminarFormato(represMonumentoHistoricoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return represMonumentoHistoricoDAO.InsertarDatos(datos);
        }

    }
}
