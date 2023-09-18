using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class InstanciaJudicial
    {
        readonly InstanciaJudicialDAO instanciaJudicialDAO = new();

        public List<InstanciaJudicialDTO> ObtenerInstanciaJudicials()
        {
            return instanciaJudicialDAO.ObtenerInstanciaJudicials();
        }

        public string AgregarInstanciaJudicial(InstanciaJudicialDTO instanciaJudicialDto)
        {
            return instanciaJudicialDAO.AgregarInstanciaJudicial(instanciaJudicialDto);
        }

        public InstanciaJudicialDTO BuscarInstanciaJudicialID(int Codigo)
        {
            return instanciaJudicialDAO.BuscarInstanciaJudicialID(Codigo);
        }

        public string ActualizarInstanciaJudicial(InstanciaJudicialDTO instanciaJudicialDTO)
        {
            return instanciaJudicialDAO.ActualizarInstanciaJudicial(instanciaJudicialDTO);
        }

        public string EliminarInstanciaJudicial(InstanciaJudicialDTO instanciaJudicialDTO)
        {
            return instanciaJudicialDAO.EliminarInstanciaJudicial(instanciaJudicialDTO);
        }

    }
}
