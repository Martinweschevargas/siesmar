using Marina.Siesmar.AccesoDatos.Formatos.Comciberdef;
using Marina.Siesmar.Entidades.Formatos.Comciberdef;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comciberdef
{
    public class CooperacionBilateralMultilateralCiberdefensa
    {
        CooperacionBilateralMultilateralCiberdefensaDAO cooperacionBilateralMultilateralCiberdefensaDAO = new();

        public List<CooperacionBilateralMultilateralCiberdefensaDTO> ObtenerLista(int? CargaId = null)
        {
            return cooperacionBilateralMultilateralCiberdefensaDAO.ObtenerLista(CargaId);
        }
        public List<CooperacionBilateralMultilateralCiberdefensaDTO> VisualizacionCooperacionBilateralMultilateralCiberdefensa(int? CargaId = null)
        {
            return cooperacionBilateralMultilateralCiberdefensaDAO.VisualizacionCooperacionBilateralMultilateralCiberdefensa( CargaId);
        }
        public string AgregarRegistro(CooperacionBilateralMultilateralCiberdefensaDTO cooperacionBilateralMultilateralCiberdefensaDTO)
        {
            return cooperacionBilateralMultilateralCiberdefensaDAO.AgregarRegistro(cooperacionBilateralMultilateralCiberdefensaDTO);
        }

        public CooperacionBilateralMultilateralCiberdefensaDTO BuscarFormato(int Codigo)
        {
            return cooperacionBilateralMultilateralCiberdefensaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CooperacionBilateralMultilateralCiberdefensaDTO cooperacionBilateralMultilateralCiberdefensaDTO)
        {
            return cooperacionBilateralMultilateralCiberdefensaDAO.ActualizaFormato(cooperacionBilateralMultilateralCiberdefensaDTO);
        }

        public bool EliminarFormato(CooperacionBilateralMultilateralCiberdefensaDTO cooperacionBilateralMultilateralCiberdefensaDTO)
        {
            return cooperacionBilateralMultilateralCiberdefensaDAO.EliminarFormato(cooperacionBilateralMultilateralCiberdefensaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return cooperacionBilateralMultilateralCiberdefensaDAO.InsertarDatos(datos);
        }

    }
}
