using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class CanalDenuncia
    {
        readonly CanalDenunciaDAO canalDenunciaDAO = new();

        public List<CanalDenunciaDTO> ObtenerCanalDenuncias()
        {
            return canalDenunciaDAO.ObtenerCanalDenuncias();
        }

        public string AgregarCanalDenuncia(CanalDenunciaDTO canalDenunciaDto)
        {
            return canalDenunciaDAO.AgregarCanalDenuncia(canalDenunciaDto);
        }

        public CanalDenunciaDTO BuscarCanalDenunciaID(int Codigo)
        {
            return canalDenunciaDAO.BuscarCanalDenunciaID(Codigo);
        }

        public string ActualizarCanalDenuncia(CanalDenunciaDTO canalDenunciaDTO)
        {
            return canalDenunciaDAO.ActualizarCanalDenuncia(canalDenunciaDTO);
        }

        public string EliminarCanalDenuncia(CanalDenunciaDTO canalDenunciaDTO)
        {
            return canalDenunciaDAO.EliminarCanalDenuncia(canalDenunciaDTO);
        }

    }
}
