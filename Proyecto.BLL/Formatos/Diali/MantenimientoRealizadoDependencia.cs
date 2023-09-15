using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diali
{
    public class MantenimientoRealizadoDependencia
    {
        MantenimientoRealizadoDependenciaDAO mantenimientoRealizadoDependenciaDAO = new();

        public List<MantenimientoRealizadoDependenciaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return mantenimientoRealizadoDependenciaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDependencia, string? fecha)
        {
            return mantenimientoRealizadoDependenciaDAO.AgregarRegistro(mantenimientoRealizadoDependencia, fecha);
        }

        public MantenimientoRealizadoDependenciaDTO EditarFormato(int Codigo)
        {
            return mantenimientoRealizadoDependenciaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDependenciaDTO)
        {
            return mantenimientoRealizadoDependenciaDAO.ActualizaFormato(mantenimientoRealizadoDependenciaDTO);
        }

        public bool EliminarFormato(MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDTO)
        {
            return mantenimientoRealizadoDependenciaDAO.EliminarFormato(mantenimientoRealizadoDTO);
        }

        public bool EliminarCarga(MantenimientoRealizadoDependenciaDTO mantenimientoRealizadoDTO)
        {
            return mantenimientoRealizadoDependenciaDAO.EliminarCarga(mantenimientoRealizadoDTO);
        }
        public string InsertarDatos(DataTable datos, string fecha)
        {
            return mantenimientoRealizadoDependenciaDAO.InsertarDatos(datos, fecha);
        }
    }
}
