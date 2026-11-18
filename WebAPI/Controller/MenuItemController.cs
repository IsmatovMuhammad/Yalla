using Application.DTOs.MenuItems;
using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class MenuItemController(IMenuItemService menuItemService) : ControllerBase
{
    private readonly IMenuItemService service = menuItemService;

    [HttpGet]
    public async Task<ApiResponse<List<MenuItemResponseDto>>> GetIMenuItem()
    {
        return await service.GetIMenuItem();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddIMenuItem(MenuItemCreateDto menuItem)
    {
        return await service.AddIMenuItem(menuItem);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteIMenuItem(int Id)
    {
        return await service.DeleteIMenuItem(Id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateIMenuItem(int id, MenuItemUpdateDto menuItem)
    {
        return await service.UpdateIMenuItem(id, menuItem);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<MenuItemResponseDto>> GetIMenuItem(int id)
    {
        return await service.GetIMenuItems(id);
    }
}
