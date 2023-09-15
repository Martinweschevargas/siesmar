using Marina.Siesmar.AccesoDatos.Formatos.Diresprom;
using Marina.Siesmar.Entidades.Formatos.Diresprom;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diresprom
{
    public class Programa2daEspecializacionSuperior
    {
        Programa2daEspecializacionSuperiorDAO programa2daEspecializacionSDAO = new();

        public List<Programa2daEspecializacionSuperiorDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return programa2daEspecializacionSDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSDTO, string? fecha = null)
        {
            return programa2daEspecializacionSDAO.AgregarRegistro(programa2daEspecializacionSDTO, fecha);
        }

        public Programa2daEspecializacionSuperiorDTO BuscarFormato(int Codigo)
        {
            return programa2daEspecializacionSDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSDTO)
        {
            return programa2daEspecializacionSDAO.ActualizaFormato(programa2daEspecializacionSDTO);
        }

        public bool EliminarFormato(Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSDTO)
        {
            return programa2daEspecializacionSDAO.EliminarFormato(programa2daEspecializacionSDTO);
        }

        public bool EliminarCarga(Programa2daEspecializacionSuperiorDTO programa2daEspecializacionSDTO)
        {
            return programa2daEspecializacionSDAO.EliminarCarga(programa2daEspecializacionSDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return programa2daEspecializacionSDAO.InsertarDatos(datos, fecha);
        }

    }
}
