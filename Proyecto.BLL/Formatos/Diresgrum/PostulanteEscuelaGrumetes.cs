using Marina.Siesmar.AccesoDatos.Formatos.Diresgrum;
using Marina.Siesmar.Entidades.Formatos.Diresgrum;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diresgrum
{
    public class PostulanteEscuelaGrumetes
    {
        PostulanteEscuelaGrumetesDAO postulanteEscuelaGrumetesDAO = new();

        public List<PostulanteEscuelaGrumetesDTO> ObtenerLista()
        {
            return postulanteEscuelaGrumetesDAO.ObtenerLista();
        }

        public string AgregarRegistro(PostulanteEscuelaGrumetesDTO postulanteEscuelaGrumetesDTO)
        {
            return postulanteEscuelaGrumetesDAO.AgregarRegistro(postulanteEscuelaGrumetesDTO);
        }

        public PostulanteEscuelaGrumetesDTO EditarFormato(int Codigo)
        {
            return postulanteEscuelaGrumetesDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PostulanteEscuelaGrumetesDTO postulanteEscuelaGrumetesDTO)
        {
            return postulanteEscuelaGrumetesDAO.ActualizaFormato(postulanteEscuelaGrumetesDTO);
        }

        public bool EliminarFormato(PostulanteEscuelaGrumetesDTO postulanteEscuelaGrumetesDTO)
        {
            return postulanteEscuelaGrumetesDAO.EliminarFormato(postulanteEscuelaGrumetesDTO);
        }

        public bool InsertarRegistros(IEnumerable<PostulanteEscuelaGrumetesDTO> postulanteEscuelaGrumetesDTO)
        {
            return InsertarRegistros(postulanteEscuelaGrumetesDTO);
        }

    }
}
