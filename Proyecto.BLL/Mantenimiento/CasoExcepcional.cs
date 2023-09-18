using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CasoExcepcional
    {
        readonly CasoExcepcionalDAO casoExcepcionalDAO = new();

        public List<CasoExcepcionalDTO> ObtenerCasoExcepcionals()
        {
            return casoExcepcionalDAO.ObtenerCasoExcepcionals();
        }

        public string AgregarCasoExcepcional(CasoExcepcionalDTO casoExcepcionalDto)
        {
            return casoExcepcionalDAO.AgregarCasoExcepcional(casoExcepcionalDto);
        }

        public CasoExcepcionalDTO BuscarCasoExcepcionalID(int Codigo)
        {
            return casoExcepcionalDAO.BuscarCasoExcepcionalID(Codigo);
        }

        public string ActualizarCasoExcepcional(CasoExcepcionalDTO casoExcepcionalDto)
        {
            return casoExcepcionalDAO.ActualizarCasoExcepcional(casoExcepcionalDto);
        }

        public string EliminarCasoExcepcional(CasoExcepcionalDTO casoExcepcionalDto)
        {
            return casoExcepcionalDAO.EliminarCasoExcepcional(casoExcepcionalDto);
        }

    }
}