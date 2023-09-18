using Marina.Siesmar.AccesoDatos.Seguridad;
using Marina.Siesmar.Entidades.Seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Marina.Siesmar.LogicaNegocios.Seguridad
{
    public class DependenciaSubordinado
    {
        DependenciaSubordinadoDAO dependenciaSubordinadoDAO = new DependenciaSubordinadoDAO();

        public List<DependenciaSubordinadoDTO> ObtenerDependenciaSubordinados()
        {
            return dependenciaSubordinadoDAO.ObtenerDependenciaSubordinados();
        }

        public string AgregarDependenciaSubordinado(DependenciaSubordinadoDTO dependenciasubordinadoDto)
        {
            return dependenciaSubordinadoDAO.AgregarDependenciaSubordinado(dependenciasubordinadoDto);
        }

        public DependenciaSubordinadoDTO EditarDependenciaSubordinado(int Codigo)
        {
            return dependenciaSubordinadoDAO.BuscarDependenciaSubordinadoID(Codigo);
        }

        public string ActualizaDependenciaSubordinado(DependenciaSubordinadoDTO dependenciaSubordinadoDto)
        {
            return dependenciaSubordinadoDAO.ActualizarDependenciaSubordinado(dependenciaSubordinadoDto);
        }

        public string EliminarDependenciaSubordinado(DependenciaSubordinadoDTO dependenciaSubordinadoDto)
        {
            return dependenciaSubordinadoDAO.EliminarDependenciaSubordinado(dependenciaSubordinadoDto);
        }

    }
}
