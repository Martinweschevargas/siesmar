using Marina.Siesmar.AccesoDatos.Formatos.Combasnai;
using Marina.Siesmar.Entidades.Formatos.Combasnai;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combasnai
{
    public class AlistamientoMaterialCombasnai
    {
        AlistamientoMaterialCombasnaiDAO alistamientoMaterialCombasnaiDAO = new();

        public List<AlistamientoMaterialCombasnaiDTO> ObtenerLista()
        {
            return alistamientoMaterialCombasnaiDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoMaterialCombasnaiDTO alistamientoMaterialCombasnaiDTO)
        {
            return alistamientoMaterialCombasnaiDAO.AgregarRegistro(alistamientoMaterialCombasnaiDTO);
        }

        public AlistamientoMaterialCombasnaiDTO BuscarFormato(int Codigo)
        {
            return alistamientoMaterialCombasnaiDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoMaterialCombasnaiDTO alistamientoMaterialCombasnaiDTO)
        {
            return alistamientoMaterialCombasnaiDAO.ActualizaFormato(alistamientoMaterialCombasnaiDTO);
        }

        public bool EliminarFormato(AlistamientoMaterialCombasnaiDTO alistamientoMaterialCombasnaiDTO)
        {
            return alistamientoMaterialCombasnaiDAO.EliminarFormato(alistamientoMaterialCombasnaiDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return alistamientoMaterialCombasnaiDAO.InsertarDatos(datos);
        }

    }
}
