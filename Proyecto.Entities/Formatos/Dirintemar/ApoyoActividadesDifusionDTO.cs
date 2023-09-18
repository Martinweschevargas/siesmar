using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirintemar
{
    public partial class ApoyoActividadesDifusionDTO
    {
        public int ApoyoActividadDifusionId { get; set; }
        public string? CodigoTipoActividadDifusion { get; set; }
        public string? NombreApoyoActividadDifusion { get; set; }
        public string? LugarApoyoActividadDifusion { get; set; }
        public string? DepartamentoUbigeo { get; set; }
        public int? DirigidoAId { get; set; }
        public string? InicioApoyoActividadDifusion { get; set; }
        public string? TerminoApoyoActividadDifusion { get; set; }
        public int? InversionApoyoActividadDifusion { get; set; }
        public string? DescTipoActividadDifusion { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescDirigidoA { get; set; }

        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
