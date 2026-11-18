using Application.DTOs.MenuItems;
using Application.Response;
using Domain.Models;
using Infrastructure.Repository;

namespace Application.Interfaces;

public interface IMenuItemService
{
    Task<ApiResponse<bool>> AddIMenuItem(MenuItemCreateDto menuItem);
    Task<ApiResponse<bool>> DeleteIMenuItem(int Id);
    Task<ApiResponse<bool>> UpdateIMenuItem(int id, MenuItemUpdateDto menuItem);
    Task<ApiResponse<MenuItemResponseDto>> GetIMenuItems(int id);
    Task<ApiResponse<List<MenuItemResponseDto>>> GetIMenuItem();
}
