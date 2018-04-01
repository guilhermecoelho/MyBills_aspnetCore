using FluentValidation.Results;
using MyBills.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBills.Domain.Services.Bills
{
    public interface IBillService : IServiceBase<Bill>
    {
        Task<ValidationResult> Insert(List<Bill> bill);
        Task<ValidationResult> UpdateBill(Bill bill);
        Task<ValidationResult> Delete(Bill bill);
    }
}
