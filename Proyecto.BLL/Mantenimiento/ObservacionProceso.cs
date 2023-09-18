using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ObservacionProceso
    {
        readonly ObservacionProcesoDAO observacionProcesoDAO = new();

        public List<ObservacionProcesoDTO> ObtenerObservacionProcesos()
        {
            return observacionProcesoDAO.ObtenerObservacionProcesos();
        }

        public string AgregarObservacionProceso(ObservacionProcesoDTO observacionProcesoDto)
        {
            return observacionProcesoDAO.AgregarObservacionProceso(observacionProcesoDto);
        }

        public ObservacionProcesoDTO BuscarObservacionProcesoID(int Codigo)
        {
            return observacionProcesoDAO.BuscarObservacionProcesoID(Codigo);
        }

        public string ActualizarObservacionProceso(ObservacionProcesoDTO observacionProcesoDTO)
        {
            return observacionProcesoDAO.ActualizarObservacionProceso(observacionProcesoDTO);
        }

        public bool EliminarObservacionProceso(int Codigo)
        {
            return observacionProcesoDAO.EliminarObservacionProceso(Codigo);
        }

    }
}
