using Marina.Siesmar.AccesoDatos.Formatos.Comoperguard;
using Marina.Siesmar.Entidades.Formatos.Comoperguard;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Comoperguard
{
    public class AvisoInfraccionImpuesto
    {
        AvisoInfraccionImpuestoDAO avisoInfraccionImpuestoDAO = new();

        public List<AvisoInfraccionImpuestoDTO> ObtenerLista()
        {
            return avisoInfraccionImpuestoDAO.ObtenerLista();
        }

        public string AgregarRegistro(AvisoInfraccionImpuestoDTO avisoInfraccionImpuestoDTO)
        {
            return avisoInfraccionImpuestoDAO.AgregarRegistro(avisoInfraccionImpuestoDTO);
        }

        public AvisoInfraccionImpuestoDTO BuscarFormato(int Codigo)
        {
            return avisoInfraccionImpuestoDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(AvisoInfraccionImpuestoDTO avisoInfraccionImpuestoDTO)
        {
            return avisoInfraccionImpuestoDAO.ActualizaFormato(avisoInfraccionImpuestoDTO);
        }

        public bool EliminarFormato(AvisoInfraccionImpuestoDTO avisoInfraccionImpuestoDTO)
        {
            return avisoInfraccionImpuestoDAO.EliminarFormato(avisoInfraccionImpuestoDTO);
        }

        public bool InsercionMasiva(IEnumerable<AvisoInfraccionImpuestoDTO> avisoInfraccionImpuestoDTO)
        {
            return avisoInfraccionImpuestoDAO.InsercionMasiva(avisoInfraccionImpuestoDTO);
        }

    }
}
