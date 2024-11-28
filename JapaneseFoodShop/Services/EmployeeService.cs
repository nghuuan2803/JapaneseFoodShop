using System.Linq.Expressions;
using AutoMapper;
using JapaneseFoodShop.DTOs;
using JapaneseFoodShop.DTOs.Responses;
using JapaneseFoodShop.Entities;
using JapaneseFoodShop.Repositories.Abstracts;
using JapaneseFoodShop.Services.Abstracts;

namespace JapaneseFoodShop.Services
{
    public class EmployeeService(IUnitOfWork _uow, IEmployeeRepos _employeeRepos, IMapper _mapper) : IEmployeeService
    {
        public async Task<BaseResponse<EmployeeDTO>> CreateAsync(EmployeeDTO dto)
        {
            try
            {
                dto.CreatedAt = DateTime.Now;
                var entity = _mapper.Map<Employee>(dto);
                await _employeeRepos.CreateAsync(entity);
                dto = _mapper.Map<EmployeeDTO>(entity);
                return new BaseResponse<EmployeeDTO>(data: dto);
            }
            catch (Exception e)
            {
                return new BaseResponse<EmployeeDTO>(false, null!, e.StackTrace);
            }
        }

        public async Task<DataListResponse<EmployeeDTO>> CreateMultipleAsync(IEnumerable<EmployeeDTO> employeeDTOs)
        {
            foreach (var dto in employeeDTOs)
            {
                dto.CreatedAt = DateTime.Now;
            }

            await _uow.BeginAsync();
            try
            {
                var enities = _mapper.Map<List<Employee>>(employeeDTOs);
                await _employeeRepos.CreateMultipleAsync(enities);
                await _uow.CommitAsync();
                var result = _mapper.Map<List<EmployeeDTO>>(enities);
                return new DataListResponse<EmployeeDTO>(data: result);
            }
            catch (Exception e)
            {
                await _uow.RollBackAsync();
                return new DataListResponse<EmployeeDTO>(false, null!, e.StackTrace);
            }
        }

        public async Task<BaseResponse> UpdateAsync(EmployeeDTO dto)
        {
            dto.LastUpdatedAt = DateTime.Now;
            try
            {
                var entity = _mapper.Map<Employee>(dto);
                await _employeeRepos.UpdateAsync(entity);
                return new BaseResponse();
            }
            catch (Exception e)
            {
                return new BaseResponse(false, e.StackTrace);
            }
        }

        public async Task<BaseResponse> UpdateMultipleAsync(IEnumerable<EmployeeDTO> employeeDTOs)
        {
            foreach (var dto in employeeDTOs)
            {
                dto.LastUpdatedAt = DateTime.Now;
            }
            await _uow.BeginAsync();
            try
            {
                var enities = _mapper.Map<List<Employee>>(employeeDTOs);
                await _employeeRepos.UpdateMultipleAsync(enities);
                await _uow.CommitAsync();
                return new BaseResponse();
            }
            catch (Exception e)
            {
                await _uow.RollBackAsync();
                return new BaseResponse(false, e.StackTrace);
            }
        }
        public async Task<BaseResponse> DeleteAsync(EmployeeDTO dto)
        {
            try
            {
                var entity = _mapper.Map<Employee>(dto);
                await _employeeRepos.DeleteAsync(entity);
                return new BaseResponse();
            }
            catch (Exception e)
            {
                return new BaseResponse(false, e.StackTrace);
            }
        }

        public async Task<BaseResponse> DeleteMultipleAsync(IEnumerable<EmployeeDTO> employeeDTOs)
        {
            await _uow.BeginAsync();
            try
            {
                var enities = _mapper.Map<List<Employee>>(employeeDTOs);
                await _employeeRepos.DeleteMultipleAsync(enities);
                await _uow.CommitAsync();
                return new BaseResponse();
            }
            catch (Exception e)
            {
                await _uow.RollBackAsync();
                return new BaseResponse(false, e.StackTrace);
            }
        }

