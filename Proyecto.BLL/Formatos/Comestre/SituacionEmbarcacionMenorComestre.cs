using Marina.Siesmar.AccesoDatos.Formatos.Comestre;
using Marina.Siesmar.Entidades.Formatos.Comestre;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comestre
{
    public class SituacionEmbarcacionMenorComestre
    {
        SituacionEmbarcacionMenorComestreDAO situacionEmbarcacionMenorComestreDAO = new();

        public List<SituacionEmbarcacionMenorComestreDTO> ObtenerLista()
        {
            return situacionEmbarcacionMenorComestreDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionEmbarcacionMenorComestreDTO situacionEmbarcacionMenorComestre)
        {
            return situacionEmbarcacionMenorComestreDAO.AgregarRegistro(situacionEmbarcacionMenorComestre);
        }

        public SituacionEmbarcacionMenorComestreDTO BuscarFormato(int Codigo)
        {
            return situacionEmbarcacionMenorComestreDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionEmbarcacionMenorComestreDTO situacionEmbarcacionMenorComestreDTO)
        {
            return situacionEmbarcacionMenorComestreDAO.ActualizaFormato(situacionEmbarcacionMenorComestreDTO);
        }

        public bool EliminarFormato(SituacionEmbarcacionMenorComestreDTO situacionEmbarcacionMenorComestreDTO)
        {
            return situacionEmbarcacionMenorComestreDAO.EliminarFormato( situacionEmbarcacionMenorComestreDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionEmbarcacionMenorComestreDTO> situacionEmbarcacionMenorComestreDTO)
        {
            return situacionEmbarcacionMenorComestreDAO.InsercionMasiva(situacionEmbarcacionMenorComestreDTO);
        }

    }
}
