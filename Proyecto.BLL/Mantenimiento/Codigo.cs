using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Codigo
    {
        readonly CodigoDAO codigoDAO = new();

        public List<CodigoDTO> ObtenerCodigos()
        {
            return codigoDAO.ObtenerCodigos();
        }

        public string AgregarCodigo(CodigoDTO codigoDto)
        {
            return codigoDAO.AgregarCodigo(codigoDto);
        }

        public CodigoDTO BuscarCodigoID(int Codigo)
        {
            return codigoDAO.BuscarCodigoID(Codigo);
        }

        public string ActualizarCodigo(CodigoDTO codigoDto)
        {
            return codigoDAO.ActualizarCodigo(codigoDto);
        }

        public string EliminarCodigo(CodigoDTO codigoDto)
        {
            return codigoDAO.EliminarCodigo(codigoDto);
        }

    }
}
