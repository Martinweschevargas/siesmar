using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DenominacionBaseDato
    {
        readonly DenominacionBaseDatoDAO denominacionBaseDatosDAO = new();

        public List<DenominacionBaseDatoDTO> ObtenerDenominacionBaseDatos()
        {
            return denominacionBaseDatosDAO.ObtenerDenominacionBaseDatos();
        }

        public string AgregarDenominacionBaseDato(DenominacionBaseDatoDTO denominacionBaseDatosDto)
        {
            return denominacionBaseDatosDAO.AgregarDenominacionBaseDato(denominacionBaseDatosDto);
        }

        public DenominacionBaseDatoDTO BuscarDenominacionBaseDatoID(int Codigo)
        {
            return denominacionBaseDatosDAO.BuscarDenominacionBaseDatoID(Codigo);
        }

        public string ActualizarDenominacionBaseDato(DenominacionBaseDatoDTO denominacionBaseDatosDTO)
        {
            return denominacionBaseDatosDAO.ActualizarDenominacionBaseDato(denominacionBaseDatosDTO);
        }

        public string EliminarDenominacionBaseDato(DenominacionBaseDatoDTO denominacionBaseDatosDTO)
        {
            return denominacionBaseDatosDAO.EliminarDenominacionBaseDato(denominacionBaseDatosDTO);
        }

    }
}
