using AWS.DTO.Order;
using AWS.Models;
using AWS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AWS.Repositories.Services
{
    public class SOrder : IOrder
    {
        private readonly ARTWORKPLATFORMContext cxt;

        public SOrder(ARTWORKPLATFORMContext cxt)
        {
            this.cxt = cxt;
        }

        public async Task<Ordertb> CreateNewOrder(CreateOrderDTO order)
        {
            try
            {
                var add = new Ordertb();
                add.OrderId = "O" + Guid.NewGuid().ToString().Substring(0, 6);
                add.ArtworkId = order.ArtwokID;
                add.UserId = order.UserID;
                add.CreateDate = order.CreateDate;
                await this.cxt.Ordertbs.AddAsync(add);
                await this.cxt.SaveChangesAsync();
                return add;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
     
        }

        public async Task<List<Ordertb>> GetAll()
        {
            try
            {
                var list = await this.cxt.Ordertbs.ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Ordertb> GetOrderById(string id)
        {
            try
            {
                var a = await this.cxt.Ordertbs.Where(x => x.OrderId.Equals(id)).FirstOrDefaultAsync();
                return a;
            }
            catch (Exception ex) 
            {


                throw new Exception(ex.Message);
            }
          
        }
    }
}
