
using Marina.Siesmar.AccesoDatos.Formatos.Jesehin;
using Marina.Siesmar.Entidades.Formatos.Jesehin;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Jesehin
{
    public class SituacionEmbarcacionMenorJesehin
    {
        SituacionEmbarcacionMenorJesehinDAO situacionEmbarcacionMenorJesehinDAO = new();

        public List<SituacionEmbarcacionMenorJesehinDTO> ObtenerLista()
        {
            return situacionEmbarcacionMenorJesehinDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionEmbarcacionMenorJesehinDTO situacionEmbarcacionMenorJesehinDTO)
        {
            return situacionEmbarcacionMenorJesehinDAO.AgregarRegistro(situacionEmbarcacionMenorJesehinDTO);
        }

        public SituacionEmbarcacionMenorJesehinDTO BuscarFormato(int Codigo)
        {
            return situacionEmbarcacionMenorJesehinDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionEmbarcacionMenorJesehinDTO situacionEmbarcacionMenorJesehinDTO)
        {
            return situacionEmbarcacionMenorJesehinDAO.ActualizaFormato(situacionEmbarcacionMenorJesehinDTO);
        }

        public bool EliminarFormato(SituacionEmbarcacionMenorJesehinDTO situacionEmbarcacionMenorJesehinDTO)
        {
            return situacionEmbarcacionMenorJesehinDAO.EliminarFormato(situacionEmbarcacionMenorJesehinDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionEmbarcacionMenorJesehinDTO> situacionEmbarcacionMenorJesehinDTO)
        {
            return situacionEmbarcacionMenorJesehinDAO.InsercionMasiva(situacionEmbarcacionMenorJesehinDTO);
        }

    }
}
