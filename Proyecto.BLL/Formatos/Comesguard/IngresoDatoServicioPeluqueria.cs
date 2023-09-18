
using Marina.Siesmar.AccesoDatos.Formatos.Comesguard;
using Marina.Siesmar.Entidades.Formatos.Comesguard;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comesguard
{
    public class IngresoDatoServicioPeluqueria
    {
        IngresoDatoServicioPeluqueriaDAO ingresoDatoServicioPeluqueriaDAO = new();

        public List<IngresoDatoServicioPeluqueriaDTO> ObtenerLista(int? CargaId = null)
        {
            return ingresoDatoServicioPeluqueriaDAO.ObtenerLista(CargaId);
        }

        public string AgregarRegistro(IngresoDatoServicioPeluqueriaDTO ingresoDatoServicioPeluqueriaDTO)
        {
            return ingresoDatoServicioPeluqueriaDAO.AgregarRegistro(ingresoDatoServicioPeluqueriaDTO);
        }

        public IngresoDatoServicioPeluqueriaDTO BuscarFormato(int Codigo)
        {
            return ingresoDatoServicioPeluqueriaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(IngresoDatoServicioPeluqueriaDTO ingresoDatoServicioPeluqueriaDTO)
        {
            return ingresoDatoServicioPeluqueriaDAO.ActualizaFormato(ingresoDatoServicioPeluqueriaDTO);
        }

        public bool EliminarFormato(IngresoDatoServicioPeluqueriaDTO ingresoDatoServicioPeluqueriaDTO)
        {
            return ingresoDatoServicioPeluqueriaDAO.EliminarFormato(ingresoDatoServicioPeluqueriaDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return ingresoDatoServicioPeluqueriaDAO.InsertarDatos(datos);
        }

    }
}
