using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CargoDotacion
    {
        readonly CargoDotacionDAO cargoDotacionDAO = new();

        public List<CargoDotacionDTO> ObtenerCargoDotacions()
        {
            return cargoDotacionDAO.ObtenerCargoDotacions();
        }

        public string AgregarCargoDotacion(CargoDotacionDTO cargoDotacionDto)
        {
            return cargoDotacionDAO.AgregarCargoDotacion(cargoDotacionDto);
        }

        public CargoDotacionDTO BuscarCargoDotacionID(int Codigo)
        {
            return cargoDotacionDAO.BuscarCargoDotacionID(Codigo);
        }

        public string ActualizarCargoDotacion(CargoDotacionDTO cargoDotacionDto)
        {
            return cargoDotacionDAO.ActualizarCargoDotacion(cargoDotacionDto);
        }

        public string EliminarCargoDotacion(CargoDotacionDTO cargoDotacionDto)
        {
            return cargoDotacionDAO.EliminarCargoDotacion(cargoDotacionDto);
        }

    }
}
