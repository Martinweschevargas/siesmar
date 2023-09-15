using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Dipermar;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dipermar;
using Marina.Siesmar.LogicaNegocios.Seguridad;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dipermar
{
    public class JuntaPermanenteTecnicoLegal
    {
        JuntaPermanenteTecnicoLegalDAO juntaPermanenteTecnicoLegalDAO = new();

        public List<JuntaPermanenteTecnicoLegalDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return juntaPermanenteTecnicoLegalDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO, string? fecha)
        {
            return juntaPermanenteTecnicoLegalDAO.AgregarRegistro(juntaPermanenteTecnicoLegalDTO, fecha);
        }

        public JuntaPermanenteTecnicoLegalDTO BuscarFormato(int Codigo)
        {
            return juntaPermanenteTecnicoLegalDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO)
        {
            return juntaPermanenteTecnicoLegalDAO.ActualizaFormato(juntaPermanenteTecnicoLegalDTO);
        }

        public bool EliminarFormato(JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO)
        {
            return juntaPermanenteTecnicoLegalDAO.EliminarFormato(juntaPermanenteTecnicoLegalDTO);
        }

        public bool EliminarCarga(JuntaPermanenteTecnicoLegalDTO juntaPermanenteTecnicoLegalDTO)
        {
            return juntaPermanenteTecnicoLegalDAO.EliminarCarga(juntaPermanenteTecnicoLegalDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return juntaPermanenteTecnicoLegalDAO.InsertarDatos(datos, fecha);
        }

    }
}
