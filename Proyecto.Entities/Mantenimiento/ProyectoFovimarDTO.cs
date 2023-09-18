using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ProyectoFovimarDTO
    {
        public int ProyectoFovimarId { get; set; }
        public string? DescProyectoFovimar { get; set; }
        public string? CodigoProyectoFovimar { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
