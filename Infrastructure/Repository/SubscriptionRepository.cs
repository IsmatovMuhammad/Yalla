using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class SubscriptionRepository(DataBase dataBase) : ISubsciptionRepository
{
    private DataBase data = dataBase;

    public async Task<bool> AddSubscription(Subscription subscription)
    {
        data.Subscriptions.Add(subscription);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteSubscription(int id)
    {
        var del = await data.Subscriptions.FirstOrDefaultAsync(x => x.Id == id);
        if (del != null)
        {
            data.Subscriptions.Remove(del);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> GetPatch(int id)
    {
        var res = await data.Subscriptions.FirstOrDefaultAsync(x => x.Id == id);
        return res != null;
    }

    public async Task<Subscription> GetSubscription(int id)
    {
        var res = await data.Subscriptions.FirstOrDefaultAsync(x => x.Id == id);
        return res ?? new();
    }

    public async Task<List<Subscription>> GetSubscriptions()
    {
        return await data.Subscriptions.ToListAsync();
    }

    public async Task<bool> UpdateSubscription(Subscription subscription)
    {
        var upd = await data.Subscriptions.FirstOrDefaultAsync(x => x.Id == subscription.Id);
        if (upd != null)
        {
            upd.CompanyId = subscription.CompanyId;
            upd.Plantype = subscription.Plantype;
            upd.Mealsperday = subscription.Mealsperday;
            upd.Price = subscription.Price;
            upd.StartDate = subscription.StartDate;
            upd.EndDate = subscription.EndDate;
            upd.Isactive = subscription.Isactive;
            upd.CreatedAt = subscription.CreatedAt;
            upd.UpdatedAt = subscription.UpdatedAt;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }
}