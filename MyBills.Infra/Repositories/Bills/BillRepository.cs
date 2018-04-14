using Microsoft.Extensions.Configuration;
using MyBills.Domain.Entities;
using MyBills.Domain.Repositories.Bills;


namespace MyBills.Infra.Repositories.Bills
{
    public class BillRepository : RepositoryBase<Bill>, IBillRepository
    {
        private IConfiguration _configuration;

        public BillRepository(IConfiguration configuration) : base("Bills", configuration)
        {
        }
    }
}
