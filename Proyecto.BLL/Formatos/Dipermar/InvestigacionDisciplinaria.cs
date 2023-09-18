using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dipermar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dipermar
{
    public class InvestigacionDisciplinaria
    {
        InvestigacionDisciplinariaDAO investigacionDisciplinariaDAO = new();

        public List<InvestigacionDisciplinariaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return investigacionDisciplinariaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO, string? fecha)
        {
            return investigacionDisciplinariaDAO.AgregarRegistro(investigacionDisciplinariaDTO, fecha);
        }

        public InvestigacionDisciplinariaDTO BuscarFormato(int Codigo)
        {
            return investigacionDisciplinariaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO)
        {
            return investigacionDisciplinariaDAO.ActualizaFormato(investigacionDisciplinariaDTO);
        }

        public bool EliminarFormato(InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO)
        {
            return investigacionDisciplinariaDAO.EliminarFormato(investigacionDisciplinariaDTO);
        }

        public bool EliminarCarga(InvestigacionDisciplinariaDTO investigacionDisciplinariaDTO)
        {
            return investigacionDisciplinariaDAO.EliminarCarga(investigacionDisciplinariaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return investigacionDisciplinariaDAO.InsertarDatos(datos, fecha);
        }


    }
}
