using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class ClasificacionSancionDisciplinariaDTO
    {
        public int ClasificacionSancionDisciplinariaId { get; set; }
        public string? DescClasificacionSancionDisciplinaria { get; set; }
        public string? CodigoClasificacionSancionDisciplinaria { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
