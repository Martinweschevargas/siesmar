using Marina.Siesmar.AccesoDatos.Formatos.Comoperpac;
using Marina.Siesmar.Entidades.Formatos.Comoperpac;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperpac
{
    public class EfectivoCompaniaIntervencionRapida
    {
        EfectivoCompaniaIntervencionRapidaDAO efectivoCompaniaIntervencionRapidaDAO = new();

        public List<EfectivoCompaniaIntervencionRapidaDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return efectivoCompaniaIntervencionRapidaDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO, string? fecha = null)
        {
            return efectivoCompaniaIntervencionRapidaDAO.AgregarRegistro(efectivoCompaniaIntervencionRapidaDTO, fecha);
        }

        public EfectivoCompaniaIntervencionRapidaDTO EditarFormato(int Codigo)
        {
            return efectivoCompaniaIntervencionRapidaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO)
        {
            return efectivoCompaniaIntervencionRapidaDAO.ActualizaFormato(efectivoCompaniaIntervencionRapidaDTO);
        }

        public bool EliminarFormato(EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO)
        {
            return efectivoCompaniaIntervencionRapidaDAO.EliminarFormato(efectivoCompaniaIntervencionRapidaDTO);
        }

        public bool EliminarCarga(EfectivoCompaniaIntervencionRapidaDTO efectivoCompaniaIntervencionRapidaDTO)
        {
            return efectivoCompaniaIntervencionRapidaDAO.EliminarCarga(efectivoCompaniaIntervencionRapidaDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return efectivoCompaniaIntervencionRapidaDAO.InsertarDatos(datos, fecha);
        }

    }
}
