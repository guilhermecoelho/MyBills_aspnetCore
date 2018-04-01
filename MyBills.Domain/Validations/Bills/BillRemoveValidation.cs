using FluentValidation;
using MyBills.Domain.Entities;

namespace MyBills.Domain.Validations
{
    public class BillRemoveValidation : AbstractValidator<Bill>
    {
        public BillRemoveValidation()
        {
            RuleFor(b => b.Id)
             .NotEmpty().WithMessage("Insert an ID");
        }
    }
}
