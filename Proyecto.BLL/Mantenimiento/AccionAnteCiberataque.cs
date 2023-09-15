using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AccionAnteCiberataque
    {
        readonly AccionAnteCiberataqueDAO accionAnteCiberataqueDAO = new();

        public List<AccionAnteCiberataqueDTO> ObtenerAccionAnteCiberataques()
        {
            return accionAnteCiberataqueDAO.ObtenerAccionAnteCiberataques();
        }

        public string AgregarAccionAnteCiberataque(AccionAnteCiberataqueDTO accionAnteCiberataqueDto)
        {
            return accionAnteCiberataqueDAO.AgregarAccionAnteCiberataque(accionAnteCiberataqueDto);
        }

        public AccionAnteCiberataqueDTO BuscarAccionAnteCiberataqueID(int Codigo)
        {
            return accionAnteCiberataqueDAO.BuscarAccionAnteCiberataqueID(Codigo);
        }

        public string ActualizarAccionAnteCiberataque(AccionAnteCiberataqueDTO accionAnteCiberataqueDto)
        {
            return accionAnteCiberataqueDAO.ActualizarAccionAnteCiberataque(accionAnteCiberataqueDto);
        }

        public string EliminarAccionAnteCiberataque(AccionAnteCiberataqueDTO accionAnteCiberataqueDto)
        {
            return accionAnteCiberataqueDAO.EliminarAccionAnteCiberataque(accionAnteCiberataqueDto);
        }

    }
}
