using System.ComponentModel.DataAnnotations.Schema;


namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class EquipoSistemaPropulsionDTO
    {
        public int EquipoSistemaPropulsionId { get; set; }
        public string? CodigoEquipoSistemaPropulsion { get; set; }
        public string? DescEquipoSistemaPropulsion { get; set; }
        public string? CodigoSubSistemaPropulsion { get; set; }
        public string? DescSubSistemaPropulsion { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
