using Marina.Siesmar.AccesoDatos.Formatos.Combasnai;
using Marina.Siesmar.Entidades.Formatos.Combasnai;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combasnai
{
    public class OperatividadEquipoContraincendioCombasnai
    {
        OperatividadEquipoContraincendioCombasnaiDAO operatividadEquipoContraincendioDAO = new();

        public List<OperatividadEquipoContraincendioCombasnaiDTO> ObtenerLista()
        {
            return operatividadEquipoContraincendioDAO.ObtenerLista();
        }

        public string AgregarRegistro(OperatividadEquipoContraincendioCombasnaiDTO operatividadEquipoContraincendioDTO)
        {
            return operatividadEquipoContraincendioDAO.AgregarRegistro(operatividadEquipoContraincendioDTO);
        }

        public OperatividadEquipoContraincendioCombasnaiDTO BuscarFormato(int Codigo)
        {
            return operatividadEquipoContraincendioDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(OperatividadEquipoContraincendioCombasnaiDTO operatividadEquipoContraincendioDTO)
        {
            return operatividadEquipoContraincendioDAO.ActualizaFormato(operatividadEquipoContraincendioDTO);
        }

        public bool EliminarFormato(OperatividadEquipoContraincendioCombasnaiDTO operatividadEquipoContraincendioDTO)
        {
            return operatividadEquipoContraincendioDAO.EliminarFormato(operatividadEquipoContraincendioDTO);
        }

        public bool InsercionMasiva(IEnumerable<OperatividadEquipoContraincendioCombasnaiDTO> operatividadEquipoContraincendioDTO)
        {
            return operatividadEquipoContraincendioDAO.InsercionMasiva(operatividadEquipoContraincendioDTO);
        }

    }
}
