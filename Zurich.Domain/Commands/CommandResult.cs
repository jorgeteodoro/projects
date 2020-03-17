using ZurichApp.Domain.Command;

namespace ZurichApp.Domain
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message ?? (success ? "Salvo com sucesso" : "Erro ao Salvar");
        }

        public CommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message ?? (success ? "Salvo com sucesso" : "Erro ao Salvar");
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
