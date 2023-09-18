using Marina.Siesmar.AccesoDatos.Formatos.Dimar;
using Marina.Siesmar.Entidades.Formatos.Dimar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Dimar
{
    public class AtencionProtocolarAeropuertoCallao
    {
        AtencionProtocolarAeropuertoCallaoDAO atencionProtocolarAeropuertoCallaoDAO = new();

        public List<AtencionProtocolarAeropuertoCallaoDTO> ObtenerLista(int? CargaId = null)
        {
            return atencionProtocolarAeropuertoCallaoDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(AtencionProtocolarAeropuertoCallaoDTO atencionProtocolarAeropuertoCallaoDTO)
        {
            return atencionProtocolarAeropuertoCallaoDAO.AgregarRegistro(atencionProtocolarAeropuertoCallaoDTO);
        }

        public AtencionProtocolarAeropuertoCallaoDTO BuscarFormato(int Codigo)
        {
            return atencionProtocolarAeropuertoCallaoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AtencionProtocolarAeropuertoCallaoDTO atencionProtocolarAeropuertoCallaoDTO)
        {
            return atencionProtocolarAeropuertoCallaoDAO.ActualizaFormato(atencionProtocolarAeropuertoCallaoDTO);
        }

        public bool EliminarFormato(AtencionProtocolarAeropuertoCallaoDTO atencionProtocolarAeropuertoCallaoDTO)
        {
            return atencionProtocolarAeropuertoCallaoDAO.EliminarFormato(atencionProtocolarAeropuertoCallaoDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return atencionProtocolarAeropuertoCallaoDAO.InsertarDatos(datos);
        }

    }
}
