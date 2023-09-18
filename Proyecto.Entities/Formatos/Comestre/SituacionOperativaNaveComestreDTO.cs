﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comestre
{
    public partial class SituacionOperativaNaveComestreDTO
    {

        public int? SituacionOperativaNaveComestreId { get; set; }
        public int? TipoNaveId { get; set; }
        public int? CascoNave { get; set; }
        public int? TipoPlataformaNaveId { get; set; }
        public int? DependenciaId { get; set; }
        public string? Ubicacion { get; set; }
        public int? DepartamentoUbigeoId { get; set; }
        public int? ProvinciaUbigeoId { get; set; }
        public int? DistritoUbigeoId { get; set; }
        public string? CapacidadOperativaNave { get; set; }
        public string? CondicionNave { get; set; }
        public string? Observacion { get; set; }


        public string? DescTipoNave { get; set; }
        public string? DescTipoPlataformaNave { get; set; }
        public string? DescDependencia { get; set; }
        public string? DescDepartamento { get; set; }
        public string? DescProvincia { get; set; }
        public string? DescDistrito { get; set; }

        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }
        public int Año { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
    }
}