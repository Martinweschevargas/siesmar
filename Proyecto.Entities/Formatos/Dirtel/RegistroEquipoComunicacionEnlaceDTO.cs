using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Dirtel
{
    public partial class RegistroEquipoComunicacionEnlaceDTO
    {

        public int? RegistroEquipoComunicacionEnlaceId { get; set; }
        public string? CodigoIBPEquipoEnlace { get; set; }
        public int? MarcaId { get; set; }
        public string? ModeloEquipoEnlace { get; set; }
        public string? ModoEquipoEnlace { get; set; }
        public int? NumeroCanalEquipo { get; set; }
        public string? AnchoBanda { get; set; }
        public string? TipoEquipoComunicacionEnlace { get; set; }
        public string? EstadoOperatividadEnlace { get; set; }
        public string? AnioAdquisicion { get; set; }
        public int? DependenciaId { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public string? DescMarca { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescDepartamento { get; set; }
        public int? CargaId { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
    }
}