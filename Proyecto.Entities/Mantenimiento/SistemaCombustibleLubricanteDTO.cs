using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class SistemaCombustibleLubricanteDTO
    {
        public int SistemaCombustibleLubricanteId { get; set; }
        public string? DescSistemaCombustibleLubricante { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
