using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CodigoEscuela
    {
        readonly CodigoEscuelaDAO codigoEscuelaDAO = new();

        public List<CodigoEscuelaDTO> ObtenerCodigoEscuelas()
        {
            return codigoEscuelaDAO.ObtenerCodigoEscuelas();
        }

        public string AgregarCodigoEscuela(CodigoEscuelaDTO codigoEscuelaDto)
        {
            return codigoEscuelaDAO.AgregarCodigoEscuela(codigoEscuelaDto);
        }

        public CodigoEscuelaDTO BuscarCodigoEscuelaID(int Codigo)
        {
            return codigoEscuelaDAO.BuscarCodigoEscuelaID(Codigo);
        }

        public string ActualizarCodigoEscuela(CodigoEscuelaDTO codigoEscuelaDTO)
        {
            return codigoEscuelaDAO.ActualizarCodigoEscuela(codigoEscuelaDTO);
        }

        public string EliminarCodigoEscuela(CodigoEscuelaDTO codigoEscuelaDTO)
        {
            return codigoEscuelaDAO.EliminarCodigoEscuela(codigoEscuelaDTO);
        }

    }
}
