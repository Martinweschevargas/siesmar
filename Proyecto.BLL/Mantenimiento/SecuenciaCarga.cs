using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class SecuenciaCarga
    {
        readonly SecuenciaCargaDAO secuenciaCargaDAO = new();

        public List<SecuenciaCargaDTO> ObtenerSecuenciaCargas()
        {
            return secuenciaCargaDAO.ObtenerSecuenciaCargas();
        }

        public string AgregarSecuenciaCarga(SecuenciaCargaDTO secuenciaCargaDto)
        {
            return secuenciaCargaDAO.AgregarSecuenciaCarga(secuenciaCargaDto);
        }

        public SecuenciaCargaDTO BuscarSecuenciaCargaID(string NOM_TABLA)
        {
            return secuenciaCargaDAO.BuscarSecuenciaCargaID(NOM_TABLA);
        }

        public string ActualizarSecuenciaCarga(SecuenciaCargaDTO secuenciaCargaDto)
        {
            return secuenciaCargaDAO.ActualizarSecuenciaCarga(secuenciaCargaDto);
        }

        public string EliminarSecuenciaCarga(SecuenciaCargaDTO secuenciaCargaDto)
        {
            return secuenciaCargaDAO.EliminarSecuenciaCarga(secuenciaCargaDto);
        }

    }
}
