using AWS.DTO;
using AWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private readonly IPremium premium;

        public PremiumController(IPremium premium)
        {
            this.premium = premium;
        }

        [HttpGet]
        [Route("get-all")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var a = await this.premium.GetAll();
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
        [HttpPost]
        [Route("create-new-order-premium")]

        public async Task<IActionResult> CreateOrderPremium(string id)
        {
            try
            {
                var a = await this.premium.CreateNewOrderPremium(id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the CreatePayment method: {ex}");

                throw;
            }

        }

        [HttpGet]
        [Route("get-premium-order-by-order-id")]

        public async Task<IActionResult> GetOrderPremium(string id)
        {
            try
            {
                var a = await this.premium.GetOrderPremium(id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetPayement method: {ex}");

                throw;
            }

        }
    }
}

