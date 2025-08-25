namespace BudgetWebAPI.Services.Exceptions
{
    public class ValidationException : BusinessException
    {
        public ValidationException(string message) : base(message) { }
        public List<string> ValidationErrors { get; set; } = new();

        public ValidationException(List<string> errors) : base("Erros de validação encontrados")
        {
            ValidationErrors = errors;
        }

    }
}
