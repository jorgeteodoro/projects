using System;
using System.Collections.Generic;
using System.Text;

namespace Zurich.Domain.Queries
{
    public class VeiculoQuerieResult
    {
        public int Id { get; set; }
        public decimal ValorVeiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NomeCarro { get; set; }
    }
}
