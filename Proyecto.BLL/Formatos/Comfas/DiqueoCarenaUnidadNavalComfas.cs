using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class DiqueoCarenaUnidadNavalComfas
    {
        DiqueoCarenaUnidadNavalComfasDAO diqueoCarenaUnidadNavalComfasDAO = new();

        public List<DiqueoCarenaUnidadNavalComfasDTO> ObtenerLista()
        {
            return diqueoCarenaUnidadNavalComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(DiqueoCarenaUnidadNavalComfasDTO diqueoCarenaUnidadNavalComfasDTO)
        {
            return diqueoCarenaUnidadNavalComfasDAO.AgregarRegistro(diqueoCarenaUnidadNavalComfasDTO);
        }

        public DiqueoCarenaUnidadNavalComfasDTO BuscarFormato(int Codigo)
        {
            return diqueoCarenaUnidadNavalComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(DiqueoCarenaUnidadNavalComfasDTO diqueoCarenaUnidadNavalComfasDTO)
        {
            return diqueoCarenaUnidadNavalComfasDAO.ActualizaFormato(diqueoCarenaUnidadNavalComfasDTO);
        }

        public bool EliminarFormato(DiqueoCarenaUnidadNavalComfasDTO diqueoCarenaUnidadNavalComfasDTO)
        {
            return diqueoCarenaUnidadNavalComfasDAO.EliminarFormato(diqueoCarenaUnidadNavalComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<DiqueoCarenaUnidadNavalComfasDTO> diqueoCarenaUnidadNavalComfasDTO)
        {
            return diqueoCarenaUnidadNavalComfasDAO.InsercionMasiva(diqueoCarenaUnidadNavalComfasDTO);
        }

    }
}
