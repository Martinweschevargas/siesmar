using Marina.Siesmar.AccesoDatos.Formatos.Comoperama;
using Marina.Siesmar.Entidades.Formatos.Comoperama;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperama
{
    public class EfectivoNivelEntrenamientoUnidad
    {
        EfectivoNivelEntrenamientoUnidadDAO efectivoNivelEntrenamientoUnidadDAO = new();

        public List<EfectivoNivelEntrenamientoUnidadDTO> ObtenerLista(int? CargaId = null)
        {
            return efectivoNivelEntrenamientoUnidadDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(EfectivoNivelEntrenamientoUnidadDTO efectivoNivelEntrenamientoUnidadDTO)
        {
            return efectivoNivelEntrenamientoUnidadDAO.AgregarRegistro(efectivoNivelEntrenamientoUnidadDTO);
        }

        public EfectivoNivelEntrenamientoUnidadDTO BuscarFormato(int Codigo)
        {
            return efectivoNivelEntrenamientoUnidadDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EfectivoNivelEntrenamientoUnidadDTO efectivoNivelEntrenamientoUnidadDTO)
        {
            return efectivoNivelEntrenamientoUnidadDAO.ActualizaFormato(efectivoNivelEntrenamientoUnidadDTO);
        }

        public bool EliminarFormato(EfectivoNivelEntrenamientoUnidadDTO efectivoNivelEntrenamientoUnidadDTO)
        {
            return efectivoNivelEntrenamientoUnidadDAO.EliminarFormato(efectivoNivelEntrenamientoUnidadDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return efectivoNivelEntrenamientoUnidadDAO.InsertarDatos(datos);
        }

    }
}
