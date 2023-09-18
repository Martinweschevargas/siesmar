using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ProyectoFovimar
    {
        readonly ProyectoFovimarDAO proyectoFovimarDAO = new();

        public List<ProyectoFovimarDTO> ObtenerProyectoFovimars()
        {
            return proyectoFovimarDAO.ObtenerProyectoFovimars();
        }

        public string AgregarProyectoFovimar(ProyectoFovimarDTO proyectoFovimarDto)
        {
            return proyectoFovimarDAO.AgregarProyectoFovimar(proyectoFovimarDto);
        }

        public ProyectoFovimarDTO BuscarProyectoFovimarID(int Codigo)
        {
            return proyectoFovimarDAO.BuscarProyectoFovimarID(Codigo);
        }

        public string ActualizarProyectoFovimar(ProyectoFovimarDTO proyectoFovimarDto)
        {
            return proyectoFovimarDAO.ActualizarProyectoFovimar(proyectoFovimarDto);
        }

        public string EliminarProyectoFovimar(ProyectoFovimarDTO proyectoFovimarDto)
        {
            return proyectoFovimarDAO.EliminarProyectoFovimar(proyectoFovimarDto);
        }

    }
}
