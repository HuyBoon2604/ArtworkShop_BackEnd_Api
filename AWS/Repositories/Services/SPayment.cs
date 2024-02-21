using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AWS.Repositories.Services
{
    public class SPayment : IPayment
    {
        private readonly ARTWORKPLATFORMContext context;

        public SPayment(ARTWORKPLATFORMContext context)
        {
            this.context = context;
        }

        public async Task<Payment> createPayment(string OrderId)
        {
            try
            { 
                var payment = new Payment();
                var order = await this.context.Ordertbs
                              .Where(x => x.OrderId.Equals(OrderId))
                              .FirstOrDefaultAsync();
                if (order != null)
                {
                    payment.PaymentId = "P" + Guid.NewGuid().ToString().Substring(0, 8);
                    payment.OrderId = order.OrderId;
                    payment.CreateDate = DateTime.Now;
                    payment.Amount = order.Total;
                    payment.Status = false;
                    await this.context.Payments.AddAsync(payment);
                    await this.context.SaveChangesAsync();
                    return payment;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Payment> GetPayment(string OrderId)
        {
            try
            {
                var payment = await this.context.Payments
                                .Where(x => x.OrderId.Equals(OrderId))
                                .FirstOrDefaultAsync();
                if (payment != null)
                {
                    return payment;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
