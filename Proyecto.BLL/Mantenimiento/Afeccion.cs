using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Afeccion
    {
        readonly AfeccionDAO afeccionDAO = new();

        public List<AfeccionDTO> ObtenerAfeccions()
        {
            return afeccionDAO.ObtenerAfeccions();
        }

        public string AgregarAfeccion(AfeccionDTO afeccionDto)
        {
            return afeccionDAO.AgregarAfeccion(afeccionDto);
        }

        public AfeccionDTO BuscarAfeccionID(int Codigo)
        {
            return afeccionDAO.BuscarAfeccionID(Codigo);
        }

        public string ActualizarAfeccion(AfeccionDTO afeccionDTO)
        {
            return afeccionDAO.ActualizarAfeccion(afeccionDTO);
        }

        public string EliminarAfeccion(AfeccionDTO afeccionDTO)
        {
            return afeccionDAO.EliminarAfeccion(afeccionDTO);
        }

    }
}
