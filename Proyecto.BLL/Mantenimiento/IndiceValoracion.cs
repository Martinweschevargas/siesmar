using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class IndiceValoracion
    {
        readonly IndiceValoracionDAO indiceValoracionDAO = new();

        public List<IndiceValoracionDTO> ObtenerIndiceValoracions()
        {
            return indiceValoracionDAO.ObtenerIndiceValoracions();
        }

        public string AgregarIndiceValoracion(IndiceValoracionDTO indiceValoracionDto)
        {
            return indiceValoracionDAO.AgregarIndiceValoracion(indiceValoracionDto);
        }

        public IndiceValoracionDTO BuscarIndiceValoracionID(int Codigo)
        {
            return indiceValoracionDAO.BuscarIndiceValoracionID(Codigo);
        }

        public string ActualizarIndiceValoracion(IndiceValoracionDTO indiceValoracionDto)
        {
            return indiceValoracionDAO.ActualizarIndiceValoracion(indiceValoracionDto);
        }

        public string EliminarIndiceValoracion(IndiceValoracionDTO indiceValoracionDto)
        {
            return indiceValoracionDAO.EliminarIndiceValoracion(indiceValoracionDto);
        }

    }
}
