using System;
using System.Collections.Generic;
using System.Text;

namespace Zurich.Domain.Entities
{
    public class VeiculoEntities
    {

        public VeiculoEntities(int id, decimal valorVeiculo, string marca, string modelo, string nomeCarro)
        {
            this.Id = id;
            this.ValorVeiculo = valorVeiculo;
            this.Marca = marca;
            this.Modelo = modelo;
            this.NomeCarro = nomeCarro;
        }

        public int Id { get; private set; }
        public decimal ValorVeiculo { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public string NomeCarro { get; private set; }
        //public void SetId(int id) => Id = id;
    }
}
