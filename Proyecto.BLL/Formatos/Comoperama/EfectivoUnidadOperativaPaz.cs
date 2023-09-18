using Marina.Siesmar.AccesoDatos.Formatos.Comoperama;
using Marina.Siesmar.Entidades.Formatos.Comoperama;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperama
{
    public class EfectivoUnidadOperativaPaz
    {
        EfectivoUnidadOperativaPazDAO efectivoUnidadOperativaPazDAO = new();

        public List<EfectivoUnidadOperativaPazDTO> ObtenerLista(int? CargaId = null)
        {
            return efectivoUnidadOperativaPazDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(EfectivoUnidadOperativaPazDTO efectivoUnidadOperativaPazDTO)
        {
            return efectivoUnidadOperativaPazDAO.AgregarRegistro(efectivoUnidadOperativaPazDTO);
        }

        public EfectivoUnidadOperativaPazDTO BuscarFormato(int Codigo)
        {
            return efectivoUnidadOperativaPazDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(EfectivoUnidadOperativaPazDTO efectivoUnidadOperativaPazDTO)
        {
            return efectivoUnidadOperativaPazDAO.ActualizaFormato(efectivoUnidadOperativaPazDTO);
        }

        public bool EliminarFormato(EfectivoUnidadOperativaPazDTO efectivoUnidadOperativaPazDTO)
        {
            return efectivoUnidadOperativaPazDAO.EliminarFormato(efectivoUnidadOperativaPazDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return efectivoUnidadOperativaPazDAO.InsertarDatos(datos);
        }

    }
}
