using Application.DTOs.CompanyDto;
using Application.Response;
using Domain.Models;

namespace Application.Interfaces;

public interface ICompanyService
{
    Task<ApiResponse<bool>> AddCompany(CreateCompanyDto company);
    Task<ApiResponse<bool>> DeleteCompany(int id);
    Task<ApiResponse<bool>> UpdateCompany(int id, UpdateCompanyDto company);
    Task<ApiResponse<Company>> GetCompany(int id);
    Task<ApiResponse<List<Company>>> GetCompanies();
}
