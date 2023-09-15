using Marina.Siesmar.AccesoDatos.Formatos.Dipermar;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dipermar
{
    public class ProcedimientoAdministrativoCivil
    {
        ProcedimientoAdministrativoCivilDAO procedimientoAdministrativoCivilDAO = new();

        public List<ProcedimientoAdministrativoCivilDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return procedimientoAdministrativoCivilDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO, string? fecha = null)
        {
            return procedimientoAdministrativoCivilDAO.AgregarRegistro(procedimientoAdministrativoCivilDTO, fecha);
        }

        public ProcedimientoAdministrativoCivilDTO BuscarFormato(int Codigo)
        {
            return procedimientoAdministrativoCivilDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO)
        {
            return procedimientoAdministrativoCivilDAO.ActualizaFormato(procedimientoAdministrativoCivilDTO);
        }

        public bool EliminarFormato(ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO)
        {
            return procedimientoAdministrativoCivilDAO.EliminarFormato(procedimientoAdministrativoCivilDTO);
        }

        public bool EliminarCarga(ProcedimientoAdministrativoCivilDTO procedimientoAdministrativoCivilDTO)
        {
            return procedimientoAdministrativoCivilDAO.EliminarCarga(procedimientoAdministrativoCivilDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return procedimientoAdministrativoCivilDAO.InsertarDatos(datos, fecha);
        }

    }
}
