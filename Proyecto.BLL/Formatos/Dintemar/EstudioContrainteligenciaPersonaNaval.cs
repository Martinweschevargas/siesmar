using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dintemar
{
    public class EstudioContrainteligenciaPersonaNaval
    {
        EstudioContrainteligenciaPersonaNavalDAO estudioContraintelPersonaCivilDAO = new();

        public List<EstudioContrainteligenciaPersonaNavalDTO> ObtenerLista(int? CargaId = null)
        {
            return estudioContraintelPersonaCivilDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(EstudioContrainteligenciaPersonaNavalDTO estudioContraintelPersonaCivilDTO)
        {
            return estudioContraintelPersonaCivilDAO.AgregarRegistro(estudioContraintelPersonaCivilDTO);
        }

        public EstudioContrainteligenciaPersonaNavalDTO EditarFormato(int Codigo)
        {
            return estudioContraintelPersonaCivilDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EstudioContrainteligenciaPersonaNavalDTO estudioContraintelPersonaCivilDTO)
        {
            return estudioContraintelPersonaCivilDAO.ActualizaFormato(estudioContraintelPersonaCivilDTO);
        }

        public bool EliminarFormato(EstudioContrainteligenciaPersonaNavalDTO estudioContraintelPersonaCivilDTO)
        {
            return estudioContraintelPersonaCivilDAO.EliminarFormato(estudioContraintelPersonaCivilDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return estudioContraintelPersonaCivilDAO.InsertarDatos(datos);
        }
    }
}
