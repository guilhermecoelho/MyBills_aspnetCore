using FluentValidation.Results;

namespace MyBills.API.Response
{
    public class ResponseGenerics
    {
        public long Total { get; set; }
        public long CodeStatus { get; set; }
        public string ErrorMessage { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
