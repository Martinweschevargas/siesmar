using Marina.Siesmar.AccesoDatos.Mantenimiento;
using Marina.Siesmar.Entidades.Mantenimiento;

namespace Marina.Siesmar.LogicaNegocios.Mantenimiento
{
    public class GrupoPuertoPeru
    {
        readonly GrupoPuertoPeruDAO GrupoPuertoPeruDAO = new();

        public List<GrupoPuertoPeruDTO> ObtenerCapintanias()
        {
            return GrupoPuertoPeruDAO.ObtenerGrupoPuertoPerus();
        }

        public string AgregarGrupoPuertoPeru(GrupoPuertoPeruDTO grupoPuertoPeruDTO)
        {
            return GrupoPuertoPeruDAO.AgregarGrupoPuertoPeru(grupoPuertoPeruDTO);
        }

        public GrupoPuertoPeruDTO BuscarGrupoPuertoPeruID(int Codigo)
        {
            return GrupoPuertoPeruDAO.BuscarGrupoPuertoPeruID(Codigo);
        }

        public string ActualizarGrupoPuertoPeru(GrupoPuertoPeruDTO grupoPuertoPeruDTO)
        {
            return GrupoPuertoPeruDAO.ActualizarGrupoPuertoPeru(grupoPuertoPeruDTO);
        }

        public string EliminarGrupoPuertoPeru(GrupoPuertoPeruDTO grupoPuertoPeruDTO)
        {
            return GrupoPuertoPeruDAO.EliminarGrupoPuertoPeru(grupoPuertoPeruDTO);
        }

    }
}
