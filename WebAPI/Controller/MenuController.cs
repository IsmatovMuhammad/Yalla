using Application.DTOs.MenuDto;
using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class MenuController(IMenuService menuService) : ControllerBase
{
    private IMenuService service = menuService;

    [HttpGet]
    public async Task<ApiResponse<List<Menu>>> GetMenus()
    {
        return await service.GetMenus();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddMenu(CreateMenuDto menu)
    {
        return await service.AddMenu(menu);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteMenu(int id)
    {
        return await service.DeleteMenu(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateMenu(int id, UpdateMenuDto menu)
    {
        return await service.UpdateMenu(id, menu);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Menu>> GetMenu(int id)
    {
        return await service.GetMenu(id);
    }
}
