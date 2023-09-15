using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DireccionTecnica
    {
        readonly DireccionTecnicaDAO direccionTecnicaDAO = new();

        public List<DireccionTecnicaDTO> ObtenerDireccionTecnicas()
        {
            return direccionTecnicaDAO.ObtenerDireccionTecnicas();
        }

        public string AgregarDireccionTecnica(DireccionTecnicaDTO direccionTecnicaDto)
        {
            return direccionTecnicaDAO.AgregarDireccionTecnica(direccionTecnicaDto);
        }

        public DireccionTecnicaDTO BuscarDireccionTecnicaID(int Codigo)
        {
            return direccionTecnicaDAO.BuscarDireccionTecnicaID(Codigo);
        }

        public string ActualizarDireccionTecnica(DireccionTecnicaDTO direccionTecnicaDTO)
        {
            return direccionTecnicaDAO.ActualizarDireccionTecnica(direccionTecnicaDTO);
        }

        public bool EliminarDireccionTecnica(DireccionTecnicaDTO direccionTecnicaDTO)
        {
            return direccionTecnicaDAO.EliminarDireccionTecnica(direccionTecnicaDTO);
        }

    }
}
