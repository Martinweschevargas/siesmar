using Marina.Siesmar.AccesoDatos.Formatos.Dihidronav;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dihidronav
{
    public class InformeTecnicoInspeccion
    {
        InformeTecnicoInspeccionDAO informeTecnicoInspeccionDAO = new();

        public List<InformeTecnicoInspeccionDTO> ObtenerLista(int? CargaId = null)
        {
            return informeTecnicoInspeccionDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(InformeTecnicoInspeccionDTO informeTecnicoInspeccion)
        {
            return informeTecnicoInspeccionDAO.AgregarRegistro(informeTecnicoInspeccion);
        }

        public InformeTecnicoInspeccionDTO BuscarFormato(int Codigo)
        {
            return informeTecnicoInspeccionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(InformeTecnicoInspeccionDTO informeTecnicoInspeccionDTO)
        {
            return informeTecnicoInspeccionDAO.ActualizaFormato(informeTecnicoInspeccionDTO);
        }

        public bool EliminarFormato(InformeTecnicoInspeccionDTO informeTecnicoInspeccionDTO)
        {
            return informeTecnicoInspeccionDAO.EliminarFormato( informeTecnicoInspeccionDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return informeTecnicoInspeccionDAO.InsertarDatos(datos);
        }

    }
}
