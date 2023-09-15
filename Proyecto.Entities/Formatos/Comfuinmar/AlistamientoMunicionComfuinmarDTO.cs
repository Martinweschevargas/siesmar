using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfuinmar
{
    public partial class AlistamientoMunicionComfuinmarDTO
    {

        public int? AlistamientoMunicionConfuinmarId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoMunicion { get; set; }
        public int? NroMunicionesExistentes { get; set; }
        public int? CargaId { get; set; }
        public string? DescUnidadNaval { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
