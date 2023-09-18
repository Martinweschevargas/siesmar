using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dihidronav
{
    public partial class ServicioConstruccionInstalacionDTO
    {

        public int? ServicioConstruccionInstalacionId { get; set; }
        public int? NumeroOrden { get; set; }
        public string? CodigoTrabajoSenializacionNautica { get; set; }
        public string? DescripcionServicio { get; set; }
        public string? FechaInicio { get; set; }
        public string? FechaTermino { get; set; }
        public string? CodigoZonaNautica { get; set; }
        public string? EstadoServicio { get; set; }
        public string? DescTrabajoSenializacionNautica { get; set; }
        public string? DescZonaNautica { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}