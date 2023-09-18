using Marina.Siesmar.AccesoDatos.Formatos.Diresna;
using Marina.Siesmar.Entidades.Formatos.Diresna;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diresna
{
    public class PostulantesEscuelaNaval
    {
        PostulantesEscuelaNavalDAO postulantesEscuelaNavalDAO = new();

        public List<PostulantesEscuelaNavalDTO> ObtenerLista(int? CargaId = null)
        {
            return postulantesEscuelaNavalDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(PostulantesEscuelaNavalDTO postulantesEscuelaNavalDTO)
        {
            return postulantesEscuelaNavalDAO.AgregarRegistro(postulantesEscuelaNavalDTO);
        }

        public PostulantesEscuelaNavalDTO EditarFormato(int Codigo)
        {
            return postulantesEscuelaNavalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PostulantesEscuelaNavalDTO postulantesEscuelaNavalDTO)
        {
            return postulantesEscuelaNavalDAO.ActualizaFormato(postulantesEscuelaNavalDTO);
        }

        public bool EliminarFormato(PostulantesEscuelaNavalDTO postulantesEscuelaNavalDTO)
        {
            return postulantesEscuelaNavalDAO.EliminarFormato(postulantesEscuelaNavalDTO);
        }
        public string InsertarDatos(DataTable datos)
        {
            return postulantesEscuelaNavalDAO.InsertarDatos(datos);
        }

    }
}
