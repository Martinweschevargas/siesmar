using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TituloProfesionalObtenido
    {
        readonly TituloProfesionalObtenidoDAO tituloProfesionalObtenidoDAO = new();

        public List<TituloProfesionalObtenidoDTO> ObtenerTituloProfesionalObtenidos()
        {
            return tituloProfesionalObtenidoDAO.ObtenerTituloProfesionalObtenidos();
        }

        public string AgregarTituloProfesionalObtenido(TituloProfesionalObtenidoDTO tituloProfesionalObtenidoDto)
        {
            return tituloProfesionalObtenidoDAO.AgregarTituloProfesionalObtenido(tituloProfesionalObtenidoDto);
        }

        public TituloProfesionalObtenidoDTO BuscarTituloProfesionalObtenidoID(int Codigo)
        {
            return tituloProfesionalObtenidoDAO.BuscarTituloProfesionalObtenidoID(Codigo);
        }

        public string ActualizarTituloProfesionalObtenido(TituloProfesionalObtenidoDTO tituloProfesionalObtenidoDTO)
        {
            return tituloProfesionalObtenidoDAO.ActualizarTituloProfesionalObtenido(tituloProfesionalObtenidoDTO);
        }

        public bool EliminarTituloProfesionalObtenido(TituloProfesionalObtenidoDTO tituloProfesionalObtenidoDTO)
        {
            return tituloProfesionalObtenidoDAO.EliminarTituloProfesionalObtenido(tituloProfesionalObtenidoDTO);
        }

    }
}
