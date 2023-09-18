using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SeveridadCiberataque
    {
        readonly SeveridadCiberataqueDAO severidadCiberataqueDAO = new();

        public List<SeveridadCiberataqueDTO> ObtenerSeveridadCiberataques()
        {
            return severidadCiberataqueDAO.ObtenerSeveridadCiberataques();
        }

        public string AgregarSeveridadCiberataque(SeveridadCiberataqueDTO severidadCiberataqueDto)
        {
            return severidadCiberataqueDAO.AgregarSeveridadCiberataque(severidadCiberataqueDto);
        }

        public SeveridadCiberataqueDTO BuscarSeveridadCiberataqueID(int Codigo)
        {
            return severidadCiberataqueDAO.BuscarSeveridadCiberataqueID(Codigo);
        }

        public string ActualizarSeveridadCiberataque(SeveridadCiberataqueDTO severidadCiberataqueDto)
        {
            return severidadCiberataqueDAO.ActualizarSeveridadCiberataque(severidadCiberataqueDto);
        }

        public string EliminarSeveridadCiberataque(SeveridadCiberataqueDTO severidadCiberataqueDto)
        {
            return severidadCiberataqueDAO.EliminarSeveridadCiberataque(severidadCiberataqueDto);
        }

    }
}
