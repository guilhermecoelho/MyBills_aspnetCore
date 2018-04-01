using FluentValidation;
using MyBills.Domain.Entities;

namespace MyBills.Domain.Validations
{
    public class BillValidation : AbstractValidator<Bill>
    {
        public BillValidation()
        {
            RuleFor(b => b.Name)
                .NotEmpty().WithMessage("Insert a name");

            RuleFor(b => b.Value)
               .NotEmpty().WithMessage("Insert a value");

            RuleFor(b => b.DatePayed)
               .NotEmpty().WithMessage("Insert a date");

        }
    }
}
