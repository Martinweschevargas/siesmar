using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DptoMaterialAcuatico
    {
        readonly DptoMaterialAcuaticoDAO dptoMaterialAcuaticoDAO = new();

        public List<DptoMaterialAcuaticoDTO> ObtenerDptoMaterialAcuaticos()
        {
            return dptoMaterialAcuaticoDAO.ObtenerDptoMaterialAcuaticos();
        }

        public string AgregarDptoMaterialAcuatico(DptoMaterialAcuaticoDTO dptoMaterialAcuaticoDto)
        {
            return dptoMaterialAcuaticoDAO.AgregarDptoMaterialAcuatico(dptoMaterialAcuaticoDto);
        }

        public DptoMaterialAcuaticoDTO BuscarDptoMaterialAcuaticoID(int Codigo)
        {
            return dptoMaterialAcuaticoDAO.BuscarDptoMaterialAcuaticoID(Codigo);
        }

        public string ActualizarDptoMaterialAcuatico(DptoMaterialAcuaticoDTO dptoMaterialAcuaticoDto)
        {
            return dptoMaterialAcuaticoDAO.ActualizarDptoMaterialAcuatico(dptoMaterialAcuaticoDto);
        }

        public string EliminarDptoMaterialAcuatico(DptoMaterialAcuaticoDTO dptoMaterialAcuaticoDto)
        {
            return dptoMaterialAcuaticoDAO.EliminarDptoMaterialAcuatico(dptoMaterialAcuaticoDto);
        }

    }
}
