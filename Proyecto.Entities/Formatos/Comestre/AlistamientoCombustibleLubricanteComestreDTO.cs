﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Marina.Siesmar.Entidades.Formatos.Comestre
{
    public partial class AlistamientoCombustibleLubricanteComestreDTO
    {

        public int? AlistamientoCombustibleLubricanteId { get; set; }
        public int? UnidadNavalId { get; set; }
        public int? AlistamientoCombustibleLubricante2Id { get; set; }
        public decimal? PromedioPonderado { get; set; }
        public decimal? SubPromedioParcial { get; set; }

        public string? DescUnidadNaval { get; set; }
        public string? Articulo { get; set; }
        public string? Equipo { get; set; }
        public string? UnidadMedida { get; set; }
        public string? Cargo { get; set; }
        public string? Aumento { get; set; }
        public string? Consumo { get; set; }
        public string? Existencia { get; set; }


        [NotMapped]
        public string? UsuarioIngresoRegistro { get; set; }

    }
}