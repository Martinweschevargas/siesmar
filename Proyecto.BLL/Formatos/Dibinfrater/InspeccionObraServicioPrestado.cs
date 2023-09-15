using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dibinfrater;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dibinfrater;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dibinfrater
{
    public class InspeccionObraServicioPrestado
    {
        InspeccionObraServicioPrestadoDAO inspeccionObraServicioPrestadoDAO = new();

        public List<InspeccionObraServicioPrestadoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return inspeccionObraServicioPrestadoDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO, string? fecha)
        {
            return inspeccionObraServicioPrestadoDAO.AgregarRegistro(inspeccionObraServicioPrestadoDTO, fecha);
        }

        public InspeccionObraServicioPrestadoDTO EditarFormato(int Codigo)
        {
            return inspeccionObraServicioPrestadoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO)
        {
            return inspeccionObraServicioPrestadoDAO.ActualizaFormato(inspeccionObraServicioPrestadoDTO);
        }

        public bool EliminarFormato(InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO)
        {
            return inspeccionObraServicioPrestadoDAO.EliminarFormato(inspeccionObraServicioPrestadoDTO);
        }

        public bool EliminarCarga(InspeccionObraServicioPrestadoDTO inspeccionObraServicioPrestadoDTO)
        {
            return inspeccionObraServicioPrestadoDAO.EliminarCarga(inspeccionObraServicioPrestadoDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return inspeccionObraServicioPrestadoDAO.InsertarDatos(datos, fecha);
        }

    }
}
