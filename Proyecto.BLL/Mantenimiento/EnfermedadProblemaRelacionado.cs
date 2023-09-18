using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class EnfermedadProblemaRelacionado
    {
        readonly EnfermedadProblemaRelacionadoDAO enfermedadProblemaRelacionadoDAO = new();

        public List<EnfermedadProblemaRelacionadoDTO> ObtenerEnfermedadProblemaRelacionados()
        {
            return enfermedadProblemaRelacionadoDAO.ObtenerEnfermedadProblemaRelacionados();
        }

        public string AgregarEnfermedadProblemaRelacionado(EnfermedadProblemaRelacionadoDTO enfermedadProblemaRelacionadoDto)
        {
            return enfermedadProblemaRelacionadoDAO.AgregarEnfermedadProblemaRelacionado(enfermedadProblemaRelacionadoDto);
        }

        public EnfermedadProblemaRelacionadoDTO BuscarEnfermedadProblemaRelacionadoID(int Codigo)
        {
            return enfermedadProblemaRelacionadoDAO.BuscarEnfermedadProblemaRelacionadoID(Codigo);
        }

        public string ActualizarEnfermedadProblemaRelacionado(EnfermedadProblemaRelacionadoDTO enfermedadProblemaRelacionadoDto)
        {
            return enfermedadProblemaRelacionadoDAO.ActualizarEnfermedadProblemaRelacionado(enfermedadProblemaRelacionadoDto);
        }

        public string EliminarEnfermedadProblemaRelacionado(EnfermedadProblemaRelacionadoDTO enfermedadProblemaRelacionadoDto)
        {
            return enfermedadProblemaRelacionadoDAO.EliminarEnfermedadProblemaRelacionado(enfermedadProblemaRelacionadoDto);
        }

    }
}
