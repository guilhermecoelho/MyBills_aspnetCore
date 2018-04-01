using FluentValidation.Results;
using MyBills.Domain.Entities;
using MyBills.Domain.Repositories.Bills;
using MyBills.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBills.Domain.Services.Bills
{
    public class BillService : ServiceBase<Bill>, IBillService
    {

        //private readonly IMapper _mapper;
        private readonly IBillRepository _billRepository;

        public BillService(IBillRepository billRepository)
            : base(billRepository)
        {
            //this._mapper = mapper;
            this._billRepository = billRepository;
        }

        public async Task<ValidationResult> Insert(List<Bill> billList)
        {
            BillValidation billValidation = new BillValidation();
            ValidationResult validationResult = new ValidationResult();
            Bill billReturn = new Bill();

            foreach(var bill in billList)
            {
                validationResult = billValidation.Validate(bill);

                if (validationResult.IsValid)
                {
                    billReturn = await Task.Run(() => _billRepository.Add(bill));
                }
            }

            return validationResult;
        }

        public async Task<ValidationResult> UpdateBill(Bill bill)
        {
            BillUpdateValidation billValidation = new BillUpdateValidation();

            ValidationResult validationResult = billValidation.Validate(bill);

            if (validationResult.IsValid)
            {
                await Task.Run(() => _billRepository.Update(bill.Id.ToString(), bill));
            }

            return validationResult;
        }

        public async Task<ValidationResult> Delete(Bill bill)
        {
            BillRemoveValidation billValidation = new BillRemoveValidation();

            ValidationResult validationResult = billValidation.Validate(bill);

            if (validationResult.IsValid)
            {
                await Task.Run(() => _billRepository.Remove(bill.Id.ToString()));
            }

            return validationResult;
        }
    }
}
