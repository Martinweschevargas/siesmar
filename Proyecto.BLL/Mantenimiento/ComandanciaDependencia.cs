using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ComandanciaDependencia
    {
        readonly ComandanciaDependenciaDAO comandanciaDependenciaDAO = new();

        public List<ComandanciaDependenciaDTO> ObtenerComandanciaDependencias()
        {
            return comandanciaDependenciaDAO.ObtenerComandanciaDependencias();
        }

        public string AgregarComandanciaDependencia(ComandanciaDependenciaDTO comandanciaDependenciaDto)
        {
            return comandanciaDependenciaDAO.AgregarComandanciaDependencia(comandanciaDependenciaDto);
        }

        public ComandanciaDependenciaDTO BuscarComandanciaDependenciaID(int Codigo)
        {
            return comandanciaDependenciaDAO.BuscarComandanciaDependenciaID(Codigo);
        }

        public string ActualizarComandanciaDependencia(ComandanciaDependenciaDTO comandanciaDependenciaDTO)
        {
            return comandanciaDependenciaDAO.ActualizarComandanciaDependencia(comandanciaDependenciaDTO);
        }

        public string EliminarComandanciaDependencia(ComandanciaDependenciaDTO comandanciaDependenciaDTO)
        {
            return comandanciaDependenciaDAO.EliminarComandanciaDependencia(comandanciaDependenciaDTO);
        }

    }
}
