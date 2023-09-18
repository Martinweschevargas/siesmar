using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dirciten;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirciten;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dirciten
{
    public class InformacionDocente
    {
        InformacionDocenteDAO informacionDocenteDAO = new();

        public List<InformacionDocenteDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return informacionDocenteDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(InformacionDocenteDTO informacionDocenteDTO, string? fecha)
        {
            return informacionDocenteDAO.AgregarRegistro(informacionDocenteDTO, fecha);
        }

        public InformacionDocenteDTO EditarFormato(int Codigo)
        {
            return informacionDocenteDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(InformacionDocenteDTO informacionDocenteDTO)
        {
            return informacionDocenteDAO.ActualizaFormato(informacionDocenteDTO);
        }

        public bool EliminarFormato(InformacionDocenteDTO informacionDocenteDTO)
        {
            return informacionDocenteDAO.EliminarFormato(informacionDocenteDTO);
        }

        public bool EliminarCarga(InformacionDocenteDTO informacionDocenteDTO)
        {
            return informacionDocenteDAO.EliminarCarga(informacionDocenteDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return informacionDocenteDAO.InsertarDatos(datos, fecha);
        }

    }
}
