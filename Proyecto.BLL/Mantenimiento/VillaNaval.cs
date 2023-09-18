using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class VillaNaval
    {
        readonly VillaNavalDAO villaNavalDAO = new();

        public List<VillaNavalDTO> ObtenerVillaNavals()
        {
            return villaNavalDAO.ObtenerVillaNavals();
        }

        public string AgregarVillaNaval(VillaNavalDTO villaNavalDto)
        {
            return villaNavalDAO.AgregarVillaNaval(villaNavalDto);
        }

        public VillaNavalDTO BuscarVillaNavalID(int Codigo)
        {
            return villaNavalDAO.BuscarVillaNavalID(Codigo);
        }

        public string ActualizarVillaNaval(VillaNavalDTO villaNavalDto)
        {
            return villaNavalDAO.ActualizarVillaNaval(villaNavalDto);
        }

        public string EliminarVillaNaval(VillaNavalDTO villaNavalDto)
        {
            return villaNavalDAO.EliminarVillaNaval(villaNavalDto);
        }

    }
}
