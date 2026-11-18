using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class OrderItemRepository(DataBase dataBase) : IOrderItemRepository
{
    private DataBase data = dataBase;

    public async Task<bool> AddOrderItem(OrderItem orderItem)
    {
        data.OrderItems.Add(orderItem);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteOrderItem(int id)
    {
        var del = await data.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
        if (del != null)
        {
            data.OrderItems.Remove(del);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<OrderItem> GetOrderItem(int id)
    {
        var res = await data.OrderItems.FirstOrDefaultAsync(x => x.Id == id);
        return res ?? new();
    }

    public async Task<List<OrderItem>> GetOrderItems()
    {
        return await data.OrderItems.ToListAsync();
    }

    public async Task<bool> UpdateOrderItem(OrderItem orderItem)
    {
        var upd = await data.OrderItems.FirstOrDefaultAsync(x => x.Id == orderItem.Id);
        if (upd != null)
        {
            upd.OrderId = orderItem.OrderId;
            upd.MenuItemId = orderItem.MenuItemId;
            upd.Quantity = orderItem.Quantity;
            upd.Price = orderItem.Price;
            upd.CreatedAt = orderItem.CreatedAt;
            upd.UpdatedAt = orderItem.UpdatedAt;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }
}