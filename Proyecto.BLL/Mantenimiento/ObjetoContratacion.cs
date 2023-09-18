using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ObjetoContratacion
    {
        readonly ObjetoContratacionDAO objetoContratacionDAO = new();

        public List<ObjetoContratacionDTO> ObtenerObjetoContratacions()
        {
            return objetoContratacionDAO.ObtenerObjetoContratacions();
        }

        public string AgregarObjetoContratacion(ObjetoContratacionDTO objetoContratacionDto)
        {
            return objetoContratacionDAO.AgregarObjetoContratacion(objetoContratacionDto);
        }

        public ObjetoContratacionDTO BuscarObjetoContratacionID(int Codigo)
        {
            return objetoContratacionDAO.BuscarObjetoContratacionID(Codigo);
        }

        public string ActualizarObjetoContratacion(ObjetoContratacionDTO objetoContratacionDTO)
        {
            return objetoContratacionDAO.ActualizarObjetoContratacion(objetoContratacionDTO);
        }

        public bool EliminarObjetoContratacion(int Codigo)
        {
            return objetoContratacionDAO.EliminarObjetoContratacion(Codigo);
        }

    }
}
