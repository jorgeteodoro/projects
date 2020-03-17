using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZurichApp.Commands
{
    public class CreateCommand
    {
        public int Id { get; set; }
        public decimal ValorVeiculo { get; set; }
        public string Marca{ get; set; }
        public string Modelo { get; set; }
        public string NomeCarro { get; set; }
    }
}