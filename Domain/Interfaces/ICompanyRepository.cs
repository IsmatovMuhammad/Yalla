using Domain.Models;

namespace Domain.Interfaces;

public interface ICompanyRepository
{
    Task<bool> AddCompany(Company company);
    Task<bool> DeleteCompany(int id);
    Task<bool> UpdateCompany(Company company);
    Task<Company> GetCompany(int id);
    Task<List<Company>> GetCompanies();
}
