using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CondicionEgresoHospitalizacion
    {
        readonly CondicionEgresoHospitalizacionDAO condicionEgresoHospitalizacionDAO = new();

        public List<CondicionEgresoHospitalizacionDTO> ObtenerCondicionEgresoHospitalizacions()
        {
            return condicionEgresoHospitalizacionDAO.ObtenerCondicionEgresoHospitalizacions();
        }

        public string AgregarCondicionEgresoHospitalizacion(CondicionEgresoHospitalizacionDTO condicionEgresoHospitalizacionDto)
        {
            return condicionEgresoHospitalizacionDAO.AgregarCondicionEgresoHospitalizacion(condicionEgresoHospitalizacionDto);
        }

        public CondicionEgresoHospitalizacionDTO BuscarCondicionEgresoHospitalizacionID(int Codigo)
        {
            return condicionEgresoHospitalizacionDAO.BuscarCondicionEgresoHospitalizacionID(Codigo);
        }

        public string ActualizarCondicionEgresoHospitalizacion(CondicionEgresoHospitalizacionDTO condicionEgresoHospitalizacionDto)
        {
            return condicionEgresoHospitalizacionDAO.ActualizarCondicionEgresoHospitalizacion(condicionEgresoHospitalizacionDto);
        }

        public string EliminarCondicionEgresoHospitalizacion(CondicionEgresoHospitalizacionDTO condicionEgresoHospitalizacionDto)
        {
            return condicionEgresoHospitalizacionDAO.EliminarCondicionEgresoHospitalizacion(condicionEgresoHospitalizacionDto);
        }

    }
}
