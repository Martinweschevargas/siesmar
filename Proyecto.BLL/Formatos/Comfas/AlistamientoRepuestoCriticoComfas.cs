using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class AlistamientoRepuestoCriticoComfas
    {
        AlistamientoRepuestoCriticoComfasDAO alistamientoRepuestoCriticoComfasDAO = new();

        public List<AlistamientoRepuestoCriticoComfasDTO> ObtenerLista()
        {
            return alistamientoRepuestoCriticoComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(AlistamientoRepuestoCriticoComfasDTO alistamientoRepuestoCriticoComfasDTO)
        {
            return alistamientoRepuestoCriticoComfasDAO.AgregarRegistro(alistamientoRepuestoCriticoComfasDTO);
        }

        public AlistamientoRepuestoCriticoComfasDTO BuscarFormato(int Codigo)
        {
            return alistamientoRepuestoCriticoComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AlistamientoRepuestoCriticoComfasDTO alistamientoRepuestoCriticoComfasDTO)
        {
            return alistamientoRepuestoCriticoComfasDAO.ActualizaFormato(alistamientoRepuestoCriticoComfasDTO);
        }

        public bool EliminarFormato(AlistamientoRepuestoCriticoComfasDTO alistamientoRepuestoCriticoComfasDTO)
        {
            return alistamientoRepuestoCriticoComfasDAO.EliminarFormato(alistamientoRepuestoCriticoComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<AlistamientoRepuestoCriticoComfasDTO> alistamientoRepuestoCriticoComfasDTO)
        {
            return alistamientoRepuestoCriticoComfasDAO.InsercionMasiva(alistamientoRepuestoCriticoComfasDTO);
        }

    }
}
