using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class ComisionAudiovisual
    {
        ComisionAudiovisualDAO comisionAudiovisualDAO = new();

        public List<ComisionAudiovisualDTO> ObtenerLista(int? CargaId = null)
        {
            return comisionAudiovisualDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ComisionAudiovisualDTO comisionAudiovisualDTO)
        {
            return comisionAudiovisualDAO.AgregarRegistro(comisionAudiovisualDTO);
        }

        public ComisionAudiovisualDTO BuscarFormato(int Codigo)
        {
            return comisionAudiovisualDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ComisionAudiovisualDTO comisionAudiovisualDTO)
        {
            return comisionAudiovisualDAO.ActualizaFormato(comisionAudiovisualDTO);
        }

        public bool EliminarFormato(ComisionAudiovisualDTO comisionAudiovisualDTO)
        {
            return comisionAudiovisualDAO.EliminarFormato(comisionAudiovisualDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return comisionAudiovisualDAO.InsertarDatos(datos);
        }
    }
}
