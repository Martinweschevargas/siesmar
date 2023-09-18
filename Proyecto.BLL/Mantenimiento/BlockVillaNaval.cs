using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class BlockVillaNaval
    {
        readonly BlockVillaNavalDAO blockVillaNavalDAO = new();

        public List<BlockVillaNavalDTO> ObtenerBlockVillaNavals()
        {
            return blockVillaNavalDAO.ObtenerBlockVillaNavals();
        }

        public string AgregarBlockVillaNaval(BlockVillaNavalDTO blockVillaNavalDto)
        {
            return blockVillaNavalDAO.AgregarBlockVillaNaval(blockVillaNavalDto);
        }

        public BlockVillaNavalDTO BuscarBlockVillaNavalID(int Codigo)
        {
            return blockVillaNavalDAO.BuscarBlockCodigoVillaNaval(Codigo);
        }

        public string ActualizarBlockVillaNaval(BlockVillaNavalDTO blockVillaNavalDto)
        {
            return blockVillaNavalDAO.ActualizarBlockVillaNaval(blockVillaNavalDto);
        }

        public string EliminarBlockVillaNaval(BlockVillaNavalDTO blockVillaNavalDto)
        {
            return blockVillaNavalDAO.EliminarBlockVillaNaval(blockVillaNavalDto);
        }

    }
}
