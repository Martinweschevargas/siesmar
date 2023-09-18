using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dirciten;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirciten
{
    public class EstudiantesPreCiten
    {
        EstudiantesPreCitenDAO estudiantesPreCitenDAO = new();

        public List<EstudiantesPreCitenDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return estudiantesPreCitenDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EstudiantesPreCitenDTO estudiantesPreCitenDTO, string? fecha)
        {
            return estudiantesPreCitenDAO.AgregarRegistro(estudiantesPreCitenDTO, fecha);
        }

        public EstudiantesPreCitenDTO EditarFormato(int Codigo)
        {
            return estudiantesPreCitenDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EstudiantesPreCitenDTO estudiantesPreCitenDTO)
        {
            return estudiantesPreCitenDAO.ActualizaFormato(estudiantesPreCitenDTO);
        }

        public bool EliminarFormato(EstudiantesPreCitenDTO estudiantesPreCitenDTO)
        {
            return estudiantesPreCitenDAO.EliminarFormato(estudiantesPreCitenDTO);
        }

        public bool EliminarCarga(EstudiantesPreCitenDTO estudiantesPreCitenDTO)
        {
            return estudiantesPreCitenDAO.EliminarCarga(estudiantesPreCitenDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return estudiantesPreCitenDAO.InsertarDatos(datos, fecha);
        }

    }
}
