using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dirconce;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirconce;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirconce
{
    public class RecaudacionMensualContrato
    {
        RecaudacionMensualContratoDAO recaudacionMensualContratoDAO = new();

        public List<RecaudacionMensualContratoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return recaudacionMensualContratoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(RecaudacionMensualContratoDTO recaudacionMensualContrato, string? fecha)
        {
            return recaudacionMensualContratoDAO.AgregarRegistro(recaudacionMensualContrato, fecha);
        }

        public RecaudacionMensualContratoDTO EditarFormado(int Codigo)
        {
            return recaudacionMensualContratoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(RecaudacionMensualContratoDTO recaudacionMensualContratoDTO)
        {
            return recaudacionMensualContratoDAO.ActualizaFormato(recaudacionMensualContratoDTO);
        }

        public bool EliminarFormato(RecaudacionMensualContratoDTO recaudacionMensualContratoDTO)
        {
            return recaudacionMensualContratoDAO.EliminarFormato( recaudacionMensualContratoDTO);
        }

        public bool EliminarCarga(RecaudacionMensualContratoDTO recaudacionMensualContratoDTO)
        {
            return recaudacionMensualContratoDAO.EliminarCarga(recaudacionMensualContratoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return recaudacionMensualContratoDAO.InsertarDatos(datos, fecha);
        }

    }
}
