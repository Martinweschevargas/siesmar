using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel { 
    public partial class RegistroEquipoComunicacionDTO
{

        public int? RegistroEquipoComunicacionId { get; set; }
        public string? CodigoIBPEquipoComunicacion { get; set; }
        public int? ModeloBienServicioSubcampoId { get; set; }
        public int? ModeloBienServicioDenominacionId { get; set; }
        public int? MarcaId { get; set; }
        public int? ModeloEquipoComunicacionId { get; set; }
        public string? ModoComunicacion { get; set; }
        public int? TipoComunicacionDirtelId { get; set; }
        public string? AnioAdquisicionComunicacion { get; set; }
        public string? EstadoOperatividadComunicacion { get; set; }
        public int? DependenciaId { get; set; }
        public int? DepartamentoUbigeoId { get; set; }

        public string? DescModeloBienServicioSubcampo { get; set; }
        public string? DescModeloBienServicioDenominacion { get; set; }
        public string? DescMarca { get; set; }
        public string? DescModeloEquipoComunicacion { get; set; }
        public string? DescTipoComunicacionDirtel { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescDepartamento { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}