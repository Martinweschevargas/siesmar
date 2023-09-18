using Marina.Siesmar.AccesoDatos.Formatos.Comciberdef;
using Marina.Siesmar.Entidades.Formatos.Comciberdef;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comciberdef
{
    public class AlistamientoIntegralComandanciaCiberdefensa
    {
        AlistamientoIntegralComandanciaCiberdefensaDAO alistamientoICCiberdefensaDAO = new();

        public List<AlistamientoIntegralComandanciaCiberdefensaDTO> ObtenerLista(int? CargaId = null)
        {
            return alistamientoICCiberdefensaDAO.ObtenerLista(CargaId);
        }
        public List<AlistamientoIntegralComandanciaCiberdefensaDTO> VisualizacionAlistamientoIntegralComandanciaCiberdefensa( int? CargaId = null)
        {
            return alistamientoICCiberdefensaDAO.VisualizacionAlistamientoIntegralComandanciaCiberdefensa(CargaId);
        }
        public string AgregarRegistro(AlistamientoIntegralComandanciaCiberdefensaDTO alistamientoICCiberdefensaDTO)
        {
            return alistamientoICCiberdefensaDAO.AgregarRegistro(alistamientoICCiberdefensaDTO);
        }

        public AlistamientoIntegralComandanciaCiberdefensaDTO BuscarFormato(int Codigo)
        {
            return alistamientoICCiberdefensaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoIntegralComandanciaCiberdefensaDTO alistamientoICCiberdefensaDTO)
        {
            return alistamientoICCiberdefensaDAO.ActualizaFormato(alistamientoICCiberdefensaDTO);
        }

        public bool EliminarFormato(AlistamientoIntegralComandanciaCiberdefensaDTO alistamientoICCiberdefensaDTO)
        {
            return alistamientoICCiberdefensaDAO.EliminarFormato(alistamientoICCiberdefensaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return alistamientoICCiberdefensaDAO.InsertarDatos(datos);
        }

    }
}
