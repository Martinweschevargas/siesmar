using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class CondicionLaboralDocenteDTO
    {
        public int CondicionLaboralDocenteId { get; set; }
        public string? DescCondicionLaboralDocente { get; set; }
        public string? CodigoCondicionLaboralDocente { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
