using Marina.Siesmar.AccesoDatos.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Mantenimiento;
using System.Data;

namespace Marina.Siesmar.LogicaNegocios.Formatos.Diali
{
    public class LicenciaArmasMenoresMilitar
    {
        LicenciaArmasMenoresMilitarDAO licenciaArmasMenoresMilitarDAO = new();

        public List<LicenciaArmasMenoresMilitarDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            return licenciaArmasMenoresMilitarDAO.ObtenerLista(CargaId, fechainicio, fechafin);
        }

        public string AgregarRegistro(LicenciaArmasMenoresMilitarDTO licenciaArmasMenoresMilitar, string? fecha)
        {
            return licenciaArmasMenoresMilitarDAO.AgregarRegistro(licenciaArmasMenoresMilitar, fecha);
        }

        public LicenciaArmasMenoresMilitarDTO EditarFormato(int Codigo)
        {
            return licenciaArmasMenoresMilitarDAO.BuscarFormato(Codigo);
        }

        public string ActualizarFormato(LicenciaArmasMenoresMilitarDTO licenciaArmasMenoresMilitarDTO)
        {
            return licenciaArmasMenoresMilitarDAO.ActualizaFormato(licenciaArmasMenoresMilitarDTO);
        }

        public bool EliminarFormato(LicenciaArmasMenoresMilitarDTO licenciaArmaMenorDTO)
        {
            return licenciaArmasMenoresMilitarDAO.EliminarFormato(licenciaArmaMenorDTO);
        }

        public bool EliminarCarga(LicenciaArmasMenoresMilitarDTO licenciaArmaMenorDTO)
        {
            return licenciaArmasMenoresMilitarDAO.EliminarCarga(licenciaArmaMenorDTO);
        }

        public string InsertarDatos(DataTable datos, string fecha)
        {
            return licenciaArmasMenoresMilitarDAO.InsertarDatos(datos, fecha);
        }

    }
}
