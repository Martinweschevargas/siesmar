using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ModeloEquipoSatelital
    {
        readonly ModeloEquipoSatelitalDAO modeloEquipoSatelitalDAO = new();

        public List<ModeloEquipoSatelitalDTO> ObtenerModeloEquipoSatelitals()
        {
            return modeloEquipoSatelitalDAO.ObtenerModeloEquipoSatelitals();
        }

        public string AgregarModeloEquipoSatelital(ModeloEquipoSatelitalDTO modeloEquipoSatelitalDto)
        {
            return modeloEquipoSatelitalDAO.AgregarModeloEquipoSatelital(modeloEquipoSatelitalDto);
        }

        public ModeloEquipoSatelitalDTO BuscarModeloEquipoSatelitalID(int Codigo)
        {
            return modeloEquipoSatelitalDAO.BuscarModeloEquipoSatelitalID(Codigo);
        }

        public string ActualizarModeloEquipoSatelital(ModeloEquipoSatelitalDTO modeloEquipoSatelitalDTO)
        {
            return modeloEquipoSatelitalDAO.ActualizarModeloEquipoSatelital(modeloEquipoSatelitalDTO);
        }

        public bool EliminarModeloEquipoSatelital(int Codigo)
        {
            return modeloEquipoSatelitalDAO.EliminarModeloEquipoSatelital(Codigo);
        }

    }
}
