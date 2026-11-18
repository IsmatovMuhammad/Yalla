using System.Net;
using Application.DTOs.Orders;
using Application.Interfaces;
using Application.Response;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    private IOrderRepository repository = orderRepository;
    public async Task<ApiResponse<bool>> AddOrder(OrderCreateDto order)
    {
        var mn = new Order()
        {
            CompanyId = order.CompanyId,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            CreatedAt = order.CreatedAt,
            UpdatedAt = order.UpdatedAt
        };
        var res = await repository.AddOrder(mn);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Order added !", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Order not added !", false);
    }

    public async Task<ApiResponse<bool>> DeleteOrder(int id)
    {
        var del = await repository.DeleteOrder(id);
        return del == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Order deleted !", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Order not deleted !", false);
    }

    public async Task<ApiResponse<OrderResponseDto>> GetOrder(int id)
    {
        var by = await repository.GetOrder(id);
        var or = new OrderResponseDto
        {
            CompanyId = by.CompanyId,
            OrderDate = by.OrderDate,
            Status = by.Status,
            TotalAmount = by.TotalAmount,
            CreatedAt = by.CreatedAt,
            UpdatedAt = by.UpdatedAt
        };
        if(or == null)
        {
            return new ApiResponse<OrderResponseDto>(HttpStatusCode.NotFound, "Not found");
        }
        return new ApiResponse<OrderResponseDto>(HttpStatusCode.OK, "Order by id", or);
    }

    public async Task<ApiResponse<List<OrderResponseDto>>> GetOrders()
    {
        var or = await repository.GetOrders();
        var res = or.Select(s => new OrderResponseDto
        {
            CompanyId = s.CompanyId,
            OrderDate = s.OrderDate,
            Status = s.Status,
            TotalAmount = s.TotalAmount,
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt
        }).ToList();
        return new ApiResponse<List<OrderResponseDto>>(HttpStatusCode.OK, "List of Order", res);
    }

    public async Task<ApiResponse<bool>> UpdateOrder(int id, OrderUpdateDto order)
    {
        var upd = new Order()
        {
            Id = id,
            CompanyId = order.CompanyId,
            OrderDate = order.OrderDate,
            Status = order.Status,
            TotalAmount = order.TotalAmount,
            CreatedAt = order.CreatedAt,
            UpdatedAt = order.UpdatedAt
        };
        var res = await repository.UpdateOrder(upd);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Order updated !", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Order not updated !", false);
    }

}
