using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class FaseInversion
    {
        readonly FaseInversionDAO faseInversionDAO = new();

        public List<FaseInversionDTO> ObtenerFaseInversions()
        {
            return faseInversionDAO.ObtenerFaseInversions();
        }

        public string AgregarFaseInversion(FaseInversionDTO faseInversionDto)
        {
            return faseInversionDAO.AgregarFaseInversion(faseInversionDto);
        }

        public FaseInversionDTO BuscarFaseInversionID(int Codigo)
        {
            return faseInversionDAO.BuscarFaseInversionID(Codigo);
        }

        public string ActualizarFaseInversion(FaseInversionDTO faseInversionDto)
        {
            return faseInversionDAO.ActualizarFaseInversion(faseInversionDto);
        }

        public string EliminarFaseInversion(FaseInversionDTO faseInversionDto)
        {
            return faseInversionDAO.EliminarFaseInversion(faseInversionDto);
        }

    }
}
