using System.Collections.Immutable;
using System.ComponentModel;
using System.Net;
using Application.DTOs.OrderItems;
using Application.DTOs.Orders;
using Application.Interfaces;
using Application.Response;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Service;

public class OrderItemService(IOrderItemRepository orderRepository) : IOrderItemService
{
    private readonly IOrderItemRepository repository = orderRepository;
    public async Task<ApiResponse<bool>> AddOrderItem(OrderItemCreateDto orderItem)
    {
        var ord = new OrderItem()
        {
            OrderId = orderItem.OrderId,
            MenuItemId = orderItem.MenuItemId,
            Quantity = orderItem.Quantity,
            Price = orderItem.Price,
            CreatedAt = orderItem.CreatedAt,
            UpdatedAt = orderItem.UpdatedAt
        };
        var res = await repository.AddOrderItem(ord);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "OrderItem added !", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "OrderItem not added !", false);
    }

    public async Task<ApiResponse<bool>> DeleteOrderItem(int id)
    {
        var res = await repository.DeleteOrderItem(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "OrderItem deleted !", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "OrderItem not deleted !", false);
    }

    public async Task<ApiResponse<OrderItemResponseDto>> GetOrderItem(int id)
    {
        var by = await repository.GetOrderItem(id);
        var res = new OrderItemResponseDto
        {
            Id = id,
            OrderId = by.OrderId,
            MenuItemId = by.MenuItemId,
            Quantity = by.Quantity,
            Price = by.Price,
            CreatedAt = by.CreatedAt,
            UpdatedAt = by.UpdatedAt
        };
        if(res == null)
        {
            return new ApiResponse<OrderItemResponseDto>(HttpStatusCode.NotFound, "Not Found !");
        }
        return new ApiResponse<OrderItemResponseDto>(HttpStatusCode.OK, "OrderItem by id", res);
    }

    public async Task<ApiResponse<List<OrderItemResponseDto>>> GetOrderItems()
    {
        var ord = await repository.GetOrderItems();
        var res = ord.Select(s => new OrderItemResponseDto
        {
            Id = s.Id,
            OrderId = s.OrderId,
            MenuItemId = s.MenuItemId,
            Quantity = s.Quantity,
            Price = s.Price,
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt
        }).ToList();
        return new ApiResponse<List<OrderItemResponseDto>>(HttpStatusCode.OK, "List of OrderItem", res);
    }

    public Task<ApiResponse<bool>> UpdateOrderItem(int id, OrderItemUpdateDto orderItem)
    {
        throw new NotImplementedException();
    }
}
