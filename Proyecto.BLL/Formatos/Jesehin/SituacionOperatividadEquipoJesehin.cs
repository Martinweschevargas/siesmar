
using Marina.Siesmar.AccesoDatos.Formatos.Jesehin;
using Marina.Siesmar.Entidades.Formatos.Jesehin;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Jesehin
{
    public class SituacionOperatividadEquipoJesehin
    {
        SituacionOperatividadEquipoJesehinDAO formatoSituacionOperatividadEquipoJesehinDAO = new();

        public List<SituacionOperatividadEquipoJesehinDTO> ObtenerLista()
        {
            return formatoSituacionOperatividadEquipoJesehinDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperatividadEquipoJesehinDTO formatoSituacionOperatividadEquipoJesehinDTO)
        {
            return formatoSituacionOperatividadEquipoJesehinDAO.AgregarRegistro(formatoSituacionOperatividadEquipoJesehinDTO);
        }

        public SituacionOperatividadEquipoJesehinDTO BuscarFormato(int Codigo)
        {
            return formatoSituacionOperatividadEquipoJesehinDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperatividadEquipoJesehinDTO formatoSituacionOperatividadEquipoJesehinDTO)
        {
            return formatoSituacionOperatividadEquipoJesehinDAO.ActualizaFormato(formatoSituacionOperatividadEquipoJesehinDTO);
        }

        public bool EliminarFormato(SituacionOperatividadEquipoJesehinDTO formatoSituacionOperatividadEquipoJesehinDTO)
        {
            return formatoSituacionOperatividadEquipoJesehinDAO.EliminarFormato(formatoSituacionOperatividadEquipoJesehinDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionOperatividadEquipoJesehinDTO> formatoSituacionOperatividadEquipoJesehinDTO)
        {
            return formatoSituacionOperatividadEquipoJesehinDAO.InsercionMasiva(formatoSituacionOperatividadEquipoJesehinDTO);
        }

    }
}
