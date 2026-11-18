using Application.DTOs.MenuDto;
using Application.Response;
using Domain.Models;

namespace Application.Interfaces;

public interface IMenuService
{
    Task<ApiResponse<bool>> AddMenu(CreateMenuDto menu);
    Task<ApiResponse<bool>> DeleteMenu(int id);
    Task<ApiResponse<bool>> UpdateMenu(int id, UpdateMenuDto menu);
    Task<ApiResponse<Menu>> GetMenu(int id);
    Task<ApiResponse<List<Menu>>> GetMenus();
}
