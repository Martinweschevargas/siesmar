using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GradoEstudioAlcanzado
    {
        readonly GradoEstudioAlcanzadoDAO gradoEstudioAlcanzadoDAO = new();

        public List<GradoEstudioAlcanzadoDTO> ObtenerGradoEstudioAlcanzados()
        {
            return gradoEstudioAlcanzadoDAO.ObtenerGradoEstudioAlcanzados();
        }

        public string AgregarGradoEstudioAlcanzado(GradoEstudioAlcanzadoDTO gradoEstudioAlcanzadoDto)
        {
            return gradoEstudioAlcanzadoDAO.AgregarGradoEstudioAlcanzado(gradoEstudioAlcanzadoDto);
        }

        public GradoEstudioAlcanzadoDTO BuscarGradoEstudioAlcanzadoID(int Codigo)
        {
            return gradoEstudioAlcanzadoDAO.BuscarGradoEstudioAlcanzadoID(Codigo);
        }

        public string ActualizarGradoEstudioAlcanzado(GradoEstudioAlcanzadoDTO gradoEstudioAlcanzadoDTO)
        {
            return gradoEstudioAlcanzadoDAO.ActualizarGradoEstudioAlcanzado(gradoEstudioAlcanzadoDTO);
        }

        public string EliminarGradoEstudioAlcanzado(GradoEstudioAlcanzadoDTO gradoEstudioAlcanzadoDTO)
        {
            return gradoEstudioAlcanzadoDAO.EliminarGradoEstudioAlcanzado(gradoEstudioAlcanzadoDTO);
        }

    }
}
