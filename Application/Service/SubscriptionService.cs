using System.Net;
using System.Security;
using Application.DTOs.Subsciptions;
using Application.Interfaces;
using Application.Response;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class SubscriptionService(ISubsciptionRepository subsciptionRepository) : ISubscriptionService
{
    private readonly ISubsciptionRepository repository = subsciptionRepository;
    public async Task<ApiResponse<bool>> AddSubscription(SubscriptionCreateDto subscription)
    {
        var sb = new Subscription()
        {
            CompanyId = subscription.CompanyId,
            Plantype = subscription.Plantype,
            Mealsperday = subscription.Mealsperday,
            Price = subscription.Price,
            StartDate = subscription.StartDate,
            EndDate = subscription.EndDate,
            Isactive = subscription.Isactive,
            CreatedAt = subscription.CreatedAt,
            UpdatedAt = subscription.UpdatedAt
        };
        var res = await repository.AddSubscription(sb);
        return res == true
        ?new ApiResponse<bool>(HttpStatusCode.OK, "Subscription added !", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Subscription not added !", false);
    }

    public async Task<ApiResponse<bool>> DeleteSubscription(int id)
    {
        var res = await repository.DeleteSubscription(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Subscription deleted !", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Subscription not deleted !",false);
    }

    public async Task<ApiResponse<bool>> GetPatch(int id)
    {
        var patch = await repository.GetPatch(id);
        return patch == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Subscription patch is true")
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Sibscription is false");
    }

    public async Task<ApiResponse<SubscriptionResponseDto>> GetSubscription(int id)
    {
        var sb = await repository.GetSubscription(id);
        var res = new SubscriptionResponseDto
        {
            Id = sb.Id,
            CompanyId = sb.CompanyId,
            Plantype = sb.Plantype,
            Mealsperday = sb.Mealsperday,
            Price = sb.Price,
            StartDate = sb.StartDate,
            EndDate = sb.EndDate,
            Isactive = sb.Isactive,
            CreatedAt = sb.CreatedAt,
            UpdatedAt = sb.UpdatedAt
        };
        return new ApiResponse<SubscriptionResponseDto>(HttpStatusCode.OK, "Subscription by id", res);
    }

    public async Task<ApiResponse<List<SubscriptionResponseDto>>> GetSubscriptions()
    {
        var sb = await repository.GetSubscriptions();
        var res = sb.Select(x => new SubscriptionResponseDto
        {
            Id = x.Id,
            CompanyId = x.CompanyId,
            Plantype = x.Plantype,
            Mealsperday = x.Mealsperday,
            Price = x.Price,
            StartDate = x.StartDate,
            EndDate = x.EndDate,
            Isactive = x.Isactive,
            CreatedAt = x.CreatedAt,
            UpdatedAt = x.UpdatedAt
        }).ToList();
        return new ApiResponse<List<SubscriptionResponseDto>>(HttpStatusCode.OK, "List of Subscription", res);
    }

    public async Task<ApiResponse<bool>> UpdateSubscription(int id, SubscripionUpdate subscription)
    {
        var sb = new Subscription()
        {
            Id = id,
            CompanyId = subscription.CompanyId,
            Plantype = subscription.Plantype,
            Mealsperday = subscription.Mealsperday,
            Price = subscription.Price,
            StartDate = subscription.StartDate,
            EndDate = subscription.EndDate,
            Isactive = subscription.Isactive,
            CreatedAt = subscription.CreatedAt,
            UpdatedAt = subscription.UpdatedAt
        };
        var res = await repository.UpdateSubscription(sb);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Subscription updated !", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Subcription not updated", false);
    }

}
