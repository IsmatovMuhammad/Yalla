using System.Globalization;
using Application.DTOs.OrderItems;
using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class OrderItemController(IOrderItemService orderItemService) : ControllerBase
{
    private readonly IOrderItemService service = orderItemService;

    [HttpGet]
    public async Task<ApiResponse<List<OrderItemResponseDto>>> GetOrderItems()
    {
        return await service.GetOrderItems();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddOrderItem(OrderItemCreateDto orderItem)
    {
        return await service.AddOrderItem(orderItem);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateOrderItem(int id, OrderItemUpdateDto orderItem)
    {
        return await service.UpdateOrderItem(id, orderItem);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteOrderItem(int id)
    {
        return await service.DeleteOrderItem(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<OrderItemResponseDto>> GetOrderItem(int id)
    {
        return await service.GetOrderItem(id);
    }
}
