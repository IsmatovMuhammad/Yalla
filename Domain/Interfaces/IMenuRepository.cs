using Domain.Models;

namespace Domain.Interfaces;

public interface IMenuRepository
{
    Task<bool> AddMenu(Menu menu);
    Task<bool> DeleteMenu(int id);
    Task<bool> UpdateMenu(Menu menu);
    Task<Menu> GetMenu(int id);
    Task<List<Menu>> GetMenus();
}
