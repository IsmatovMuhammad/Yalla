using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MenuItemRepository(DataBase dataBase) : IMenuItemRepository
{
    private DataBase data = dataBase;

    public async Task<bool> AddIMenuItem(MenuItem menuItem)
    {
        data.MenuItems.Add(menuItem);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteIMenuItem(int id)
    {
        var del = await data.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
        if (del != null)
        {
            data.MenuItems.Remove(del);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }


    public async Task<MenuItem> GetIMenuItem(int id)
    {
        var res = await data.MenuItems.FirstOrDefaultAsync(x => x.Id == id);
        return res ?? new();
    }

    public async Task<List<MenuItem>> GetIMenuItemR()
    {
        return await data.MenuItems.ToListAsync();
    }


    public async Task<bool> UpdateIMenuItem(MenuItem menuItem)
    {
        var upd = await data.MenuItems.FirstOrDefaultAsync(x => x.Id == menuItem.Id);
        if (upd != null)
        {
            upd.MenuId = menuItem.MenuId;
            upd.Name = menuItem.Name;
            upd.Description = menuItem.Description;
            upd.Price = menuItem.Price;
            upd.Category = menuItem.Category;
            upd.CreatedAt = menuItem.CreatedAt;
            upd.UpdatedAt = menuItem.UpdatedAt;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }
}