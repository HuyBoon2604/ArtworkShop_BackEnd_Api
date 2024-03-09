using AWS.DTO;
using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AWS.Repositories.Services
{
    public class SOrderPremium : IOrderPremium
    {

        private readonly ARTWORKPLATFORMContext cxt;

        public SOrderPremium(ARTWORKPLATFORMContext cxt)
        {
            this.cxt = cxt;
        }

        public async Task<OrderPremium> AddNewOrder(CreateOrderPremiumDTO create)
        {
            try
            {
                var add = new OrderPremium();
                add.OrderPremiumId = "OP" + Guid.NewGuid().ToString().Substring(0, 6);
                add.PremiumId = create.PremiumId;
                add.UserId = create.UserID;
                add.OrderDate = create.CreateDate;
                add.Status = false;

                var pre = await cxt.Premia.FindAsync(create.PremiumId);
                if (pre != null)
                {
                    add.Total = pre.Price; // Gán giá trị Price từ Premeium cho đơn hàng
                }

                await this.cxt.OrderPremia.AddAsync(add);
                await this.cxt.SaveChangesAsync();
                return add;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OrderPremium>> GetAll()
        {
            try
            {
                var list = await this.cxt.OrderPremia.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderPremium> GetByID(string id)
        {
            try
            {
                var a = await this.cxt.OrderPremia.Where(x => x.OrderPremiumId.Equals(id)).FirstOrDefaultAsync();
                return a;
            }
            catch (Exception ex)
            {


                throw new Exception(ex.Message);
            }
        }
    }
}
