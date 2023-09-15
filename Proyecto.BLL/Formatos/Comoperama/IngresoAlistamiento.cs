using Marina.Siesmar.AccesoDatos.Formatos.Comoperama;
using Marina.Siesmar.Entidades.Formatos.Comoperama;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperama
{
    public class IngresoAlistamiento
    {
        IngresoAlistamientoDAO ingresoAlistamientoDAO = new();

        public List<IngresoAlistamientoDTO> ObtenerLista(int? CargaId = null)
        {
            return ingresoAlistamientoDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(IngresoAlistamientoDTO ingresoAlistamientoDTO)
        {
            return ingresoAlistamientoDAO.AgregarRegistro(ingresoAlistamientoDTO);
        }

        public IngresoAlistamientoDTO BuscarFormato(int Codigo)
        {
            return ingresoAlistamientoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(IngresoAlistamientoDTO ingresoAlistamientoDTO)
        {
            return ingresoAlistamientoDAO.ActualizaFormato(ingresoAlistamientoDTO);
        }

        public bool EliminarFormato(IngresoAlistamientoDTO ingresoAlistamientoDTO)
        {
            return ingresoAlistamientoDAO.EliminarFormato(ingresoAlistamientoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return ingresoAlistamientoDAO.InsertarDatos(datos);
        }

    }
}
