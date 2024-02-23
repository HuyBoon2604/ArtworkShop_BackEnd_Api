using AWS.Models;

namespace AWS.Repositories.Interfaces
{
    public interface IPayment
    {
        Task<Payment> createPayment(string OrderId);
        Task<Payment> GetPayment(string OrderId);
        Task<List<Payment>> GetPaymentList();
    }
}
