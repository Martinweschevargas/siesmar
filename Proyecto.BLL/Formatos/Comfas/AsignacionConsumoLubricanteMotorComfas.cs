using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class AsignacionConsumoLubricanteMotorComfas
    {
        AsignacionConsumoLubricanteMotorComfasDAO asignacionConsumoLubricanteMotorComfasDAO = new();

        public List<AsignacionConsumoLubricanteMotorComfasDTO> ObtenerLista()
        {
            return asignacionConsumoLubricanteMotorComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(AsignacionConsumoLubricanteMotorComfasDTO asignacionConsumoLubricanteMotorComfasDTO)
        {
            return asignacionConsumoLubricanteMotorComfasDAO.AgregarRegistro(asignacionConsumoLubricanteMotorComfasDTO);
        }

        public AsignacionConsumoLubricanteMotorComfasDTO BuscarFormato(int Codigo)
        {
            return asignacionConsumoLubricanteMotorComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AsignacionConsumoLubricanteMotorComfasDTO asignacionConsumoLubricanteMotorComfasDTO)
        {
            return asignacionConsumoLubricanteMotorComfasDAO.ActualizaFormato(asignacionConsumoLubricanteMotorComfasDTO);
        }

        public bool EliminarFormato(AsignacionConsumoLubricanteMotorComfasDTO asignacionConsumoLubricanteMotorComfasDTO)
        {
            return asignacionConsumoLubricanteMotorComfasDAO.EliminarFormato(asignacionConsumoLubricanteMotorComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<AsignacionConsumoLubricanteMotorComfasDTO> asignacionConsumoLubricanteMotorComfasDTO)
        {
            return asignacionConsumoLubricanteMotorComfasDAO.InsercionMasiva(asignacionConsumoLubricanteMotorComfasDTO);
        }

    }
}
