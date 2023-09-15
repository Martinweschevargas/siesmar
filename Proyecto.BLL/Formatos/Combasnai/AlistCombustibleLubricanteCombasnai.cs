using Marina.Siesmar.AccesoDatos.Formatos.Combasnai;
using Marina.Siesmar.Entidades.Formatos.Combasnai;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Combasnai
{
    public class AlistCombustibleLubricanteCombasnai
    {
        AlistCombustibleLubricanteCombasnaiDAO alistCombustibleLubricanteCombasnaiDAO = new();

        public List<AlistCombustibleLubricanteCombasnaiDTO> ObtenerLista()
        {
            return alistCombustibleLubricanteCombasnaiDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistCombustibleLubricanteCombasnaiDTO alistCombustibleLubricanteCombasnaiDTO)
        {
            return alistCombustibleLubricanteCombasnaiDAO.AgregarRegistro(alistCombustibleLubricanteCombasnaiDTO);
        }

        public AlistCombustibleLubricanteCombasnaiDTO BuscarFormato(int Codigo)
        {
            return alistCombustibleLubricanteCombasnaiDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistCombustibleLubricanteCombasnaiDTO alistCombustibleLubricanteCombasnaiDTO)
        {
            return alistCombustibleLubricanteCombasnaiDAO.ActualizaFormato(alistCombustibleLubricanteCombasnaiDTO);
        }

        public bool EliminarFormato(AlistCombustibleLubricanteCombasnaiDTO alistCombustibleLubricanteCombasnaiDTO)
        {
            return alistCombustibleLubricanteCombasnaiDAO.EliminarFormato(alistCombustibleLubricanteCombasnaiDTO);
        }

        public string InsertarDatos(DataTable datos)
        {
            return alistCombustibleLubricanteCombasnaiDAO.InsertarDatos(datos);
        }

    }
}
