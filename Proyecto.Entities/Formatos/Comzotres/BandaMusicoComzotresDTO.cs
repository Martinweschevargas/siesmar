using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comzotres
{
    public partial class BandaMusicoComzotresDTO
    {

        public int? BandaMusicoComzotresId { get; set; }
        public string? CodigoTipoComision { get; set; }
        public string? CodigoEvento { get; set; }
        public string? CodigoGrupoComisionado { get; set; }
        public string? CodigoVestimentaUniforme { get; set; }
        public string? NombreEvento { get; set; }
        public string? Lugar { get; set; }
        public string? FechaHoraSalida { get; set; }
        public string? FechaHoraInicio { get; set; }
        public string? FechaHoraTermino { get; set; }
        public string? RequerimientoMovilidad { get; set; }
        public string? Observacion { get; set; }
        public int? CargaId { get; set; }
        public string? DescTipoComision { get; set; }
        public string? DescEvento { get; set; }
        public string? DescGrupoComisionado { get; set; }
        public string? DescVestimentaUniforme { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}