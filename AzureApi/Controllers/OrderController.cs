using AzureApi.Interface;
using AzureApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) 
        { 
            _orderService = orderService;
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<ActionResult<List<Order>>> GetOrders(CancellationToken cancellationToken)
        {
            return await this._orderService.GetOrders(cancellationToken).ConfigureAwait(false);
        }

        [HttpPost]
        [Route("AddOrders")]
        public async Task<ActionResult<bool>> AddOrders([FromBody] Order order, CancellationToken cancellationToken)
        {
            return await this._orderService.AddOrders(order, cancellationToken).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("GetOrderById/{id}")]
        public async Task<ActionResult<List<Order>>> AddOrders(int id, CancellationToken cancellationToken)
        {
            return await this._orderService.GetOrdersById(id, cancellationToken).ConfigureAwait(false);
        }
    }
}
