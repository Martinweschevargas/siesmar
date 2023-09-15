using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfuinmar
{
    public partial class AlistamientoCombustibleLubricanteComfuinmarDTO
    {

        public int? AlistamientoCombustibleLubricanteComfuinmarId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoAlistamientoCombustibleLubricante { get; set; }
        public int? CargaId { get; set; }
        public string? DescUnidadNaval { get; set; }
        public string? CombustibleLubricante { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
