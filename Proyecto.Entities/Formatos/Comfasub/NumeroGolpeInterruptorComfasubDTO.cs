using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfasub
{
    public partial class NumeroGolpeInterruptorComfasubDTO
    {

        public int NumeroGolpeInterruptorComfasubId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoEquipoSistemaPropulsion { get; set; }
        public int? GolpeFijadoRecorridoTotal { get; set; }
        public int? GolpeFijadoRecorridoParcial { get; set; }
        public int? GolpeUltimoRecorrido { get; set; }
        public int? GolpeTotalInstalacion { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescEquipoSistemaPropulsion { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}