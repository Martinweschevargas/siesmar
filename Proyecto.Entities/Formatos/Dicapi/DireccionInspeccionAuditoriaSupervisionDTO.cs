using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dicapi
{
    public partial class DireccionInspeccionAuditoriaSupervisionDTO
    {

        public int? DireccionInspeccionAuditoriaSupervisionId { get; set; }
        public string? NumeroNombramiento { get; set; }
        public string? FechaInspeccion { get; set; }
        public string? CodigoCapitania { get; set; }
        public string? Nombre1Inspector { get; set; }
        public string? Nombre2Inspector { get; set; }
        public string? DescCapitania { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}