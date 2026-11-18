using Application.DTOs.CompanyDto;
using Application.Interfaces;
using Application.Response;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]

public class CompanyController(ICompanyService companyService) : ControllerBase
{
    private ICompanyService service = companyService;
    
    [HttpGet]
    public async Task<ApiResponse<List<Company>>> GetCompanies()
    {
        return await service.GetCompanies();
    }
    
    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Company>> GetCompany(int id)
    {
        return await service.GetCompany(id);
    }
    
    [HttpPost]
    public async Task<ApiResponse<bool>> AddCompany(CreateCompanyDto company)
    {
        return await service.AddCompany(company);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteCompany(int id)
    {
        return await service.DeleteCompany(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateCompany(int id, UpdateCompanyDto company)
    {
        return await service.UpdateCompany(id, company);
    }
}
