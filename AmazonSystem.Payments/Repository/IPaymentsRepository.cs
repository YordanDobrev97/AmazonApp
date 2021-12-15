using System.Threading.Tasks;

namespace AmazonSystem.Payments.Repository
{
    public interface IPaymentsRepository
    {
        Task<bool> Pay(int orderId);
    }
}
