using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dircapen;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dircapen;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dircapen
{
    public class DocentesCapacitacionPerfeccionamiento
    {
        DocentesCapacitacionPerfeccionamientoDAO docentesCapacitacionPerfecDAO = new();

        public List<DocentesCapacitacionPerfeccionamientoDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return docentesCapacitacionPerfecDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO, string? fecha = null)
        {
            return docentesCapacitacionPerfecDAO.AgregarRegistro(docentesCapacitacionPerfecDTO, fecha);
        }

        public DocentesCapacitacionPerfeccionamientoDTO EditarFormato(int Codigo)
        {
            return docentesCapacitacionPerfecDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO)
        {
            return docentesCapacitacionPerfecDAO.ActualizaFormato(docentesCapacitacionPerfecDTO);
        }

        public bool EliminarFormato(DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO)
        {
            return docentesCapacitacionPerfecDAO.EliminarFormato(docentesCapacitacionPerfecDTO);
        }

        public bool EliminarCarga(DocentesCapacitacionPerfeccionamientoDTO docentesCapacitacionPerfecDTO)
        {
            return docentesCapacitacionPerfecDAO.EliminarCarga(docentesCapacitacionPerfecDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return docentesCapacitacionPerfecDAO.InsertarDatos(datos, fecha);
        }

    }
}
