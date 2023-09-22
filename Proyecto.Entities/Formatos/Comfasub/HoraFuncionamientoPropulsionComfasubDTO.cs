using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comfasub
{
    public partial class HoraFuncionamientoPropulsionComfasubDTO
    {

        public int HoraFuncionamientoPropulsionComfasubId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? CodigoEquipoSistemaPropulsion { get; set; }
        public int? HoraFijadaRecorridoTotal { get; set; }
        public int? HoraFijadaRecorridoParcial { get; set; }
        public string? FechaUltimoRecorrdio { get; set; }
        public int? HoraUltimoRecorrido { get; set; }
        public int? HoraTotalInstalacion { get; set; }


        public string? DescUnidadNaval { get; set; }
        public string? DescEquipoSistemaPropulsion { get; set; }
        public string? DescSistemaPropulsion { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}