using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DptoPersonalAcuatico
    {
        readonly DptoPersonalAcuaticoDAO dptoPersonalAcuaticoDAO = new();

        public List<DptoPersonalAcuaticoDTO> ObtenerDptoPersonalAcuaticos()
        {
            return dptoPersonalAcuaticoDAO.ObtenerDptoPersonalAcuaticos();
        }

        public string AgregarDptoPersonalAcuatico(DptoPersonalAcuaticoDTO dptoPersonalAcuaticoDto)
        {
            return dptoPersonalAcuaticoDAO.AgregarDptoPersonalAcuatico(dptoPersonalAcuaticoDto);
        }

        public DptoPersonalAcuaticoDTO BuscarDptoPersonalAcuaticoID(int Codigo)
        {
            return dptoPersonalAcuaticoDAO.BuscarDptoPersonalAcuaticoID(Codigo);
        }

        public string ActualizarDptoPersonalAcuatico(DptoPersonalAcuaticoDTO dptoPersonalAcuaticoDTO)
        {
            return dptoPersonalAcuaticoDAO.ActualizarDptoPersonalAcuatico(dptoPersonalAcuaticoDTO);
        }

        public bool EliminarDptoPersonalAcuatico(DptoPersonalAcuaticoDTO dptoPersonalAcuaticoDTO)
        {
            return dptoPersonalAcuaticoDAO.EliminarDptoPersonalAcuatico(dptoPersonalAcuaticoDTO);
        }

    }
}
