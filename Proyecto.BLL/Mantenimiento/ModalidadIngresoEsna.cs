using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ModalidadIngresoEsna
    {
        readonly ModalidadIngresoEsnaDAO modalidadIngresoEsnaDAO = new();

        public List<ModalidadIngresoEsnaDTO> ObtenerModalidadIngresoEsnas()
        {
            return modalidadIngresoEsnaDAO.ObtenerModalidadIngresoEsnas();
        }

        public string AgregarModalidadIngresoEsna(ModalidadIngresoEsnaDTO modalidadIngresoEsnaDto)
        {
            return modalidadIngresoEsnaDAO.AgregarModalidadIngresoEsna(modalidadIngresoEsnaDto);
        }

        public ModalidadIngresoEsnaDTO BuscarModalidadIngresoEsnaID(int Codigo)
        {
            return modalidadIngresoEsnaDAO.BuscarModalidadIngresoEsnaID(Codigo);
        }

        public string ActualizarModalidadIngresoEsna(ModalidadIngresoEsnaDTO modalidadIngresoEsnaDTO)
        {
            return modalidadIngresoEsnaDAO.ActualizarModalidadIngresoEsna(modalidadIngresoEsnaDTO);
        }

        public string EliminarModalidadIngresoEsna(ModalidadIngresoEsnaDTO modalidadIngresoEsnaDTO)
        {
            return modalidadIngresoEsnaDAO.EliminarModalidadIngresoEsna(modalidadIngresoEsnaDTO);
        }

    }
}
