using Marina.Siesmar.AccesoDatos.Formatos.Ipecamar;
using Marina.Siesmar.Entidades.Formatos.Ipecamar;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Ipecamar
{
    public class DenunciaAnticorrupcion
    {
        DenunciaAnticorrupcionDAO denunciaAnticorrupcionDAO = new();

        public List<DenunciaAnticorrupcionDTO> ObtenerLista(int? CargaId = null)
        {
            return denunciaAnticorrupcionDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(DenunciaAnticorrupcionDTO denunciaAnticorrupcionDTO)
        {
            return denunciaAnticorrupcionDAO.AgregarRegistro(denunciaAnticorrupcionDTO);
        }

        public DenunciaAnticorrupcionDTO BuscarFormato(int Codigo)
        {
            return denunciaAnticorrupcionDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(DenunciaAnticorrupcionDTO denunciaAnticorrupcionDTO)
        {
            return denunciaAnticorrupcionDAO.ActualizaFormato(denunciaAnticorrupcionDTO);
        }

        public bool EliminarFormato(DenunciaAnticorrupcionDTO denunciaAnticorrupcionDTO)
        {
            return denunciaAnticorrupcionDAO.EliminarFormato(denunciaAnticorrupcionDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return denunciaAnticorrupcionDAO.InsertarDatos(datos);
        }

    }
}
