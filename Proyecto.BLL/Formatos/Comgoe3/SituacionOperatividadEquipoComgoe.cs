
using Marina.Siesmar.AccesoDatos.Formatos.Comgoe3;
using Marina.Siesmar.Entidades.Formatos.Comgoe3;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comgoe3
{
    public class SituacionOperatividadEquipoComgoe
    {
        SituacionOperatividadEquipoComgoeDAO situacionOperatividadEquipoComgoeDAO = new();

        public List<SituacionOperatividadEquipoComgoeDTO> ObtenerLista()
        {
            return situacionOperatividadEquipoComgoeDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperatividadEquipoComgoeDTO situacionOperatividadEquipoComgoeDTO)
        {
            return situacionOperatividadEquipoComgoeDAO.AgregarRegistro(situacionOperatividadEquipoComgoeDTO);
        }

        public SituacionOperatividadEquipoComgoeDTO BuscarFormato(int Codigo)
        {
            return situacionOperatividadEquipoComgoeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperatividadEquipoComgoeDTO situacionOperatividadEquipoComgoeDTO)
        {
            return situacionOperatividadEquipoComgoeDAO.ActualizaFormato(situacionOperatividadEquipoComgoeDTO);
        }

        public bool EliminarFormato(SituacionOperatividadEquipoComgoeDTO situacionOperatividadEquipoComgoeDTO)
        {
            return situacionOperatividadEquipoComgoeDAO.EliminarFormato(situacionOperatividadEquipoComgoeDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionOperatividadEquipoComgoeDTO> situacionOperatividadEquipoComgoeDTO)
        {
            return situacionOperatividadEquipoComgoeDAO.InsercionMasiva(situacionOperatividadEquipoComgoeDTO);
        }

    }
}
