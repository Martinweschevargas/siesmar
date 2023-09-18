using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TrabajoHidrografico
    {
        readonly TrabajoHidrograficoDAO trabajoHidrograficoDAO = new();

        public List<TrabajoHidrograficoDTO> ObtenerTrabajoHidrograficos()
        {
            return trabajoHidrograficoDAO.ObtenerTrabajoHidrograficos();
        }

        public string AgregarTrabajoHidrografico(TrabajoHidrograficoDTO trabajoHidrograficoDto)
        {
            return trabajoHidrograficoDAO.AgregarTrabajoHidrografico(trabajoHidrograficoDto);
        }

        public TrabajoHidrograficoDTO BuscarTrabajoHidrograficoID(int Codigo)
        {
            return trabajoHidrograficoDAO.BuscarTrabajoHidrograficoID(Codigo);
        }

        public string ActualizarTrabajoHidrografico(TrabajoHidrograficoDTO trabajoHidrograficoDto)
        {
            return trabajoHidrograficoDAO.ActualizarTrabajoHidrografico(trabajoHidrograficoDto);
        }

        public string EliminarTrabajoHidrografico(TrabajoHidrograficoDTO trabajoHidrograficoDto)
        {
            return trabajoHidrograficoDAO.EliminarTrabajoHidrografico(trabajoHidrograficoDto);
        }

    }
}
