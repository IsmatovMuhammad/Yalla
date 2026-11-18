using System.Net;
using Application.DTOs.CompanyDto;
using Application.Interfaces;
using Application.Response;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Service;

public class CompanyService(ICompanyRepository companyRepository) : ICompanyService
{
    private ICompanyRepository repository = companyRepository;
    public async Task<ApiResponse<bool>> AddCompany(CreateCompanyDto company)
    {
        Company cm = new()
        {
            Name = company.Name,
            Phone = company.Phone,
            Address = company.Address,
            Email = company.Email,
            CreatedAt = company.CreatedAt,
            UpdatedAt = company.UpdatedAt
        };
        var res = await repository.AddCompany(cm);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Company added ! ", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Company not added ! ");
    }

    public async Task<ApiResponse<bool>> DeleteCompany(int id)
    {
        var res = await repository.DeleteCompany(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Company deleted !", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Company not deleted !");
    }

    public async Task<ApiResponse<List<Company>>> GetCompanies()
    {
        var res = await repository.GetCompanies();
        return new ApiResponse<List<Company>>(HttpStatusCode.OK, "List of Company", res);
    }

    public async Task<ApiResponse<Company>> GetCompany(int id)
    {
        var res = await repository.GetCompany(id);
        return new ApiResponse<Company>(HttpStatusCode.OK, "Company by id", res);
    }

    public async Task<ApiResponse<bool>> UpdateCompany(int id, UpdateCompanyDto company)
    {
        Company cm = new()
        {
            Id = id,
            Name = company.Name,
            Phone = company.Phone,
            Address = company.Address,
            Email = company.Email,
            CreatedAt = company.CreatedAt,
            UpdatedAt = company.UpdatedAt
        };
        var res = await repository.UpdateCompany(cm);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Company updated ! ", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Company not updated ! ");
    }
}
