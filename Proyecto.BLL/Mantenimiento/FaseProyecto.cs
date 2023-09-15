using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class FaseProyecto
    {
        readonly FaseProyectoDAO faseProyectoDAO = new();

        public List<FaseProyectoDTO> ObtenerFaseProyectos()
        {
            return faseProyectoDAO.ObtenerFaseProyectos();
        }

        public string AgregarFaseProyecto(FaseProyectoDTO faseProyectoDto)
        {
            return faseProyectoDAO.AgregarFaseProyecto(faseProyectoDto);
        }

        public FaseProyectoDTO BuscarFaseProyectoID(int Codigo)
        {
            return faseProyectoDAO.BuscarFaseProyectoID(Codigo);
        }

        public string ActualizarFaseProyecto(FaseProyectoDTO faseProyectoDTO)
        {
            return faseProyectoDAO.ActualizarFaseProyecto(faseProyectoDTO);
        }

        public bool EliminarFaseProyecto(FaseProyectoDTO faseProyectoDTO)
        {
            return faseProyectoDAO.EliminarFaseProyecto(faseProyectoDTO);
        }

    }
}