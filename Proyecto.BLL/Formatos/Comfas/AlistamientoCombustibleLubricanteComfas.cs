using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class AlistamientoCombustibleLubricanteComfas
    {
        AlistamientoCombustibleLubricanteComfasDAO alistamientoCombustibleLubricanteComfasDAO = new();

        public List<AlistamientoCombustibleLubricanteComfasDTO> ObtenerLista()
        {
            return alistamientoCombustibleLubricanteComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoCombustibleLubricanteComfasDTO alistamientoCombustibleLubricanteComfasDTO)
        {
            return alistamientoCombustibleLubricanteComfasDAO.AgregarRegistro(alistamientoCombustibleLubricanteComfasDTO);
        }

        public AlistamientoCombustibleLubricanteComfasDTO BuscarFormato(int Codigo)
        {
            return alistamientoCombustibleLubricanteComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoCombustibleLubricanteComfasDTO alistamientoCombustibleLubricanteComfasDTO)
        {
            return alistamientoCombustibleLubricanteComfasDAO.ActualizaFormato(alistamientoCombustibleLubricanteComfasDTO);
        }

        public bool EliminarFormato(AlistamientoCombustibleLubricanteComfasDTO alistamientoCombustibleLubricanteComfasDTO)
        {
            return alistamientoCombustibleLubricanteComfasDAO.EliminarFormato(alistamientoCombustibleLubricanteComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoCombustibleLubricanteComfasDTO> alistamientoCombustibleLubricanteComfasDTO)
        {
            return alistamientoCombustibleLubricanteComfasDAO.InsercionMasiva(alistamientoCombustibleLubricanteComfasDTO);
        }

    }
}
