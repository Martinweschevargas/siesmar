using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ValorReferencial
    {
        readonly ValorReferencialDAO valorReferencialDAO = new();

        public List<ValorReferencialDTO> ObtenerValorReferencials()
        {
            return valorReferencialDAO.ObtenerValorReferencials();
        }

        public string AgregarValorReferencial(ValorReferencialDTO valorReferencialDto)
        {
            return valorReferencialDAO.AgregarValorReferencial(valorReferencialDto);
        }

        public ValorReferencialDTO BuscarValorReferencialID(int Codigo)
        {
            return valorReferencialDAO.BuscarValorReferencialID(Codigo);
        }

        public string ActualizarValorReferencial(ValorReferencialDTO valorReferencialDTO)
        {
            return valorReferencialDAO.ActualizarValorReferencial(valorReferencialDTO);
        }

        public bool EliminarValorReferencial(ValorReferencialDTO valorReferencialDTO)
        {
            return valorReferencialDAO.EliminarValorReferencial(valorReferencialDTO);
        }

    }
}
