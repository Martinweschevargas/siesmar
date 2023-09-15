using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class UbicacionCIRD
    {
        readonly UbicacionCIRDDAO ubicacionCIRDDAO = new();

        public List<UbicacionCIRDDTO> ObtenerUbicacionCIRDs()
        {
            return ubicacionCIRDDAO.ObtenerUbicacionCIRDs();
        }

        public string AgregarUbicacionCIRD(UbicacionCIRDDTO ubicacionCIRDDto)
        {
            return ubicacionCIRDDAO.AgregarUbicacionCIRD(ubicacionCIRDDto);
        }

        public UbicacionCIRDDTO BuscarUbicacionCIRDID(int Codigo)
        {
            return ubicacionCIRDDAO.BuscarUbicacionCIRDID(Codigo);
        }

        public string ActualizarUbicacionCIRD(UbicacionCIRDDTO ubicacionCIRDDto)
        {
            return ubicacionCIRDDAO.ActualizarUbicacionCIRD(ubicacionCIRDDto);
        }

        public string EliminarUbicacionCIRD(UbicacionCIRDDTO ubicacionCIRDDto)
        {
            return ubicacionCIRDDAO.EliminarUbicacionCIRD(ubicacionCIRDDto);
        }

    }
}
