using System.Net;
using Application.DTOs.MenuItems;
using Application.Interfaces;
using Application.Response;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class MenuItemService(IMenuItemRepository repository1) : IMenuItemService
{
    private IMenuItemRepository repository = repository1;

    async Task<ApiResponse<bool>> IMenuItemService.AddIMenuItem(MenuItemCreateDto menuItem)
    {
        var mn = new MenuItem()
        {
            MenuId = menuItem.MenuId,
            Name = menuItem.Name,
            Description = menuItem.Description,
            Price = menuItem.Price,
            Category = menuItem.Category,
            CreatedAt = menuItem.CreatedAt,
            UpdatedAt = menuItem.UpdatedAt
        };
        var res = await repository.AddIMenuItem(mn);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "MenuItem added", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "MenuItem not added", false);
    }

    async Task<ApiResponse<bool>> IMenuItemService.DeleteIMenuItem(int Id)
    {
        var del = await repository.DeleteIMenuItem(Id);
        return del == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "MenuItem deleted !", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "MenuItem not deleted !", false);
    }

    async Task<ApiResponse<MenuItemResponseDto>> IMenuItemService.GetIMenuItems(int id)
    {
        var mn = await repository.GetIMenuItem(id);
        var by = new MenuItemResponseDto
        {
            MenuId = mn.MenuId,
            Name = mn.Name,
            Description = mn.Description,
            Price = mn.Price,
            Category = mn.Category,
            CreatedAt = mn.CreatedAt,
            UpdatedAt = mn.UpdatedAt
        };
        if(by == null)
        {
            return new ApiResponse<MenuItemResponseDto>(HttpStatusCode.NotFound, "Not found");
        }
        return new ApiResponse<MenuItemResponseDto>(HttpStatusCode.OK, "MenuItem by id", by);
    }

    async Task<ApiResponse<List<MenuItemResponseDto>>> IMenuItemService.GetIMenuItem()
    {
        var li = await repository.GetIMenuItemR();
        var mn = li.Select(s => new MenuItemResponseDto
        {
            MenuId = s.MenuId,
            Name = s.Name,
            Description = s.Description,
            Price = s.Price,
            Category = s.Category,
            CreatedAt = s.CreatedAt,
            UpdatedAt = s.UpdatedAt
        }).ToList();
        return new ApiResponse<List<MenuItemResponseDto>>(HttpStatusCode.OK, "List by MenuItem", mn);
    }

    async Task<ApiResponse<bool>> IMenuItemService.UpdateIMenuItem(int id, MenuItemUpdateDto menuItem)
    {
        var upd = new MenuItem()
        {
            Id = id,
            MenuId = menuItem.MenuId,
            Description = menuItem.Description,
            Price = menuItem.Price,
            Category = menuItem.Category,
            CreatedAt = menuItem.CreatedAt,
            UpdatedAt = menuItem.UpdatedAt
        };
        var res = await repository.UpdateIMenuItem(upd);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "MenuItem updated !", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "MenuItem not updated !", false);
    }
}
