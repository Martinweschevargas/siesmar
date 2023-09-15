using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class ComandanciaNaval
    {
        readonly ComandanciaNavalDAO comandanciaNavalDAO = new();

        public List<ComandanciaNavalDTO> ObtenerComandanciaNavals()
        {
            return comandanciaNavalDAO.ObtenerComandanciaNavals();
        }

        public string AgregarComandanciaNaval(ComandanciaNavalDTO comandanciaNavalDto)
        {
            return comandanciaNavalDAO.AgregarComandanciaNaval(comandanciaNavalDto);
        }

        public ComandanciaNavalDTO BuscarComandanciaNavalID(int Codigo)
        {
            return comandanciaNavalDAO.BuscarComandanciaNavalID(Codigo);
        }

        public string ActualizarComandanciaNaval(ComandanciaNavalDTO comandanciaNavalDto)
        {
            return comandanciaNavalDAO.ActualizarComandanciaNaval(comandanciaNavalDto);
        }

        public string EliminarComandanciaNaval(ComandanciaNavalDTO comandanciaNavalDto)
        {
            return comandanciaNavalDAO.EliminarComandanciaNaval(comandanciaNavalDto);
        }

    }
}
