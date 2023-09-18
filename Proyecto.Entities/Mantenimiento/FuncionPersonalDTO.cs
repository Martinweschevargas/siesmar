using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Mantenimiento
{
    public class FuncionPersonalDTO
    {
        public int FuncionPersonalId { get; set; }
        public string? DescFuncionPersonal { get; set; }
        public string? CodigoFuncionPersonal { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}
