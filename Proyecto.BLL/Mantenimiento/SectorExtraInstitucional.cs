using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SectorExtraInstitucional
    {
        readonly SectorExtraInstitucionalDAO SectorExtraInstitucionalDAO = new();

        public List<SectorExtraInstitucionalDTO> ObtenerCapintanias()
        {
            return SectorExtraInstitucionalDAO.ObtenerSectorExtraInstitucionals();
        }

        public string AgregarSectorExtraInstitucional(SectorExtraInstitucionalDTO sectorExtraInstitucionalDto)
        {
            return SectorExtraInstitucionalDAO.AgregarSectorExtraInstitucional(sectorExtraInstitucionalDto);
        }

        public SectorExtraInstitucionalDTO BuscarSectorExtraInstitucionalID(int Codigo)
        {
            return SectorExtraInstitucionalDAO.BuscarSectorExtraInstitucionalID(Codigo);
        }

        public string ActualizarSectorExtraInstitucional(SectorExtraInstitucionalDTO sectorExtraInstitucionalDto)
        {
            return SectorExtraInstitucionalDAO.ActualizarSectorExtraInstitucional(sectorExtraInstitucionalDto);
        }

        public string EliminarSectorExtraInstitucional(SectorExtraInstitucionalDTO sectorExtraInstitucionalDto)
        {
            return SectorExtraInstitucionalDAO.EliminarSectorExtraInstitucional(sectorExtraInstitucionalDto);
        }

    }
}
