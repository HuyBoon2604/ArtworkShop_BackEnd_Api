using AWS.Models;

namespace AWS.Repositories.Interfaces
{
    public interface IOrderPremiumLog
    {
        Task<List<OrderPremiumLog>> GetPaymentList();
        Task<OrderPremiumLog> createPayment(string OrderPremiumId);

    }
}
