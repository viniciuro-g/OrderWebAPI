using AutoMapper;
using BudgetWebAPI.DTOs;
using BudgetWebAPI.Models.Enum;
using BudgetWebAPI.Services.Exceptions;
using BudgetWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OrderWebAPI.Models.Entities;

namespace BudgetWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetOrdersAsync();
                var orderResults = _mapper.Map<ICollection<OrderDto>>(orders);
                return Ok(orderResults);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var orderEntity = await _orderService.GetOrderByIdAsync(id);
                var orderResult = _mapper.Map<OrderDto>(orderEntity);
                return Ok(orderResult);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("/by-customer/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int customerId)
        {
            try
            {
                var ordersEntity = await _orderService.GetOrderByCostumerIdAsync(customerId);
                var orderResults = _mapper.Map<ICollection<OrderDto>>(ordersEntity);
                return Ok(orderResults);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpGet("/by-status/{status}")]
        public async Task<IActionResult> GetOrdersByStatus(Status status)
        {
            try
            {
                var ordersEntity = await _orderService.GetOrdersByStatusAsync(status);
                var orderResults = _mapper.Map<ICollection<OrderDto>>(ordersEntity);
                return Ok(orderResults);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderCreateDto createOrderDto)
        {
            try
            {
                var orderEntity = _mapper.Map<Order>(createOrderDto);

                var orderResult = await _orderService.CreateOrderAsync(orderEntity);

                var orderDto = _mapper.Map<OrderDto>(orderResult);
                return CreatedAtAction(nameof(GetOrderById), new { id = orderDto.Id }, orderDto);
            }
            catch (BusinessException ex)
            { 
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, OrderUpdateDto updateOrderDto)
        {
            if (id != updateOrderDto.Id)
            {
                return BadRequest("ID do orçamento e do objeto não coincidem");
            }   
            try
            {
                var orderEntity = await _orderService.GetOrderByIdAsync(updateOrderDto.Id);
                _mapper.Map(updateOrderDto,orderEntity);
                await _orderService.UpdateOrderAsync(orderEntity);

                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var orderEntity = _orderService.GetOrderByIdAsync(id);
                await _orderService.DeleteOrderAsync(orderEntity.Id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
        }



        // ORDER ITEMS ENDPOINTS

        [HttpPost("{orderId}/items")]
        public async Task<IActionResult> AddItemToOrder(int orderId, [FromBody] OrderItemCreateDto itemDto)
        {
            try
            {
                var orderEntity = _mapper.Map<OrderItem>(itemDto);
                var orderResult = await _orderService.AddItemToOrderAsync(orderId, orderEntity);
                var resultDto = _mapper.Map<OrderItemDto>(orderResult);
                return Ok(resultDto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{orderId}/items/{itemId}")]
        public async Task<IActionResult> UpdateOrderItem(int orderId, int itemId, [FromBody] OrderItemUpdateDto itemDto)
        {
            if (itemId != itemDto.Id)
            {
                return BadRequest("O ID do item na rota e no corpo da requisição não coincidem");
            }
            try
            {
                var itemEntity = _mapper.Map<OrderItem>(itemDto);
                await _orderService.UpdateItemInOrderAsync(orderId, itemId, itemEntity);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{orderId}/items/{itemId}")]
        public async Task<IActionResult> DeleteOrderItem(int orderId, int itemId)
        {
            try
            {
                await _orderService.DeleteItemInOrderAsync(orderId, itemId);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }


    }
}
