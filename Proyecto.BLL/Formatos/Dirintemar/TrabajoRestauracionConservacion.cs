using Marina.Siesmar.AccesoDatos.Formatos.Dirintemar;
using Marina.Siesmar.Entidades.Formatos.Dirintemar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirintemar
{
    public class TrabajoRestauracionConservacion
    {
        TrabajoRestauracionConservacionDAO trabajoRestauracionConservacionDAO = new();

        public List<TrabajoRestauracionConservacionDTO> ObtenerLista()
        {
            return trabajoRestauracionConservacionDAO.ObtenerLista();
        }

        public string AgregarRegistro(TrabajoRestauracionConservacionDTO trabajoRestauracionConservacion)
        {
            return trabajoRestauracionConservacionDAO.AgregarRegistro(trabajoRestauracionConservacion);
        }

        public TrabajoRestauracionConservacionDTO EditarFormato(int Codigo)
        {
            return trabajoRestauracionConservacionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(TrabajoRestauracionConservacionDTO trabajoRestauracionConservacionDTO)
        {
            return trabajoRestauracionConservacionDAO.ActualizaFormato(trabajoRestauracionConservacionDTO);
        }

        public bool EliminarFormato(TrabajoRestauracionConservacionDTO trabajoRestauracionConservacionDTO)
        {
            return trabajoRestauracionConservacionDAO.EliminarFormato(trabajoRestauracionConservacionDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return trabajoRestauracionConservacionDAO.InsertarDatos(datos);
        }

    }
}
