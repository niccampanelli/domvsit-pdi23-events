﻿using Application.Boundaries.Commom;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Event.Boundaries.List
{
    public class ListInput : IPaginationRequest, ISortingRequest
    {
        [SwaggerSchema(
            Title = "Página",
            Description = "Página a ser listada",
            Format = "int"
            )]
        public int? Page { get; set; }

        [SwaggerSchema(
            Title = "Limite",
            Description = "Limite de itens na página",
            Format = "int"
            )]
        public int? Limit { get; set; }

        [SwaggerSchema(
            Title = "Campo",
            Description = "Campo para ordenar",
            Format = "string"
            )]
        public string? SortField { get; set; }

        [SwaggerSchema(
            Title = "Ordem",
            Description = "Direção da ordenação (asc, desc)",
            Format = "string"
            )]
        public string? SortOrder { get; set; }

        [SwaggerSchema(
            Title = "Id do usuário",
            Description = "Id do consultor responsável pelo evento",
            Format = "long"
            )]
        public long? ConsultorId { get; set; }
    }
}