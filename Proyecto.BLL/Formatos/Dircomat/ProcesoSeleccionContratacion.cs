using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dircomat;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dircomat;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dircomat
{
    public class ProcesoSeleccionContratacion
    {
        ProcesoSeleccionContratacionDAO procesoSeleccionContratacionDAO = new();

        public List<ProcesoSeleccionContratacionDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return procesoSeleccionContratacionDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ProcesoSeleccionContratacionDTO procesoSeleccionContratacion, string? fecha)
        {
            return procesoSeleccionContratacionDAO.AgregarRegistro(procesoSeleccionContratacion, fecha);
        }

        public ProcesoSeleccionContratacionDTO EditarFormato(int Codigo)
        {
            return procesoSeleccionContratacionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ProcesoSeleccionContratacionDTO procesoSeleccionContratacionDTO)
        {
            return procesoSeleccionContratacionDAO.ActualizaFormato(procesoSeleccionContratacionDTO);
        }

        public bool EliminarFormato(ProcesoSeleccionContratacionDTO procesoSeleccionContratacionDTO)
        {
            return procesoSeleccionContratacionDAO.EliminarFormato(procesoSeleccionContratacionDTO);
        }


        public bool EliminarCarga(ProcesoSeleccionContratacionDTO procesoSeleccionContratacionDTO)
        {
            return procesoSeleccionContratacionDAO.EliminarCarga(procesoSeleccionContratacionDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return procesoSeleccionContratacionDAO.InsertarDatos(datos, fecha);
        }


    }
}
