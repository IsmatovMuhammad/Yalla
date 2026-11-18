using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class OrderRepository(DataBase dataBase) : IOrderRepository
{
    private DataBase data = dataBase;

    public async Task<bool> AddOrder(Order order)
    {
        data.Orders.Add(order);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteOrder(int id)
    {
        var del = await data.Orders.FirstOrDefaultAsync(x => x.Id == id);
        if (del != null)
        {
            data.Orders.Remove(del);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Order> GetOrder(int id)
    {
        var res = await data.Orders.FirstOrDefaultAsync(x => x.Id == id);
        return res ?? new();
    }

    public async Task<List<Order>> GetOrders()
    {
        return await data.Orders.ToListAsync();
    }

    public async Task<bool> UpdateOrder(Order order)
    {
        var upd = await data.Orders.FirstOrDefaultAsync(x => x.Id == order.Id);
        if (upd != null)
        {
            upd.CompanyId = order.CompanyId;
            upd.OrderDate = order.OrderDate;
            upd.Status = order.Status;
            upd.TotalAmount = order.TotalAmount;
            upd.CreatedAt = order.CreatedAt;
            upd.UpdatedAt = order.UpdatedAt;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }
}