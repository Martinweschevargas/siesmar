using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class DptoProteccionMedioAmbienteDTO
    {
        public int DptoProteccionMedioAmbienteId { get; set; }
        public string? DescDptoProteccionMedioAmbiente { get; set; }
        public string? CodigoDptoProteccionMedioAmbiente { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
