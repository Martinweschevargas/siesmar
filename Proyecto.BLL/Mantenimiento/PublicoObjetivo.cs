using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class PublicoObjetivo
    {
        readonly PublicoObjetivoDAO publicoObjetivoDAO = new();

        public List<PublicoObjetivoDTO> ObtenerPublicoObjetivos()
        {
            return publicoObjetivoDAO.ObtenerPublicoObjetivos();
        }

        public string AgregarPublicoObjetivo(PublicoObjetivoDTO publicoObjetivoDto)
        {
            return publicoObjetivoDAO.AgregarPublicoObjetivo(publicoObjetivoDto);
        }

        public PublicoObjetivoDTO BuscarPublicoObjetivoID(int Codigo)
        {
            return publicoObjetivoDAO.BuscarPublicoObjetivoID(Codigo);
        }

        public string ActualizarPublicoObjetivo(PublicoObjetivoDTO publicoObjetivoDTO)
        {
            return publicoObjetivoDAO.ActualizarPublicoObjetivo(publicoObjetivoDTO);
        }

        public bool EliminarPublicoObjetivo(PublicoObjetivoDTO publicoObjetivoDTO)
        {
            return publicoObjetivoDAO.EliminarPublicoObjetivo(publicoObjetivoDTO);
        }

    }
}
