using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class AutoridadEmiteZarpe
    {
        readonly AutoridadEmiteZarpeDAO AutoridadEmiteZarpeDAO = new();

        public List<AutoridadEmiteZarpeDTO> ObtenerCapintanias()
        {
            return AutoridadEmiteZarpeDAO.ObtenerAutoridadEmiteZarpes();
        }

        public string AgregarAutoridadEmiteZarpe(AutoridadEmiteZarpeDTO autoridadEmiteZarpeDto)
        {
            return AutoridadEmiteZarpeDAO.AgregarAutoridadEmiteZarpe(autoridadEmiteZarpeDto);
        }

        public AutoridadEmiteZarpeDTO BuscarAutoridadEmiteZarpeID(int Codigo)
        {
            return AutoridadEmiteZarpeDAO.BuscarAutoridadEmiteZarpeID(Codigo);
        }

        public string ActualizarAutoridadEmiteZarpe(AutoridadEmiteZarpeDTO autoridadEmiteZarpeDto)
        {
            return AutoridadEmiteZarpeDAO.ActualizarAutoridadEmiteZarpe(autoridadEmiteZarpeDto);
        }

        public string EliminarAutoridadEmiteZarpe(AutoridadEmiteZarpeDTO autoridadEmiteZarpeDto)
        {
            return AutoridadEmiteZarpeDAO.EliminarAutoridadEmiteZarpe(autoridadEmiteZarpeDto);
        }

    }
}
