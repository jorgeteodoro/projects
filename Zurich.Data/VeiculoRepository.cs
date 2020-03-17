using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using Dapper;
using DapperExtensions.Mapper;
using Zurich.Domain.Entities;
using Zurich.Domain.Interfaces;
using Zurich.Domain.Queries;
using Zurich.Infrastructure.Data;

namespace Zurich.Data.Repository
{
    public class VeiculoRepositoryResultMapper : ClassMapper<VeiculoEntities>
    {
        public VeiculoRepositoryResultMapper()
        {
            Table("Veiculo");
            Map(t => t.Id).Column("Id");
            Map(t => t.Marca).Column("Marca");
            Map(t => t.Modelo).Column("Modelo");
            Map(t => t.NomeCarro).Column("NomeCarro");
            Map(t => t.ValorVeiculo).Column("ValorVeiculo");
            AutoMap();
        }
    }

        public class VeiculoRepository : Repository<VeiculoEntities, Guid>, IVeiculoService
    {
            private readonly IDbConnection connection;


            public VeiculoRepository(IDbConnection connection) : base(connection)
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["zurich"].ConnectionString;
                DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(VeiculoRepositoryResultMapper).Assembly });
                this.connection = connection;
            }

            public new void Add(VeiculoEntities item)
            {
                connection.ConnectionString = ConfigurationManager.ConnectionStrings["zurich"].ConnectionString;
                base.Add(item);
            }

        public IEnumerable<VeiculoQuerieResult> Get()
        {
            string query = @"SELECT a.[Id]
                                  ,a.[Marca]
                                  ,a.[Modelo]
                                  ,a.[NomeCarro]
                                  ,a.[ValorVeiculo]
                              FROM [veiculos] a";

            return connection.Query<VeiculoQuerieResult>(query.ToString());
        }

        public new void Update(VeiculoEntities item)
        {
            connection.ConnectionString = ConfigurationManager.ConnectionStrings["zurich"].ConnectionString;
            var cmd = new StringBuilder();
           
            cmd.AppendLine(@"UPDATE [veiculos] SET [Marca] = @marca
                                                  ,[Modelo] = @modelo
                                                  ,[NomeCarro] = @nomeCarro
                                                  ,[ValorVeiculo] = @valorVeiculo");
            cmd.AppendLine("WHERE Id = @id ");

            var param = new
            {
                item.Marca,
                item.Modelo,
                item.ValorVeiculo,
              
                item.Id
            };

            connection.Execute(cmd.ToString(), param);
        }

        
    }
}
