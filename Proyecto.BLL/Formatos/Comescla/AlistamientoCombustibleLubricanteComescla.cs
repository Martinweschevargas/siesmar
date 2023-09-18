using Marina.Siesmar.AccesoDatos.Formatos.Comescla;
using Marina.Siesmar.Entidades.Formatos.Comescla;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comescla
{
    public class AlistamientoCombustibleLubricanteComescla
    {
        AlistamientoCombustibleLubricanteComesclaDAO alistamientoCombustibleLubricanteComesclaDAO = new();

        public List<AlistamientoCombustibleLubricanteComesclaDTO> ObtenerLista()
        {
            return alistamientoCombustibleLubricanteComesclaDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComesclaDTO alistamientoCombustibleLubricanteComesclaDTO)
        {
            return alistamientoCombustibleLubricanteComesclaDAO.AgregarRegistro(alistamientoCombustibleLubricanteComesclaDTO);
        }

        public AlistamientoCombustibleLubricanteComesclaDTO BuscarFormato(int Codigo)
        {
            return alistamientoCombustibleLubricanteComesclaDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoCombustibleLubricanteComesclaDTO alistamientoCombustibleLubricanteComesclaDTO)
        {
            return alistamientoCombustibleLubricanteComesclaDAO.ActualizaFormato(alistamientoCombustibleLubricanteComesclaDTO);
        }

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComesclaDTO alistamientoCombustibleLubricanteComesclaDTO)
        {
            return alistamientoCombustibleLubricanteComesclaDAO.EliminarFormato(alistamientoCombustibleLubricanteComesclaDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoCombustibleLubricanteComesclaDTO> alistamientoCombustibleLubricanteComesclaDTO)
        {
            return alistamientoCombustibleLubricanteComesclaDAO.InsercionMasiva(alistamientoCombustibleLubricanteComesclaDTO);
        }

    }
}
