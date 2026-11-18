using Application.DTOs.Orders;
using Application.Response;
using Domain.Models;

namespace Application.Interfaces;

public interface IOrderService
{
    Task<ApiResponse<bool>> AddOrder(OrderCreateDto order);
    Task<ApiResponse<bool>> UpdateOrder(int id, OrderUpdateDto order);
    Task<ApiResponse<bool>> DeleteOrder(int id);
    Task<ApiResponse<OrderResponseDto>> GetOrder(int id);
    Task<ApiResponse<List<OrderResponseDto>>> GetOrders();
}
