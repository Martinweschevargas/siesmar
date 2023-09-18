using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Formatos.Dintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dintemar
{
    public class EstudioContraintelPersonalExterno
    {
        EstudioContraintelPersonalExternoDAO estudioContraintelPersonalExternoDAO = new();

        public List<EstudioContraintelPersonalExternoDTO> ObtenerLista(int? CargaId = null)
        {
            return estudioContraintelPersonalExternoDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(EstudioContraintelPersonalExternoDTO estudioContraintelPersonalExternoDTO)
        {
            return estudioContraintelPersonalExternoDAO.AgregarRegistro(estudioContraintelPersonalExternoDTO);
        }

        public EstudioContraintelPersonalExternoDTO EditarFormato(int Codigo)
        {
            return estudioContraintelPersonalExternoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EstudioContraintelPersonalExternoDTO estudioContraintelPersonalExternoDTO)
        {
            return estudioContraintelPersonalExternoDAO.ActualizaFormato(estudioContraintelPersonalExternoDTO);
        }

        public bool EliminarFormato(EstudioContraintelPersonalExternoDTO estudioContraintelPersonalExternoDTO)
        {
            return estudioContraintelPersonalExternoDAO.EliminarFormato(estudioContraintelPersonalExternoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return estudioContraintelPersonalExternoDAO.InsertarDatos(datos);
        }

    }
}
