using Marina.Siesmar.AccesoDatos.Formatos.Dirciten;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirciten
{
    public class PostulanteCiten
    {
        PostulanteCitenDAO postulanteCitenDAO = new();

        public List<PostulanteCitenDTO> ObtenerLista()
        {
            return postulanteCitenDAO.ObtenerLista();
        }

        public string AgregarRegistro(PostulanteCitenDTO postulanteCitenDTO)
        {
            return postulanteCitenDAO.AgregarRegistro(postulanteCitenDTO);
        }

        public PostulanteCitenDTO EditarFormato(int Codigo)
        {
            return postulanteCitenDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PostulanteCitenDTO postulanteCitenDTO)
        {
            return postulanteCitenDAO.ActualizaFormato(postulanteCitenDTO);
        }

        public bool EliminarFormato(PostulanteCitenDTO postulanteCitenDTO)
        {
            return postulanteCitenDAO.EliminarFormato(postulanteCitenDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return postulanteCitenDAO.InsertarDatos(datos);
        }

    }
}
