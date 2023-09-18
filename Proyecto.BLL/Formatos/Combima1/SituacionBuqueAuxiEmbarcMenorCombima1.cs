using Marina.Siesmar.AccesoDatos.Formatos.Combima1;
using Marina.Siesmar.Entidades.Formatos.Combima1;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combima1
{
    public class SituacionBuqueAuxiEmbarcMenorCombima1
    {
        SituacionBuqueAuxiEmbarcMenorCombima1DAO situacionBuqueAuxiEmbarcMenorCombima1DAO = new();

        public List<SituacionBuqueAuxiEmbarcMenorCombima1DTO> ObtenerLista()
        {
            return situacionBuqueAuxiEmbarcMenorCombima1DAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionBuqueAuxiEmbarcMenorCombima1DTO situacionBuqueAuxiEmbarcMenorCombima1DTO)
        {
            return situacionBuqueAuxiEmbarcMenorCombima1DAO.AgregarRegistro(situacionBuqueAuxiEmbarcMenorCombima1DTO);
        }

        public SituacionBuqueAuxiEmbarcMenorCombima1DTO BuscarFormato(int Codigo)
        {
            return situacionBuqueAuxiEmbarcMenorCombima1DAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionBuqueAuxiEmbarcMenorCombima1DTO situacionBuqueAuxiEmbarcMenorCombima1DTO)
        {
            return situacionBuqueAuxiEmbarcMenorCombima1DAO.ActualizaFormato(situacionBuqueAuxiEmbarcMenorCombima1DTO);
        }

        public bool EliminarFormato(SituacionBuqueAuxiEmbarcMenorCombima1DTO situacionBuqueAuxiEmbarcMenorCombima1DTO)
        {
            return situacionBuqueAuxiEmbarcMenorCombima1DAO.EliminarFormato(situacionBuqueAuxiEmbarcMenorCombima1DTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionBuqueAuxiEmbarcMenorCombima1DTO> situacionBuqueAuxiEmbarcMenorCombima1DTO)
        {
            return situacionBuqueAuxiEmbarcMenorCombima1DAO.InsercionMasiva(situacionBuqueAuxiEmbarcMenorCombima1DTO);
        }

    }
}
