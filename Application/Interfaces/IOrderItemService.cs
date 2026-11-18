using Application.DTOs.OrderItems;
using Application.Response;

namespace Application.Interfaces;

public interface IOrderItemService
{
    Task<ApiResponse<bool>> AddOrderItem(OrderItemCreateDto orderItem);
    Task<ApiResponse<bool>> UpdateOrderItem(int id, OrderItemUpdateDto orderItem);
    Task<ApiResponse<bool>> DeleteOrderItem(int id);
    Task<ApiResponse<OrderItemResponseDto>> GetOrderItem(int id);
    Task<ApiResponse<List<OrderItemResponseDto>>> GetOrderItems();
}
