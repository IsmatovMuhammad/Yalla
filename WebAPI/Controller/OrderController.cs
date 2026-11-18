using Application.DTOs.Orders;
using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class OrderController(IOrderService orderService) : ControllerBase
{
    private readonly IOrderService service = orderService;

    [HttpGet]
    public async Task<ApiResponse<List<OrderResponseDto>>> GetOrders()
    {
        return await service.GetOrders();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddOrder(OrderCreateDto order)
    {
        return await service.AddOrder(order);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateOrder(int id, OrderUpdateDto order)
    {
        return await service.UpdateOrder(id, order);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteOrder(int id)
    {
        return await service.DeleteOrder(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<OrderResponseDto>> GetOrder(int id)
    {
        return await service.GetOrder(id);
    }
}
