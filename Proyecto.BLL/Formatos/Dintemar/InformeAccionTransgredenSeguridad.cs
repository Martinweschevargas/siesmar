using Marina.Siesmar.AccesoDatos.Formatos.Dintemar;
using Marina.Siesmar.Entidades.Formatos.Dintemar;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dintemar
{
    public class InformeAccionTransgredenSeguridad
    {
        InformeAccionTransgredenSeguridadDAO informeAccionTransgredenSeguridadDAO = new();

        public List<InformeAccionTransgredenSeguridadDTO> ObtenerLista()
        {
            return informeAccionTransgredenSeguridadDAO.ObtenerLista();
        }

        public string AgregarRegistro(InformeAccionTransgredenSeguridadDTO informeAccionTransgredenSeguridadDTO)
        {
            return informeAccionTransgredenSeguridadDAO.AgregarRegistro(informeAccionTransgredenSeguridadDTO);
        }

        public InformeAccionTransgredenSeguridadDTO EditarFormato(int Codigo)
        {
            return informeAccionTransgredenSeguridadDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(InformeAccionTransgredenSeguridadDTO informeAccionTransgredenSeguridadDTO)
        {
            return informeAccionTransgredenSeguridadDAO.ActualizaFormato(informeAccionTransgredenSeguridadDTO);
        }

        public bool EliminarFormato(InformeAccionTransgredenSeguridadDTO informeAccionTransgredenSeguridadDTO)
        {
            return informeAccionTransgredenSeguridadDAO.EliminarFormato(informeAccionTransgredenSeguridadDTO);
        }

        public bool InsertarRegistros(IEnumerable<InformeAccionTransgredenSeguridadDTO> informeAccionTransgredenSeguridadDTO)
        {
            return InsertarRegistros(informeAccionTransgredenSeguridadDTO);
        }

    }
}
