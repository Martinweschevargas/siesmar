using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class DistritoUbigeo
    {
        readonly DistritoUbigeoDAO distritoUbigeoDAO = new();

        public List<DistritoUbigeoDTO> ObtenerDistritoUbigeos()
        {
            return distritoUbigeoDAO.ObtenerDistritoUbigeos();
        }

        public string AgregarDistritoUbigeo(DistritoUbigeoDTO distritoUbigeoDto)
        {
            return distritoUbigeoDAO.AgregarDistritoUbigeo(distritoUbigeoDto);
        }

        public DistritoUbigeoDTO BuscarDistritoUbigeoID(int Codigo)
        {
            return distritoUbigeoDAO.BuscarDistritoUbigeoID(Codigo);
        }

        public string ActualizarDistritoUbigeo(DistritoUbigeoDTO distritoUbigeoDTO)
        {
            return distritoUbigeoDAO.ActualizarDistritoUbigeo(distritoUbigeoDTO);
        }

        public bool EliminarDistritoUbigeo(DistritoUbigeoDTO distritoUbigeoDTO)
        {
            return distritoUbigeoDAO.EliminarDistritoUbigeo(distritoUbigeoDTO);
        }

    }
}