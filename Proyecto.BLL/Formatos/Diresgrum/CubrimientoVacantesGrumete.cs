using Marina.Siesmar.AccesoDatos.Formatos.Diresgrum;
using Marina.Siesmar.Entidades.Formatos.Diresgrum;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diresgrum
{
    public class CubrimientoVacantesGrumete
    {
        CubrimientoVacantesGrumeteDAO cubrimientoVacantesGrumeteDAO = new();

        public List<CubrimientoVacantesGrumeteDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return cubrimientoVacantesGrumeteDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO, string? fecha = null)
        {
            return cubrimientoVacantesGrumeteDAO.AgregarRegistro(cubrimientoVacantesGrumeteDTO, fecha);
        }

        public CubrimientoVacantesGrumeteDTO EditarFormato(int Codigo)
        {
            return cubrimientoVacantesGrumeteDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO)
        {
            return cubrimientoVacantesGrumeteDAO.ActualizaFormato(cubrimientoVacantesGrumeteDTO);
        }

        public bool EliminarFormato(CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO)
        {
            return cubrimientoVacantesGrumeteDAO.EliminarFormato(cubrimientoVacantesGrumeteDTO);
        }

        public bool EliminarCarga(CubrimientoVacantesGrumeteDTO cubrimientoVacantesGrumeteDTO)
        {
            return cubrimientoVacantesGrumeteDAO.EliminarCarga(cubrimientoVacantesGrumeteDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return cubrimientoVacantesGrumeteDAO.InsertarDatos(datos, fecha);
        }

    }
}
