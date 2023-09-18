using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AreaTecnica
    {
        readonly AreaTecnicaDAO areaTecnicaDAO = new();

        public List<AreaTecnicaDTO> ObtenerAreaTecnicas()
        {
            return areaTecnicaDAO.ObtenerAreaTecnicas();
        }

        public string AgregarAreaTecnica(AreaTecnicaDTO areaTecnicaDto)
        {
            return areaTecnicaDAO.AgregarAreaTecnica(areaTecnicaDto);
        }

        public AreaTecnicaDTO BuscarAreaTecnicaID(int Codigo)
        {
            return areaTecnicaDAO.BuscarAreaTecnicaID(Codigo);
        }

        public string ActualizarAreaTecnica(AreaTecnicaDTO areaTecnicaDTO)
        {
            return areaTecnicaDAO.ActualizarAreaTecnica(areaTecnicaDTO);
        }

        public bool EliminarAreaTecnica(AreaTecnicaDTO areaTecnicaDTO)
        {
            return areaTecnicaDAO.EliminarAreaTecnica(areaTecnicaDTO);
        }

    }
}