using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class ParteNumericoPersonalComfas
    {
        ParteNumericoPersonalComfasDAO parteNumericoPersonalComfasDAO = new();

        public List<ParteNumericoPersonalComfasDTO> ObtenerLista()
        {
            return parteNumericoPersonalComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(ParteNumericoPersonalComfasDTO parteNumericoPersonalComfasDTO)
        {
            return parteNumericoPersonalComfasDAO.AgregarRegistro(parteNumericoPersonalComfasDTO);
        }

        public ParteNumericoPersonalComfasDTO BuscarFormato(int Codigo)
        {
            return parteNumericoPersonalComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(ParteNumericoPersonalComfasDTO parteNumericoPersonalComfasDTO)
        {
            return parteNumericoPersonalComfasDAO.ActualizaFormato(parteNumericoPersonalComfasDTO);
        }

        public bool EliminarFormato(ParteNumericoPersonalComfasDTO parteNumericoPersonalComfasDTO)
        {
            return parteNumericoPersonalComfasDAO.EliminarFormato(parteNumericoPersonalComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<ParteNumericoPersonalComfasDTO> parteNumericoPersonalComfasDTO)
        {
            return parteNumericoPersonalComfasDAO.InsercionMasiva(parteNumericoPersonalComfasDTO);
        }

    }
}
