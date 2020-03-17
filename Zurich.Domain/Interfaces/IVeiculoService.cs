using System;
using System.Collections.Generic;
using Zurich.Domain.Entities;
using Zurich.Domain.Queries;

namespace Zurich.Domain.Interfaces
{
    public interface IVeiculoService
    {
        void Update(VeiculoEntities veiculoEntities);
        void Add(VeiculoEntities veiculoEntities);
        IEnumerable<VeiculoQuerieResult> Get();
    }
}
