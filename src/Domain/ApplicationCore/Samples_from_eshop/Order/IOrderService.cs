using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Features.Orders
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int basketId, Address shippingAddress);
    }
}
