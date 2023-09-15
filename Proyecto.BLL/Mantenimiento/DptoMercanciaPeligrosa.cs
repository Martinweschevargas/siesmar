using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DptoMercanciaPeligrosa
    {
        readonly DptoMercanciaPeligrosaDAO dptoMercanciaPeligrosaDAO = new();

        public List<DptoMercanciaPeligrosaDTO> ObtenerDptoMercanciaPeligrosas()
        {
            return dptoMercanciaPeligrosaDAO.ObtenerDptoMercanciaPeligrosas();
        }

        public string AgregarDptoMercanciaPeligrosa(DptoMercanciaPeligrosaDTO dptoMercanciaPeligrosaDto)
        {
            return dptoMercanciaPeligrosaDAO.AgregarDptoMercanciaPeligrosa(dptoMercanciaPeligrosaDto);
        }

        public DptoMercanciaPeligrosaDTO BuscarDptoMercanciaPeligrosaID(int Codigo)
        {
            return dptoMercanciaPeligrosaDAO.BuscarDptoMercanciaPeligrosaID(Codigo);
        }

        public string ActualizarDptoMercanciaPeligrosa(DptoMercanciaPeligrosaDTO dptoMercanciaPeligrosaDto)
        {
            return dptoMercanciaPeligrosaDAO.ActualizarDptoMercanciaPeligrosa(dptoMercanciaPeligrosaDto);
        }

        public string EliminarDptoMercanciaPeligrosa(DptoMercanciaPeligrosaDTO dptoMercanciaPeligrosaDto)
        {
            return dptoMercanciaPeligrosaDAO.EliminarDptoMercanciaPeligrosa(dptoMercanciaPeligrosaDto);
        }

    }
}
