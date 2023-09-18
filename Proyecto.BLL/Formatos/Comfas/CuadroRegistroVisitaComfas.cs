using Marina.Siesmar.AccesoDatos.Formatos.Comfas;
using Marina.Siesmar.Entidades.Formatos.Comfas;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comfas
{
    public class CuadroRegistroVisitaComfas
    {
        CuadroRegistroVisitaComfasDAO cuadroRegistroVisitaComfasDAO = new();

        public List<CuadroRegistroVisitaComfasDTO> ObtenerLista()
        {
            return cuadroRegistroVisitaComfasDAO.ObtenerLista();
        }

        public string AgregarRegistro(CuadroRegistroVisitaComfasDTO cuadroRegistroVisitaComfasDTO)
        {
            return cuadroRegistroVisitaComfasDAO.AgregarRegistro(cuadroRegistroVisitaComfasDTO);
        }

        public CuadroRegistroVisitaComfasDTO BuscarFormato(int Codigo)
        {
            return cuadroRegistroVisitaComfasDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(CuadroRegistroVisitaComfasDTO cuadroRegistroVisitaComfasDTO)
        {
            return cuadroRegistroVisitaComfasDAO.ActualizaFormato(cuadroRegistroVisitaComfasDTO);
        }

        public bool EliminarFormato(CuadroRegistroVisitaComfasDTO cuadroRegistroVisitaComfasDTO)
        {
            return cuadroRegistroVisitaComfasDAO.EliminarFormato(cuadroRegistroVisitaComfasDTO);
        }

        public bool InsercionMasiva(IEnumerable<CuadroRegistroVisitaComfasDTO> cuadroRegistroVisitaComfasDTO)
        {
            return cuadroRegistroVisitaComfasDAO.InsercionMasiva(cuadroRegistroVisitaComfasDTO);
        }

    }
}
