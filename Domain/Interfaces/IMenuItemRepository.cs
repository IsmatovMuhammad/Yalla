using Domain.Models;

namespace Domain.Interfaces;

public interface IMenuItemRepository
{
    Task<bool> AddIMenuItem(MenuItem menuItem);
    Task<bool> DeleteIMenuItem(int id);
    Task<bool> UpdateIMenuItem(MenuItem menuItem);
    Task<MenuItem> GetIMenuItem(int id);
    Task<List<MenuItem>> GetIMenuItemR();
}
