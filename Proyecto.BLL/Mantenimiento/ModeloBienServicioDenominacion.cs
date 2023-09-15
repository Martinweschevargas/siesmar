using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ModeloBienServicioDenominacion
    {
        readonly ModeloBienServicioDenominacionDAO modeloBienServicioDenominacionDAO = new();

        public List<ModeloBienServicioDenominacionDTO> ObtenerModeloBienServicioDenominacions()
        {
            return modeloBienServicioDenominacionDAO.ObtenerModeloBienServicioDenominacions();
        }

        public string AgregarModeloBienServicioDenominacion(ModeloBienServicioDenominacionDTO modeloBienServicioDenominacionDto)
        {
            return modeloBienServicioDenominacionDAO.AgregarModeloBienServicioDenominacion(modeloBienServicioDenominacionDto);
        }

        public ModeloBienServicioDenominacionDTO BuscarModeloBienServicioDenominacionID(int Codigo)
        {
            return modeloBienServicioDenominacionDAO.BuscarModeloBienServicioDenominacionID(Codigo);
        }

        public string ActualizarModeloBienServicioDenominacion(ModeloBienServicioDenominacionDTO modeloBienServicioDenominacionDTO)
        {
            return modeloBienServicioDenominacionDAO.ActualizarModeloBienServicioDenominacion(modeloBienServicioDenominacionDTO);
        }

        public string EliminarModeloBienServicioDenominacion(ModeloBienServicioDenominacionDTO modeloBienServicioDenominacionDTO)
        {
            return modeloBienServicioDenominacionDAO.EliminarModeloBienServicioDenominacion(modeloBienServicioDenominacionDTO);
        }

    }
}
