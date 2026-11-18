using System.Diagnostics.CodeAnalysis;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class CompanyRepository(DataBase dataBase) : ICompanyRepository
{
    private DataBase data = dataBase;
    public async Task<bool> AddCompany(Company company)
    {
        data.Companies.Add(company);
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteCompany(int id)
    {
        var del = await data.Companies.FirstOrDefaultAsync(x => x.Id == id);
        if (del != null)
        {
            data.Companies.Remove(del);
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

    public async Task<List<Company>> GetCompanies()
    {
        return await data.Companies.ToListAsync();
    }

    public async Task<Company> GetCompany(int id)
    {
        var res = await data.Companies.FirstOrDefaultAsync(x => x.Id == id);
        return res??new();
    }

    public async Task<bool> UpdateCompany(Company company)
    {
        var upd = await data.Companies.FirstOrDefaultAsync(x => x.Id == company.Id);
        if(upd != null)
        {
            upd.Name = company.Name;
            upd.Phone = company.Phone;
            upd.Address = company.Address;
            upd.Email = company.Email;
            upd.CreatedAt = company.CreatedAt;
            upd.UpdatedAt = company.UpdatedAt;
        }
        var res = await data.SaveChangesAsync();
        return res > 0;
    }

}
