using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TrabajoOceanografico
    {
        readonly TrabajoOceanograficoDAO trabajoOceanograficoDAO = new();

        public List<TrabajoOceanograficoDTO> ObtenerTrabajoOceanograficos()
        {
            return trabajoOceanograficoDAO.ObtenerTrabajoOceanograficos();
        }

        public string AgregarTrabajoOceanografico(TrabajoOceanograficoDTO trabajoOceanograficoDto)
        {
            return trabajoOceanograficoDAO.AgregarTrabajoOceanografico(trabajoOceanograficoDto);
        }

        public TrabajoOceanograficoDTO BuscarTrabajoOceanograficoID(int Codigo)
        {
            return trabajoOceanograficoDAO.BuscarTrabajoOceanograficoID(Codigo);
        }

        public string ActualizarTrabajoOceanografico(TrabajoOceanograficoDTO trabajoOceanograficoDTO)
        {
            return trabajoOceanograficoDAO.ActualizarTrabajoOceanografico(trabajoOceanograficoDTO);
        }

        public bool EliminarTrabajoOceanografico(TrabajoOceanograficoDTO trabajoOceanograficoDTO)
        {
            return trabajoOceanograficoDAO.EliminarTrabajoOceanografico(trabajoOceanograficoDTO);
        }

    }
}
