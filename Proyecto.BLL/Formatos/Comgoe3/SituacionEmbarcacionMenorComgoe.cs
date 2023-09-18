
using Marina.Siesmar.AccesoDatos.Formatos.Comgoe3;
using Marina.Siesmar.Entidades.Formatos.Comgoe3;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comgoe3
{
    public class SituacionEmbarcacionMenorComgoe
    {
        SituacionEmbarcacionMenorComgoeDAO situacionEmbarcacionMenorComgoeDAO = new();

        public List<SituacionEmbarcacionMenorComgoeDTO> ObtenerLista()
        {
            return situacionEmbarcacionMenorComgoeDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionEmbarcacionMenorComgoeDTO situacionEmbarcacionMenorComgoeDTO)
        {
            return situacionEmbarcacionMenorComgoeDAO.AgregarRegistro(situacionEmbarcacionMenorComgoeDTO);
        }

        public SituacionEmbarcacionMenorComgoeDTO BuscarFormato(int Codigo)
        {
            return situacionEmbarcacionMenorComgoeDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionEmbarcacionMenorComgoeDTO situacionEmbarcacionMenorComgoeDTO)
        {
            return situacionEmbarcacionMenorComgoeDAO.ActualizaFormato(situacionEmbarcacionMenorComgoeDTO);
        }

        public bool EliminarFormato(SituacionEmbarcacionMenorComgoeDTO situacionEmbarcacionMenorComgoeDTO)
        {
            return situacionEmbarcacionMenorComgoeDAO.EliminarFormato(situacionEmbarcacionMenorComgoeDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionEmbarcacionMenorComgoeDTO> situacionEmbarcacionMenorComgoeDTO)
        {
            return situacionEmbarcacionMenorComgoeDAO.InsercionMasiva(situacionEmbarcacionMenorComgoeDTO);
        }

    }
}
