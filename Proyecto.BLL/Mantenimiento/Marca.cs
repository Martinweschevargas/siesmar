using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class Marca
    {
        readonly MarcaDAO marcaDAO = new();

        public List<MarcaDTO> ObtenerMarcas()
        {
            return marcaDAO.ObtenerMarcas();
        }

        public string AgregarMarca(MarcaDTO marcaDto)
        {
            return marcaDAO.AgregarMarca(marcaDto);
        }

        public MarcaDTO BuscarMarcaID(int Codigo)
        {
            return marcaDAO.BuscarMarcaID(Codigo);
        }

        public string ActualizarMarca(MarcaDTO marcaDto)
        {
            return marcaDAO.ActualizarMarca(marcaDto);
        }

        public string EliminarMarca(MarcaDTO marcaDto)
        {
            return marcaDAO.EliminarMarca(marcaDto);
        }

    }
}
