using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class InspeccionFinalidad
    {
        readonly InspeccionFinalidadDAO inspeccionFinalidadDAO = new();

        public List<InspeccionFinalidadDTO> ObtenerInspeccionFinalidads()
        {
            return inspeccionFinalidadDAO.ObtenerInspeccionFinalidads();
        }

        public string AgregarInspeccionFinalidad(InspeccionFinalidadDTO inspeccionFinalidadDto)
        {
            return inspeccionFinalidadDAO.AgregarInspeccionFinalidad(inspeccionFinalidadDto);
        }

        public InspeccionFinalidadDTO BuscarInspeccionFinalidadID(int Codigo)
        {
            return inspeccionFinalidadDAO.BuscarInspeccionFinalidadID(Codigo);
        }

        public string ActualizarInspeccionFinalidad(InspeccionFinalidadDTO inspeccionFinalidadDto)
        {
            return inspeccionFinalidadDAO.ActualizarInspeccionFinalidad(inspeccionFinalidadDto);
        }

        public string EliminarInspeccionFinalidad(InspeccionFinalidadDTO inspeccionFinalidadDto)
        {
            return inspeccionFinalidadDAO.EliminarInspeccionFinalidad(inspeccionFinalidadDto);
        }

    }
}
