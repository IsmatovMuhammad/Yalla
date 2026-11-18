using Application.DTOs.Subsciptions;
using Application.Response;

namespace Application.Interfaces;

public interface ISubscriptionService
{
    Task<ApiResponse<bool>> AddSubscription(SubscriptionCreateDto subscription);
    Task<ApiResponse<bool>> UpdateSubscription(int id, SubscripionUpdate subscription);
    Task<ApiResponse<bool>> DeleteSubscription(int id);
    Task<ApiResponse<SubscriptionResponseDto>> GetSubscription(int id);
    Task<ApiResponse<List<SubscriptionResponseDto>>> GetSubscriptions();
    Task<ApiResponse<bool>> GetPatch(int id);
}
