using Marina.Siesmar.AccesoDatos.Formatos.Combasnai;
using Marina.Siesmar.Entidades.Formatos.Combasnai;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combasnai
{
    public class SituacionEmbarcacionMenorCombasnai
    {
        SituacionEmbarcacionMenorCombasnaiDAO situacionEmbarcacionMenorCombasnaiDAO = new();

        public List<SituacionEmbarcacionMenorCombasnaiDTO> ObtenerLista()
        {
            return situacionEmbarcacionMenorCombasnaiDAO.ObtenerLista();
        }

        public string AgregarRegistro(SituacionEmbarcacionMenorCombasnaiDTO situacionEmbarcacionMenorCombasnaiDTO)
        {
            return situacionEmbarcacionMenorCombasnaiDAO.AgregarRegistro(situacionEmbarcacionMenorCombasnaiDTO);
        }

        public SituacionEmbarcacionMenorCombasnaiDTO BuscarFormato(int Codigo)
        {
            return situacionEmbarcacionMenorCombasnaiDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(SituacionEmbarcacionMenorCombasnaiDTO situacionEmbarcacionMenorCombasnaiDTO)
        {
            return situacionEmbarcacionMenorCombasnaiDAO.ActualizaFormato(situacionEmbarcacionMenorCombasnaiDTO);
        }

        public bool EliminarFormato(SituacionEmbarcacionMenorCombasnaiDTO situacionEmbarcacionMenorCombasnaiDTO)
        {
            return situacionEmbarcacionMenorCombasnaiDAO.EliminarFormato(situacionEmbarcacionMenorCombasnaiDTO);
        }

        public bool InsercionMasiva(IEnumerable<SituacionEmbarcacionMenorCombasnaiDTO> situacionEmbarcacionMenorCombasnaiDTO)
        {
            return situacionEmbarcacionMenorCombasnaiDAO.InsercionMasiva(situacionEmbarcacionMenorCombasnaiDTO);
        }

    }
}
