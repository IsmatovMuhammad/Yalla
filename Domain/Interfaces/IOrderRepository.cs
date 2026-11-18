using Domain.Models;

namespace Domain.Interfaces;

public interface IOrderRepository
{
    Task<bool> AddOrder(Order order);
    Task<bool> UpdateOrder(Order order);
    Task<bool> DeleteOrder(int id);
    Task<Order> GetOrder(int id);
    Task<List<Order>> GetOrders();
}
