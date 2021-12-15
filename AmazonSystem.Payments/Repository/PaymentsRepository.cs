using AmazonSystem.Data;
using AmazonSystem.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonSystem.Payments.Repository
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly ApplicationDbContext dbContext;

        public PaymentsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> Pay(int orderId)
        {
            var existOrder = this.dbContext.Orders.Any(x => x.Id == orderId);

            if (!existOrder)
            {
                return false;
            }

            var newPayment = new Payment()
            {
                OrderId = orderId,
                IsValidPayment = true,
            };

            await this.dbContext.Payments.AddAsync(newPayment);
            await this.dbContext.SaveChangesAsync();
            return true;
        }
    }
}
