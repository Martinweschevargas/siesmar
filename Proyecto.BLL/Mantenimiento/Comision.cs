using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Comision
    {
        readonly ComisionDAO comisionDAO = new();

        public List<ComisionDTO> ObtenerComisions()
        {
            return comisionDAO.ObtenerComisions();
        }

        public string AgregarComision(ComisionDTO comisionDto)
        {
            return comisionDAO.AgregarComision(comisionDto);
        }

        public ComisionDTO BuscarComisionID(int Codigo)
        {
            return comisionDAO.BuscarComisionID(Codigo);
        }

        public string ActualizarComision(ComisionDTO comisionDto)
        {
            return comisionDAO.ActualizarComision(comisionDto);
        }

        public string EliminarComision(ComisionDTO comisionDto)
        {
            return comisionDAO.EliminarComision(comisionDto);
        }

    }
}