        public async Task<BaseResponse<EmployeeDTO>> FindByIdAsync(string id)
        {
            try
            {
                var data = await _employeeRepos.FindByIdAsync(id);
                return new BaseResponse<EmployeeDTO>(data: _mapper.Map<EmployeeDTO>(data));
            }
            catch (KeyNotFoundException e)
            {
                return new BaseResponse<EmployeeDTO>(false, null!, e.Message);
            }
            catch (Exception e)
            {
                return new BaseResponse<EmployeeDTO>(false, null!, e.StackTrace);
            }
        }

        public async Task<BaseResponse<EmployeeDTO>> GetAsync(Expression<Func<EmployeeDTO, bool>> predicate)
        {
            try
            {
                Expression<Func<Employee, bool>> entityPredicate = predicate != null
               ? ConvertPredicate(predicate)
               : null;
                var data = await _employeeRepos.GetAsync(entityPredicate);
                return new BaseResponse<EmployeeDTO>(data: _mapper.Map<EmployeeDTO>(data));
            }
            catch (KeyNotFoundException e)
            {
                return new BaseResponse<EmployeeDTO>(false, null!, e.Message);
            }
            catch (Exception e)
            {
                return new BaseResponse<EmployeeDTO>(false, null!, e.StackTrace);
            }
        }

        public async Task<DataListResponse<EmployeeDTO>> GetAllAsync(Expression<Func<EmployeeDTO, bool>> predicate = null!)
        {
            try
            {
                Expression<Func<Employee, bool>> entityPredicate = predicate != null
                  ? ConvertPredicate(predicate)
                  : null;
                var data = await _employeeRepos.GetAllAsync(entityPredicate);
                var dtos = _mapper.Map<List<EmployeeDTO>>(data);
                return new DataListResponse<EmployeeDTO>(data: dtos);
            }
            catch (KeyNotFoundException e)
            {
                return new DataListResponse<EmployeeDTO>(false, null!, e.Message);
            }
            catch (Exception e)
            {
                return new DataListResponse<EmployeeDTO>(false, null!, e.StackTrace);
            }
        }

        public async Task<PaginingResponse<EmployeeDTO>> GetAllAsync(int pageSize, int pageNum = 1, Expression<Func<EmployeeDTO, bool>> predicate = null!)
        {
            try
            {
                Expression<Func<Employee, bool>> entityPredicate = predicate != null
                ? ConvertPredicate(predicate)
                : null;

                var data = await _employeeRepos.GetAllAsync(pageSize, pageNum, entityPredicate); //lỗi ở dòng này do khác kiểu dữ liệu: Employee và EmployeeDTO
                var dtos = _mapper.Map<List<EmployeeDTO>>(data.Data);
                return new PaginingResponse<EmployeeDTO>(data: dtos, data.TotalItems, data.TotalPages, true, null);
            }
            catch (KeyNotFoundException e)
            {
                return new PaginingResponse<EmployeeDTO>(data: null, 0, 0, false, e.Message);
            }
            catch (Exception e)
            {
                return new PaginingResponse<EmployeeDTO>(data: null, 0, 0, false, e.StackTrace);
            }
        }

        private static Expression<Func<Employee, bool>> ConvertPredicate(Expression<Func<EmployeeDTO, bool>> predicate)
        {
            var parameter = Expression.Parameter(typeof(Employee), "e");
            var body = new ExpressionReplacer(predicate.Parameters[0], parameter).Visit(predicate.Body);
            return Expression.Lambda<Func<Employee, bool>>(body, parameter);
        }


        private class ExpressionReplacer : ExpressionVisitor
        {
            private readonly ParameterExpression _source;
            private readonly ParameterExpression _target;

            public ExpressionReplacer(ParameterExpression source, ParameterExpression target)
            {
                _source = source;
                _target = target;
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                if (node.Expression == _source)
                {
                    // Ánh xạ thuộc tính từ DTO sang Entity
                    var targetProperty = typeof(Employee).GetProperty(node.Member.Name);
                    if (targetProperty == null)
                        throw new ArgumentException($"Property '{node.Member.Name}' is not defined for type '{typeof(Employee)}'");

                    return Expression.Property(_target, targetProperty);
                }
                return base.VisitMember(node);
            }
        }
    }
    
}
