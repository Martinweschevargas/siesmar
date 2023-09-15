using Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comzocuatro
{
    public class AlistamientoMaterialComzocuatro
    {
        AlistamientoMaterialComzocuatroDAO alistamientoMaterialComzocuatroDAO = new();

        public List<AlistamientoMaterialComzocuatroDTO> ObtenerLista()
        {
            return alistamientoMaterialComzocuatroDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoMaterialComzocuatroDTO alistamientoMaterialComzocuatroDTO)
        {
            return alistamientoMaterialComzocuatroDAO.AgregarRegistro(alistamientoMaterialComzocuatroDTO);
        }

        public AlistamientoMaterialComzocuatroDTO BuscarFormato(int Codigo)
        {
            return alistamientoMaterialComzocuatroDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialComzocuatroDTO alistamientoMaterialComzocuatroDTO)
        {
            return alistamientoMaterialComzocuatroDAO.ActualizaFormato(alistamientoMaterialComzocuatroDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialComzocuatroDTO alistamientoMaterialComzocuatroDTO)
        {
            return alistamientoMaterialComzocuatroDAO.EliminarFormato(alistamientoMaterialComzocuatroDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return alistamientoMaterialComzocuatroDAO.InsertarDatos(datos);
        }

    }
}
