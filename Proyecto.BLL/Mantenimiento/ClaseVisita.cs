using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ClaseVisita
    {
        readonly ClaseVisitaDAO claseVisitaDAO = new();

        public List<ClaseVisitaDTO> ObtenerClaseVisitas()
        {
            return claseVisitaDAO.ObtenerClaseVisitas();
        }

        public string AgregarClaseVisita(ClaseVisitaDTO claseVisitaDto)
        {
            return claseVisitaDAO.AgregarClaseVisita(claseVisitaDto);
        }

        public ClaseVisitaDTO BuscarClaseVisitaID(int Codigo)
        {
            return claseVisitaDAO.BuscarClaseVisitaID(Codigo);
        }

        public string ActualizarClaseVisita(ClaseVisitaDTO claseVisitaDto)
        {
            return claseVisitaDAO.ActualizarClaseVisita(claseVisitaDto);
        }

        public string EliminarClaseVisita(ClaseVisitaDTO claseVisitaDto)
        {
            return claseVisitaDAO.EliminarClaseVisita(claseVisitaDto);
        }

    }
}
