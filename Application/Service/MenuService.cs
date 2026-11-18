using System.Net;
using Application.DTOs.MenuDto;
using Application.Interfaces;
using Application.Response;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class MenuService(IMenuRepository menuRepository) : IMenuService
{
    private IMenuRepository repository = menuRepository;
    public async Task<ApiResponse<bool>> AddMenu(CreateMenuDto menu)
    {
        Menu mn = new()
        {
            MenuDate = menu.MenuDate,
            isactive = menu.isactive,
            CreatedAt = menu.CreatedAt,
            UpdatedAt = menu.UpdatedAt
        };
        var res = await repository.AddMenu(mn);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Company added ! ", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Company not added !");
    }

    public async Task<ApiResponse<bool>> DeleteMenu(int id)
    {
        var res = await repository.DeleteMenu(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Menu deleted !", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Menu not deleted ! ");
    }

    public async Task<ApiResponse<Menu>> GetMenu(int id)
    {
        var res = await repository.GetMenu(id);
        return new ApiResponse<Menu>(HttpStatusCode.OK, "Menu by id", res);
    }

    public async Task<ApiResponse<List<Menu>>> GetMenus()
    {
        var res = await repository.GetMenus();
        return new ApiResponse<List<Menu>>(HttpStatusCode.OK, "List of Menu", res);
    }

    public async Task<ApiResponse<bool>> UpdateMenu(int id, UpdateMenuDto menu)
    {
        Menu mn = new()
        {
            Id = id,
            MenuDate = menu.MenuDate,
            isactive = menu.isactive,
            CreatedAt = menu.CreatedAt,
            UpdatedAt = menu.UpdatedAt
        };
        var res = await repository.AddMenu(mn);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Company added ! ", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Company not added !");
    }

}
