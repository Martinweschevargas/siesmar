using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class PerfilProfesionalDTO
    {
        public int PerfilProfesionalId { get; set; }
        public string? DescPerfilProfesional { get; set; }
        public string? CodigoPerfilProfesional { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
