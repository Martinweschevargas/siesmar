using Marina.Siesmar.AccesoDatos.Formatos.Comescla;
using Marina.Siesmar.Entidades.Formatos.Comescla;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescla
{
    public class OperatividadEquipoMaterialAntidisturbioComescla
    {
        OperatividadEquipoMaterialAntidisturbioComesclaDAO operEquipoMaterialAntidisturbioDAO = new();

        public List<OperatividadEquipoMaterialAntidisturbioComesclaDTO> ObtenerLista()
        {
            return operEquipoMaterialAntidisturbioDAO.ObtenerLista();
        }

        public string AgregarRegistro(OperatividadEquipoMaterialAntidisturbioComesclaDTO operEquipoMaterialAntidisturbioDTO)
        {
            return operEquipoMaterialAntidisturbioDAO.AgregarRegistro(operEquipoMaterialAntidisturbioDTO);
        }

        public OperatividadEquipoMaterialAntidisturbioComesclaDTO BuscarFormato(int Codigo)
        {
            return operEquipoMaterialAntidisturbioDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(OperatividadEquipoMaterialAntidisturbioComesclaDTO operEquipoMaterialAntidisturbioDTO)
        {
            return operEquipoMaterialAntidisturbioDAO.ActualizaFormato(operEquipoMaterialAntidisturbioDTO);
        }

        public bool EliminarFormato(OperatividadEquipoMaterialAntidisturbioComesclaDTO operEquipoMaterialAntidisturbioDTO)
        {
            return operEquipoMaterialAntidisturbioDAO.EliminarFormato(operEquipoMaterialAntidisturbioDTO);
        }

        public bool InsercionMasiva(IEnumerable<OperatividadEquipoMaterialAntidisturbioComesclaDTO> operEquipoMaterialAntidisturbioDTO)
        {
            return operEquipoMaterialAntidisturbioDAO.InsercionMasiva(operEquipoMaterialAntidisturbioDTO);
        }

    }
}
