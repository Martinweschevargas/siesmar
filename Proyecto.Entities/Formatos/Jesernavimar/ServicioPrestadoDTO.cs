using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Jesernavimar
{
    public partial class ServicioPrestadoDTO
    {

        public int? ServicioPrestadoId { get; set; }
        public string? CodigoUnidadNaval { get; set; }
        public string? DocumentoServicio { get; set; }
        public string? FechaServicioPrestado { get; set; }
        public int? UnidadAuxiliarNaval { get; set; }
        public string? NroViajeComercial { get; set; }
        public int? PuertoPeruZarpe { get; set; }
        public int? DepartamentoZarpe { get; set; }
        public int? ProvinciaZarpe { get; set; }
        public int? DistritoZarpe { get; set; }
        public string? FechaHoraZarpe { get; set; }
        public string? Ocurrencia { get; set; }
        public int? PuertoPeruArribo { get; set; }
        public int? DepartamentoArribo { get; set; }
        public int? ProvinciaArribo { get; set; }
        public int? DistritoArribo { get; set; }
        public string? FechaHoraArribo { get; set; }
        public string? EmpresaReceptoraServicio { get; set; } 
 

        public string? DescUnidadNaval { get; set; }
        public string? DescUnidadAuxiliarNaval { get; set; }
        public string? DescPuertoPeruZarpe { get; set; }
        public string? DescDepartamentoZarpe { get; set; }
        public string? DescProvinciaZarpe { get; set; }
        public string? DescDistritoZarpe { get; set; }
        public string? DescPuertoPeruArribo { get; set; }
        public string? DescDepartamentoArribo { get; set; }
        public string? DescProvinciaArribo { get; set; }
        public string? DescDistritoArribo { get; set; } 
        public int? CargaId { get; set; }
        
        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}
