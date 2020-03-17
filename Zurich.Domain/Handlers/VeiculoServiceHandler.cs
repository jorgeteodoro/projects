using System;
using Zurich.Domain.Entities;
using Zurich.Domain.Interfaces;
using ZurichApp.Commands;
using ZurichApp.Domain;
using ZurichApp.Domain.Command;

namespace Zurich.Domain.Handler
{
    public class VeiculoServiceHandler
    {
        private readonly IVeiculoService _rep;
        private readonly int MARGEM_SEGURANCA = 3;
        private readonly int LUCRO = 5;

        public VeiculoServiceHandler(IVeiculoService rep)
        {
            _rep = rep;
        }

        public ICommandResult CreateHandle(CreateCommand cmd)
        {
            decimal valorVeiculo = CalcularSeguro(cmd.ValorVeiculo);

            var entity = new VeiculoEntities(0, valorVeiculo, cmd.Marca, cmd.Modelo, cmd.NomeCarro);

            //validations
            _rep.Add(entity);

            return new CommandResult(true, "Dado criado com sucesso", entity);

        }

        internal decimal CalcularSeguro(decimal ValorVeiculo)
        {
            decimal TaxaRisco = (ValorVeiculo * 5) / (2 * ValorVeiculo);
            decimal PremioRisco = (TaxaRisco * ValorVeiculo);
            decimal PremioPuro = PremioRisco * (1 + MARGEM_SEGURANCA);
            decimal PremioComercial = LUCRO * PremioPuro;

            return PremioComercial;
        }

        //public ICommandResult UpdateHandle(UpdateBankCommand cmd)
        //{
        //    var bank = new Bank(cmd.Name, cmd.Description, (EnumStatus)(cmd.StatusId), cmd.Reason, cmd.Code, cmd.GetId());

        //    //validations
        //    var validator = new BankValidation(_roleRepository, bank);
        //    var validationResult = validator.Validate(bank);
        //    if (!validationResult.IsValid)
        //        return new CommandResult(false, "Erro ao atualizar Banco", validationResult.Errors);

        //    var result = _roleRepository.Update(bank);
        //    return new CommandResult(true, "Banco atualizado com sucesso", bank);
        //}
        //public bool HandleActivate(Guid id, UpdateBankCommand cmd)
        //{

        //    var active = _roleRepository.Get(id);

        //    if (active.StatusId != (int)cmd.StatusId)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

    }
}
