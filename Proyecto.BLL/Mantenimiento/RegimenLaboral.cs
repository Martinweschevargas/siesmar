using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class RegimenLaboral
    {
        readonly RegimenLaboralDAO regimenLaboralDAO = new();

        public List<RegimenLaboralDTO> ObtenerRegimenLaborals()
        {
            return regimenLaboralDAO.ObtenerRegimenLaborals();
        }

        public string AgregarRegimenLaboral(RegimenLaboralDTO regimenLaboralDto)
        {
            return regimenLaboralDAO.AgregarRegimenLaboral(regimenLaboralDto);
        }

        public RegimenLaboralDTO BuscarRegimenLaboralID(int Codigo)
        {
            return regimenLaboralDAO.BuscarRegimenLaboralID(Codigo);
        }

        public string ActualizarRegimenLaboral(RegimenLaboralDTO regimenLaboralDTO)
        {
            return regimenLaboralDAO.ActualizarRegimenLaboral(regimenLaboralDTO);
        }

        public string EliminarRegimenLaboral(RegimenLaboralDTO regimenLaboralDTO)
        {
            return regimenLaboralDAO.EliminarRegimenLaboral(regimenLaboralDTO);
        }

    }
}
