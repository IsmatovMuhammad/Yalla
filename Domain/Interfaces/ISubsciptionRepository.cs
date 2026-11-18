using Domain.Models;

namespace Domain.Interfaces;

public interface ISubsciptionRepository
{
    Task<bool> AddSubscription(Subscription subscription);
    Task<bool> UpdateSubscription(Subscription subscription);
    Task<bool> DeleteSubscription(int id);
    Task<Subscription> GetSubscription(int id);
    Task<List<Subscription>> GetSubscriptions();
    Task<bool> GetPatch(int id);
}
