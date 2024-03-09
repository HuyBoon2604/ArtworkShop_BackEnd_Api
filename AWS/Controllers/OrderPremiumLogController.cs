using AWS.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderPremiumLogController : ControllerBase
    {
        private readonly IOrderPremiumLog orderPremiumLog;

        public OrderPremiumLogController(IOrderPremiumLog orderPremiumLog)
        {
            this.orderPremiumLog = orderPremiumLog;
        }

        [HttpGet]
        [Route("get-all")]

        public async Task<IActionResult> GetAll()
        {
            try
            {
                var a = await this.orderPremiumLog.GetPaymentList();
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the GetPaymentList method: {ex}");

                throw;
            }

        }

        [HttpPost]
        [Route("create-new-Premium-log")]

        public async Task<IActionResult> CreateNew(string id)
        {
            try
            {
                var a = await this.orderPremiumLog.createPayment(id);
                if (a == null)
                {
                    return NotFound();
                }
                return Ok(a);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred in the CreateNew method: {ex}");

                throw;
            }

        }

    }
}
