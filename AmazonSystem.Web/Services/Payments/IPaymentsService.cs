using System.Threading.Tasks;

namespace AmazonSystem.Web.Services.Payments
{
    public interface IPaymentsService
    {
        Task<bool> Pay(int orderId);
    }
}
