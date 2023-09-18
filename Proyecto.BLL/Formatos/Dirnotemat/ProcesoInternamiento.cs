using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dirnotemat;
using Marina.Siesmar.Entidades.Formatos.Dirnotemat;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirnotemat
{
    public class ProcesoInternamiento
    {
        ProcesoInternamientoDAO procesoInternamientoDAO = new();

        public List<ProcesoInternamientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return procesoInternamientoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ProcesoInternamientoDTO procesoInternamiento, string? fecha)
        {
            return procesoInternamientoDAO.AgregarRegistro(procesoInternamiento, fecha);
        }

        public ProcesoInternamientoDTO EditarFormato(int Codigo)
        {
            return procesoInternamientoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ProcesoInternamientoDTO procesoInternamientoDTO)
        {
            return procesoInternamientoDAO.ActualizaFormato(procesoInternamientoDTO);
        }

        public bool EliminarFormato(ProcesoInternamientoDTO procesoInternamientoDTO)
        {
            return procesoInternamientoDAO.EliminarFormato(procesoInternamientoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return procesoInternamientoDAO.InsertarDatos(datos, fecha);
        }

    }
}
