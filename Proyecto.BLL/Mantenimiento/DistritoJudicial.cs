using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DistritoJudicial
    {
        readonly DistritoJudicialDAO distritoJudicialDAO = new();

        public List<DistritoJudicialDTO> ObtenerDistritoJudiciales()
        {
            return distritoJudicialDAO.ObtenerDistritoJudiciales();
        }

        public string AgregarDistritoJudicial(DistritoJudicialDTO distritoJudicialDto)
        {
            return distritoJudicialDAO.AgregarDistritoJudicial(distritoJudicialDto);
        }

        public DistritoJudicialDTO BuscarDistritoJudicialID(int Codigo)
        {
            return distritoJudicialDAO.BuscarDistritoJudicialID(Codigo);
        }

        public string ActualizarDistritoJudicial(DistritoJudicialDTO distritoJudicialDTO)
        {
            return distritoJudicialDAO.ActualizarDistritoJudicial(distritoJudicialDTO);
        }

        public bool EliminarDistritoJudicial(int Codigo)
        {
            return distritoJudicialDAO.EliminarDistritoJudicial(Codigo);
        }

    }
}
