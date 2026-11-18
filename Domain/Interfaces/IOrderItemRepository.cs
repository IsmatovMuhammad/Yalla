using Domain.Models;

namespace Domain.Interfaces;

public interface IOrderItemRepository
{
    Task<bool> AddOrderItem(OrderItem orderItem);
    Task<bool> UpdateOrderItem(OrderItem orderItem);
    Task<bool> DeleteOrderItem(int id);
    Task<OrderItem> GetOrderItem(int id);
    Task<List<OrderItem>> GetOrderItems();

}
