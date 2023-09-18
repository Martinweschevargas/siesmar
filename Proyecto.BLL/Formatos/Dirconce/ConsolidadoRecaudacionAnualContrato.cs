using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dirconce;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirconce;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirconce
{
    public class ConsolidadoRecaudacionAnualContrato
    {
        ConsolidadoRecaudacionAnualContratoDAO consolidadoRecaudacionAnualContratoDAO = new();

        public List<ConsolidadoRecaudacionAnualContratoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            
            return consolidadoRecaudacionAnualContratoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ConsolidadoRecaudacionAnualContratoDTO consolidadoRecaudacionAnualContrato, string? fecha)
            {
            return consolidadoRecaudacionAnualContratoDAO.AgregarRegistro(consolidadoRecaudacionAnualContrato, fecha);
            }

        public ConsolidadoRecaudacionAnualContratoDTO EditarFormado(int Codigo)
        {
            return consolidadoRecaudacionAnualContratoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ConsolidadoRecaudacionAnualContratoDTO consolidadoRecaudacionAnualContratoDTO)
        {
            return consolidadoRecaudacionAnualContratoDAO.ActualizaFormato(consolidadoRecaudacionAnualContratoDTO);
        }

        public bool EliminarFormato(ConsolidadoRecaudacionAnualContratoDTO consolidadoRecaudacionAnualContratoDTO)
        {
            return consolidadoRecaudacionAnualContratoDAO.EliminarFormato( consolidadoRecaudacionAnualContratoDTO);
        }

        public bool EliminarCarga(ConsolidadoRecaudacionAnualContratoDTO consolidadoRecaudacionAnualContratoDTO)
        {
            return consolidadoRecaudacionAnualContratoDAO.EliminarCarga(consolidadoRecaudacionAnualContratoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return consolidadoRecaudacionAnualContratoDAO.InsertarDatos(datos, fecha);
        }

    }
}
