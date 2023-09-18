using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class AsignacionConsumoCombustibleComfas
    {
        AsignacionConsumoCombustibleComfasDAO asignacionConsumoCombustibleComfasDAO = new();

        public List<AsignacionConsumoCombustibleComfasDTO> ObtenerLista()
        {
            return asignacionConsumoCombustibleComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(AsignacionConsumoCombustibleComfasDTO asignacionConsumoCombustibleComfasDTO)
        {
            return asignacionConsumoCombustibleComfasDAO.AgregarRegistro(asignacionConsumoCombustibleComfasDTO);
        }

        public AsignacionConsumoCombustibleComfasDTO BuscarFormato(int Codigo)
        {
            return asignacionConsumoCombustibleComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AsignacionConsumoCombustibleComfasDTO asignacionConsumoCombustibleComfasDTO)
        {
            return asignacionConsumoCombustibleComfasDAO.ActualizaFormato(asignacionConsumoCombustibleComfasDTO);
        }

        public bool EliminarFormato(AsignacionConsumoCombustibleComfasDTO asignacionConsumoCombustibleComfasDTO)
        {
            return asignacionConsumoCombustibleComfasDAO.EliminarFormato(asignacionConsumoCombustibleComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<AsignacionConsumoCombustibleComfasDTO> asignacionConsumoCombustibleComfasDTO)
        {
            return asignacionConsumoCombustibleComfasDAO.InsercionMasiva(asignacionConsumoCombustibleComfasDTO);
        }

    }
}
