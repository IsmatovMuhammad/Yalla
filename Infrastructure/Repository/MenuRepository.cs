using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MenuRepository(DataBase dataBase) : IMenuRepository
{
    private DataBase data = dataBase;

    public async Task<bool> AddMenu(Menu menu)
    {
        data.Menus.Add(menu);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteMenu(int id)
    {
        var del = await data.Menus.FirstOrDefaultAsync(x => x.Id == id);
        if (del != null)
        {
            data.Menus.Remove(del);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Menu> GetMenu(int id)
    {
        var res = await data.Menus.FirstOrDefaultAsync(x => x.Id == id);
        return res ?? new();
    }

    public async Task<List<Menu>> GetMenus()
    {
        return await data.Menus.ToListAsync();
    }

    public async Task<bool> UpdateMenu(Menu menu)
    {
        var upd = await data.Menus.FirstOrDefaultAsync(x => x.Id == menu.Id);
        if (upd != null)
        {
            upd.MenuDate = menu.MenuDate;
            upd.isactive = menu.isactive;
            upd.CreatedAt = menu.CreatedAt;
            upd.UpdatedAt = menu.UpdatedAt;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }
}