using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CalificativoAsignadoOperatividadMaterialDTO
    {
        public int CalificativoAsignadoOperatividadMaterialId { get; set; }
        public string? Descripcion { get; set; }
        public string? Calificativo { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
