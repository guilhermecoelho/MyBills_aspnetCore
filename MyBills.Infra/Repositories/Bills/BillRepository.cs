using MyBills.Domain.Entities;
using MyBills.Domain.Repositories.Bills;


namespace MyBills.Infra.Repositories.Bills
{
    public class BillRepository : RepositoryBase<Bill>, IBillRepository
    {
        public BillRepository() : base("Bills")
        {
        }
    }
}
