using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class UnidadMedida
    {
        readonly UnidadMedidaDAO unidadMedidaDAO = new();

        public List<UnidadMedidaDTO> ObtenerUnidadMedidas()
        {
            return unidadMedidaDAO.ObtenerUnidadMedidas();
        }

        public string AgregarUnidadMedida(UnidadMedidaDTO unidadMedidaDto)
        {
            return unidadMedidaDAO.AgregarUnidadMedida(unidadMedidaDto);
        }

        public UnidadMedidaDTO BuscarUnidadMedidaID(int Codigo)
        {
            return unidadMedidaDAO.BuscarUnidadMedidaID(Codigo);
        }

        public string ActualizarUnidadMedida(UnidadMedidaDTO unidadMedidaDto)
        {
            return unidadMedidaDAO.ActualizarUnidadMedida(unidadMedidaDto);
        }

        public string EliminarUnidadMedida(UnidadMedidaDTO unidadMedidaDto)
        {
            return unidadMedidaDAO.EliminarUnidadMedida(unidadMedidaDto);
        }

    }
}
