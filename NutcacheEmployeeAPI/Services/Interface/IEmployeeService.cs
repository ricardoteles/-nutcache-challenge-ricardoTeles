using NutcacheEmployeeAPI.Models;

namespace NutcacheEmployeeAPI.Services.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> Get(int id);
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<Employee> Delete(int id);
    }
}
