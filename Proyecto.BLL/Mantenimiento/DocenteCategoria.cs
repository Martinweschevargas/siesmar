using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DocenteCategoria
    {
        readonly DocenteCategoriaDAO docenteCategoriaDAO = new();

        public List<DocenteCategoriaDTO> ObtenerDocenteCategorias()
        {
            return docenteCategoriaDAO.ObtenerDocenteCategorias();
        }

        public string AgregarDocenteCategoria(DocenteCategoriaDTO docenteCategoriaDto)
        {
            return docenteCategoriaDAO.AgregarDocenteCategoria(docenteCategoriaDto);
        }

        public DocenteCategoriaDTO BuscarDocenteCategoriaID(int Codigo)
        {
            return docenteCategoriaDAO.BuscarDocenteCategoriaID(Codigo);
        }

        public string ActualizarDocenteCategoria(DocenteCategoriaDTO docenteCategoriaDto)
        {
            return docenteCategoriaDAO.ActualizarDocenteCategoria(docenteCategoriaDto);
        }

        public string EliminarDocenteCategoria(DocenteCategoriaDTO docenteCategoriaDto)
        {
            return docenteCategoriaDAO.EliminarDocenteCategoria(docenteCategoriaDto);
        }

    }
}
