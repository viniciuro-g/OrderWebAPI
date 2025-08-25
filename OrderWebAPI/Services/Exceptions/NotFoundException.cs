namespace BudgetWebAPI.Services.Exceptions
{
    public class NotFoundException : BusinessException
    {
        public NotFoundException(string entity, int id) : base($"{entity} com ID {id} não foi encontrado") { }
        public NotFoundException(string message) : base(message) { }
    }
}
