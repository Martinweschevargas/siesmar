using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ModeloBienServicioSubcampo
    {
        readonly ModeloBienServicioSubcampoDAO modeloBienServicioSubcampoDAO = new();

        public List<ModeloBienServicioSubcampoDTO> ObtenerModeloBienServicioSubcampos()
        {
            return modeloBienServicioSubcampoDAO.ObtenerModeloBienServicioSubcampos();
        }

        public string AgregarModeloBienServicioSubcampo(ModeloBienServicioSubcampoDTO modeloBienServicioSubcampoDto)
        {
            return modeloBienServicioSubcampoDAO.AgregarModeloBienServicioSubcampo(modeloBienServicioSubcampoDto);
        }

        public ModeloBienServicioSubcampoDTO BuscarModeloBienServicioSubcampoID(int Codigo)
        {
            return modeloBienServicioSubcampoDAO.BuscarModeloBienServicioSubcampoID(Codigo);
        }

        public string ActualizarModeloBienServicioSubcampo(ModeloBienServicioSubcampoDTO modeloBienServicioSubcampoDTO)
        {
            return modeloBienServicioSubcampoDAO.ActualizarModeloBienServicioSubcampo(modeloBienServicioSubcampoDTO);
        }

        public string EliminarModeloBienServicioSubcampo(ModeloBienServicioSubcampoDTO modeloBienServicioSubcampoDTO)
        {
            return modeloBienServicioSubcampoDAO.EliminarModeloBienServicioSubcampo(modeloBienServicioSubcampoDTO);
        }

    }
}
