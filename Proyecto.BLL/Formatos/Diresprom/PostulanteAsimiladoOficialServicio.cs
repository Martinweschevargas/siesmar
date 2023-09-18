using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.AccesoDatos.Formatos.Diresprom;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diresprom;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diresprom
{
    public class PostulanteAsimiladoOficialServicio
    {
        PostulanteAsimiladoOficialServicioDAO postulanteAsimiladoOficialServicioDAO = new();

        public List<PostulanteAsimiladoOficialServicioDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return postulanteAsimiladoOficialServicioDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO, string? fecha = null)
        {
            return postulanteAsimiladoOficialServicioDAO.AgregarRegistro(postulanteAsimiladoOficialServicioDTO, fecha);
        }

        public PostulanteAsimiladoOficialServicioDTO EditarFormado(int Codigo)
        {
            return postulanteAsimiladoOficialServicioDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO)
        {
            return postulanteAsimiladoOficialServicioDAO.ActualizaFormato(postulanteAsimiladoOficialServicioDTO);
        }

        public bool EliminarFormato(PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO)
        {
            return postulanteAsimiladoOficialServicioDAO.EliminarFormato(postulanteAsimiladoOficialServicioDTO);
        }

        public bool EliminarCarga(PostulanteAsimiladoOficialServicioDTO postulanteAsimiladoOficialServicioDTO)
        {
            return postulanteAsimiladoOficialServicioDAO.EliminarCarga(postulanteAsimiladoOficialServicioDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return postulanteAsimiladoOficialServicioDAO.InsertarDatos(datos, fecha);
        }

    }
}
