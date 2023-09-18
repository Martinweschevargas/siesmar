using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Seguridad
{
    public class NivelDependencia
    {

        readonly NivelDependenciaDAO nivelDependenciaDAO = new();

        public List<NivelDependenciaDTO> ObtenerNivelDependencias()
        {
            return nivelDependenciaDAO.ObtenerNivelDependencias();
        }

        public string AgregarNivelDependencia(NivelDependenciaDTO nivelDependenciaDto)
        {
            return nivelDependenciaDAO.AgregarNivelDependencia(nivelDependenciaDto);
        }

        public NivelDependenciaDTO BuscarNivelDependenciaID(int Codigo)
        {
            return nivelDependenciaDAO.BuscarNivelDependenciaID(Codigo);
        }

        public string ActualizarNivelDependencia(NivelDependenciaDTO nivelDependenciaDTO)
        {
            return nivelDependenciaDAO.ActualizarNivelDependencia(nivelDependenciaDTO);
        }

        public string EliminarNivelDependencia(NivelDependenciaDTO nivelDependenciaDTO)
        {
            return nivelDependenciaDAO.EliminarNivelDependencia(nivelDependenciaDTO);

        }

    }
}
