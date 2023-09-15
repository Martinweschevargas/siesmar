using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class SituacionOperativaNaveComestre
    {
        SituacionOperativaNaveComestreDAO situacionOperativaNaveComestreDAO = new();

        public List<SituacionOperativaNaveComestreDTO> ObtenerLista()
        {
            return situacionOperativaNaveComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionOperativaNaveComestreDTO situacionOperativaNaveComestre)
        {
            return situacionOperativaNaveComestreDAO.AgregarRegistro(situacionOperativaNaveComestre);
        }

        public SituacionOperativaNaveComestreDTO BuscarFormato(int Codigo)
        {
            return situacionOperativaNaveComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionOperativaNaveComestreDTO situacionOperativaNaveComestreDTO)
        {
            return situacionOperativaNaveComestreDAO.ActualizaFormato(situacionOperativaNaveComestreDTO);
        }

        public bool EliminarFormato(SituacionOperativaNaveComestreDTO situacionOperativaNaveComestreDTO)
        {
            return situacionOperativaNaveComestreDAO.EliminarFormato( situacionOperativaNaveComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionOperativaNaveComestreDTO> situacionOperativaNaveComestreDTO)
        {
            return situacionOperativaNaveComestreDAO.InsercionMasiva(situacionOperativaNaveComestreDTO);
        }

    }
}
