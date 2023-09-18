using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PosicionTipoArma
    {
        readonly PosicionTipoArmaDAO posicionTipoArmaDAO = new();

        public List<PosicionTipoArmaDTO> ObtenerPosicionTipoArmas()
        {
            return posicionTipoArmaDAO.ObtenerPosicionTipoArmas();
        }

        public string AgregarPosicionTipoArma(PosicionTipoArmaDTO posicionTipoArmaDto)
        {
            return posicionTipoArmaDAO.AgregarPosicionTipoArma(posicionTipoArmaDto);
        }

        public PosicionTipoArmaDTO BuscarPosicionTipoArmaID(int Codigo)
        {
            return posicionTipoArmaDAO.BuscarPosicionTipoArmaID(Codigo);
        }

        public string ActualizarPosicionTipoArma(PosicionTipoArmaDTO posicionTipoArmaDto)
        {
            return posicionTipoArmaDAO.ActualizarPosicionTipoArma(posicionTipoArmaDto);
        }

        public string EliminarPosicionTipoArma(PosicionTipoArmaDTO posicionTipoArmaDto)
        {
            return posicionTipoArmaDAO.EliminarPosicionTipoArma(posicionTipoArmaDto);
        }

    }
}
