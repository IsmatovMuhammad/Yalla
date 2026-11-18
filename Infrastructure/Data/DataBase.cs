using System.Data.Common;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Data;

public class DataBase(DbContextOptions<DataBase>options) : DbContext(options)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
}
