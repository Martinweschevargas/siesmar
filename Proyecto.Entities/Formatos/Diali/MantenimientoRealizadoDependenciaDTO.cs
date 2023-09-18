using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Diali
{
    public partial class MantenimientoRealizadoDependenciaDTO
    {
        public int MantenimientoDependUnidId { get; set; }
        public string? TipoUnidadMantenimiento { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? NumeroMes { get; set; }
        public int? TareaProgramada { get; set; }
        public int? TareaEjecutada { get; set; }
        public int? TareaNoEjecutada { get; set; }
        public int? TNEFaltapersonal { get; set; }
        public int? TNEFaltaTiempo { get; set; }
        public int? TNEFaltaRepuesto { get; set; }
        public int? TNEFaltaMaterial { get; set; }
        public int? TNEFaltaPresupuesto { get; set; }
        public int? TNEFaltaHerramienta { get; set; }
        public int? TNEFaltaInstrumento { get; set; }
        public int? TNEFaltaConocimiento { get; set; }
        public string? DescMes { get; set; }
        public string? DescUnidadNaval { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
