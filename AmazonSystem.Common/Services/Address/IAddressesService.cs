using System.Threading.Tasks;

namespace AmazonSystem.Common.Services.Addresses
{
    public interface IAddressesService
    {
        int IsExist(string street, string city, string country);

        Task<int> Create(string street, string city, string country, string zipCode);
    }
}
