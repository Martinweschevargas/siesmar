using Marina.Siesmar.AccesoDatos.Formatos.Comciberdef;
using Marina.Siesmar.AccesoDatos.Formatos.Diabaste;
using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diabaste;
using Marina.Siesmar.Entidades.Formatos.Diali;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diabaste
{
    public class DistribucionVestuario
    {
        DistribucionVestuarioDAO distribucionVestuarioDAO = new();

        public List<DistribucionVestuarioDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return distribucionVestuarioDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(DistribucionVestuarioDTO distribucionVestuario, string? fecha)
        {
            return distribucionVestuarioDAO.AgregarRegistro(distribucionVestuario, fecha);
        }

        public DistribucionVestuarioDTO EditarFormato(int Codigo)
        {
            return distribucionVestuarioDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(DistribucionVestuarioDTO distribucionVestuarioDTO)
        {
            return distribucionVestuarioDAO.ActualizaFormato(distribucionVestuarioDTO);
        }

        public bool EliminarFormato(DistribucionVestuarioDTO distribucionVestuarioDTO)
        {
            return distribucionVestuarioDAO.EliminarFormato( distribucionVestuarioDTO);
        }

        public bool EliminarCarga(DistribucionVestuarioDTO distribucionVestuarioDTO)
        {
            return distribucionVestuarioDAO.EliminarCarga(distribucionVestuarioDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return distribucionVestuarioDAO.InsertarDatos(datos, fecha);
        }

    }
}
