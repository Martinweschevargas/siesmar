using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class ComunicadoEmisionMes
    {
        ComunicadoEmisionMesDAO comunicadoEmisionMesDAO = new();

        public List<ComunicadoEmisionMesDTO> ObtenerLista(int? CargaId = null)
        {
            return comunicadoEmisionMesDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(ComunicadoEmisionMesDTO comunicadoEmisionMesDTO)
        {
            return comunicadoEmisionMesDAO.AgregarRegistro(comunicadoEmisionMesDTO);
        }

        public ComunicadoEmisionMesDTO BuscarFormato(int Codigo)
        {
            return comunicadoEmisionMesDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ComunicadoEmisionMesDTO comunicadoEmisionMesDTO)
        {
            return comunicadoEmisionMesDAO.ActualizaFormato(comunicadoEmisionMesDTO);
        }

        public bool EliminarFormato(ComunicadoEmisionMesDTO comunicadoEmisionMesDTO)
        {
            return comunicadoEmisionMesDAO.EliminarFormato(comunicadoEmisionMesDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return comunicadoEmisionMesDAO.InsertarDatos(datos);
        }

    }
}
