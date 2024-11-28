using System.Linq.Expressions;
using JapaneseFoodShop.DTOs;
using JapaneseFoodShop.DTOs.Responses;
using JapaneseFoodShop.Entities;

namespace JapaneseFoodShop.Services.Abstracts
{
    public interface IEmployeeService
    {
        Task<BaseResponse<EmployeeDTO>> CreateAsync(EmployeeDTO dto);
        Task<BaseResponse> UpdateAsync(EmployeeDTO dto);
        Task<BaseResponse> DeleteAsync(EmployeeDTO dto);

        Task<DataListResponse<EmployeeDTO>> CreateMultipleAsync(IEnumerable<EmployeeDTO> employeeDTOs);
        Task<BaseResponse> UpdateMultipleAsync(IEnumerable<EmployeeDTO> employeeDTOs);
        Task<BaseResponse> DeleteMultipleAsync(IEnumerable<EmployeeDTO> employeeDTOs);

        Task<BaseResponse<EmployeeDTO>> GetAsync(Expression<Func<EmployeeDTO, bool>> predicate);
        Task<BaseResponse<EmployeeDTO>> FindByIdAsync(string id);

        Task<DataListResponse<EmployeeDTO>> GetAllAsync(Expression<Func<EmployeeDTO, bool>> predicate = null!);
        Task<PaginingResponse<EmployeeDTO>> GetAllAsync(int pageSize, int PageNum = 1, Expression<Func<EmployeeDTO, bool>> predicate = null!);
    }
}
