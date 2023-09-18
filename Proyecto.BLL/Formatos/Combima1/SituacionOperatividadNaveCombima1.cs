using Marina.Siesmar.AccesoDatos.Formatos.Combima1;
using Marina.Siesmar.Entidades.Formatos.Combima1;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combima1
{
    public class SituacionOperatividadNaveCombima1
    {
        SituacionOperatividadNaveCombima1DAO situacionOperatividadNaveCombima1DAO = new();

        public List<SituacionOperatividadNaveCombima1DTO> ObtenerLista()
        {
            return situacionOperatividadNaveCombima1DAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperatividadNaveCombima1DTO situacionOperatividadNaveCombima1DTO)
        {
            return situacionOperatividadNaveCombima1DAO.AgregarRegistro(situacionOperatividadNaveCombima1DTO);
        }

        public SituacionOperatividadNaveCombima1DTO BuscarFormato(int Codigo)
        {
            return situacionOperatividadNaveCombima1DAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperatividadNaveCombima1DTO situacionOperatividadNaveCombima1DTO)
        {
            return situacionOperatividadNaveCombima1DAO.ActualizaFormato(situacionOperatividadNaveCombima1DTO);
        }

        public bool EliminarFormato(SituacionOperatividadNaveCombima1DTO situacionOperatividadNaveCombima1DTO)
        {
            return situacionOperatividadNaveCombima1DAO.EliminarFormato(situacionOperatividadNaveCombima1DTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionOperatividadNaveCombima1DTO> situacionOperatividadNaveCombima1DTO)
        {
            return situacionOperatividadNaveCombima1DAO.InsercionMasiva(situacionOperatividadNaveCombima1DTO);
        }

    }
}
