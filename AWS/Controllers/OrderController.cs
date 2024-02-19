using AWS.DTO.Order;
using AWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder order;

        public OrderController(IOrder order)
        {
            this.order = order;
        }

        [HttpGet]
        [Route("get-all")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var a = await this.order.GetAll();
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetAll method: {ex}");

                throw;
            }

        }

        [HttpGet]
        [Route("get-by-id")]

        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                var a = await this.order.GetOrderById(id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetById method: {ex}");

                throw;
            }

        }

        [HttpPost]
        [Route("create-new-order")]

        public async Task<IActionResult> CreateOrder(CreateOrderDTO order)
        {
            try
            {
                var a = await this.order.CreateNewOrder(order);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the CreateOrder method: {ex}");

                throw;
            }

        }
    }
}
