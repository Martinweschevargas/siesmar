using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class OperacionesBusquedasSalvamento
    {
        OperacionesBusquedasSalvamentoDAO operacionesBusquedasSalvamentoDAO = new();

        public List<OperacionesBusquedasSalvamentoDTO> ObtenerLista()
        {
            return operacionesBusquedasSalvamentoDAO.ObtenerLista();
        }

        public string AgregarRegistro(OperacionesBusquedasSalvamentoDTO operacionesBusquedasSalvamentoDTO)
        {
            return operacionesBusquedasSalvamentoDAO.AgregarRegistro(operacionesBusquedasSalvamentoDTO);
        }

        public OperacionesBusquedasSalvamentoDTO BuscarFormato(int Codigo)
        {
            return operacionesBusquedasSalvamentoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(OperacionesBusquedasSalvamentoDTO operacionesBusquedasSalvamentoDTO)
        {
            return operacionesBusquedasSalvamentoDAO.ActualizaFormato(operacionesBusquedasSalvamentoDTO);
        }

        public bool EliminarFormato(OperacionesBusquedasSalvamentoDTO operacionesBusquedasSalvamentoDTO)
        {
            return operacionesBusquedasSalvamentoDAO.EliminarFormato(operacionesBusquedasSalvamentoDTO);
        }

        public bool InsercionMasiva(IEnumerable<OperacionesBusquedasSalvamentoDTO> operacionesBusquedasSalvamentoDTO)
        {
            return operacionesBusquedasSalvamentoDAO.InsercionMasiva(operacionesBusquedasSalvamentoDTO);
        }

    }
}
