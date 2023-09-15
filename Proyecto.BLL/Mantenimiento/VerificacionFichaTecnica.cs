using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class VerificacionFichaTecnica
    {
        readonly VerificacionFichaTecnicaDAO verificacionFichaTecnicaDAO = new();

        public List<VerificacionFichaTecnicaDTO> ObtenerVerificacionFichaTecnicas()
        {
            return verificacionFichaTecnicaDAO.ObtenerVerificacionFichaTecnicas();
        }

        public string AgregarVerificacionFichaTecnica(VerificacionFichaTecnicaDTO verificacionFichaTecnicaDto)
        {
            return verificacionFichaTecnicaDAO.AgregarVerificacionFichaTecnica(verificacionFichaTecnicaDto);
        }

        public VerificacionFichaTecnicaDTO BuscarVerificacionFichaTecnicaID(int Codigo)
        {
            return verificacionFichaTecnicaDAO.BuscarVerificacionFichaTecnicaID(Codigo);
        }

        public string ActualizarVerificacionFichaTecnica(VerificacionFichaTecnicaDTO verificacionFichaTecnicaDTO)
        {
            return verificacionFichaTecnicaDAO.ActualizarVerificacionFichaTecnica(verificacionFichaTecnicaDTO);
        }

        public bool EliminarVerificacionFichaTecnica(VerificacionFichaTecnicaDTO verificacionFichaTecnicaDTO)
        {
            return verificacionFichaTecnicaDAO.EliminarVerificacionFichaTecnica(verificacionFichaTecnicaDTO);
        }

    }
}
