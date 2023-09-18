using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class TramiteGestionPatrimonial
    {
        readonly TramiteGestionPatrimonialDAO tramiteGestionPatrimonialDAO = new();

        public List<TramiteGestionPatrimonialDTO> ObtenerTramiteGestionPatrimonials()
        {
            return tramiteGestionPatrimonialDAO.ObtenerTramiteGestionPatrimonials();
        }

        public string AgregarTramiteGestionPatrimonial(TramiteGestionPatrimonialDTO tramiteGestionPatrimonialDto)
        {
            return tramiteGestionPatrimonialDAO.AgregarTramiteGestionPatrimonial(tramiteGestionPatrimonialDto);
        }

        public TramiteGestionPatrimonialDTO BuscarTramiteGestionPatrimonialID(int Codigo)
        {
            return tramiteGestionPatrimonialDAO.BuscarTramiteGestionPatrimonialID(Codigo);
        }

        public string ActualizarTramiteGestionPatrimonial(TramiteGestionPatrimonialDTO tramiteGestionPatrimonialDTO)
        {
            return tramiteGestionPatrimonialDAO.ActualizarTramiteGestionPatrimonial(tramiteGestionPatrimonialDTO);
        }

        public bool EliminarTramiteGestionPatrimonial(TramiteGestionPatrimonialDTO tramiteGestionPatrimonialDTO)
        {
            return tramiteGestionPatrimonialDAO.EliminarTramiteGestionPatrimonial(tramiteGestionPatrimonialDTO);
        }

    }
}
