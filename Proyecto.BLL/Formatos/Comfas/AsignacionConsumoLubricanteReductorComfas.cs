using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class AsignacionConsumoLubricanteReductorComfas
    {
        AsignacionConsumoLubricanteReductorComfasDAO asignacionConsumoLubricanteReductorComfasDAO = new();

        public List<AsignacionConsumoLubricanteReductorComfasDTO> ObtenerLista()
        {
            return asignacionConsumoLubricanteReductorComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(AsignacionConsumoLubricanteReductorComfasDTO asignacionConsumoLubricanteReductorComfasDTO)
        {
            return asignacionConsumoLubricanteReductorComfasDAO.AgregarRegistro(asignacionConsumoLubricanteReductorComfasDTO);
        }

        public AsignacionConsumoLubricanteReductorComfasDTO BuscarFormato(int Codigo)
        {
            return asignacionConsumoLubricanteReductorComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AsignacionConsumoLubricanteReductorComfasDTO asignacionConsumoLubricanteReductorComfasDTO)
        {
            return asignacionConsumoLubricanteReductorComfasDAO.ActualizaFormato(asignacionConsumoLubricanteReductorComfasDTO);
        }

        public bool EliminarFormato(AsignacionConsumoLubricanteReductorComfasDTO asignacionConsumoLubricanteReductorComfasDTO)
        {
            return asignacionConsumoLubricanteReductorComfasDAO.EliminarFormato(asignacionConsumoLubricanteReductorComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<AsignacionConsumoLubricanteReductorComfasDTO> asignacionConsumoLubricanteReductorComfasDTO)
        {
            return asignacionConsumoLubricanteReductorComfasDAO.InsercionMasiva(asignacionConsumoLubricanteReductorComfasDTO);
        }

    }
}
