using AmazonSystem.Payments.Repository;
using System;
using System.Threading.Tasks;

namespace AmazonSystem.Web.Services.Payments
{
    public class PaymentsService : IPaymentsService
    {
        private readonly IPaymentsRepository paymentRepository;

        public PaymentsService(IPaymentsRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        public async Task<bool> Pay(int orderId)
        {
            return await this.paymentRepository.Pay(orderId);
        }
    }
}
