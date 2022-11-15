using NutcacheEmployeeAPI.Models;
using NutcacheEmployeeAPI.Repositories.Interface;
using NutcacheEmployeeAPI.Services.Interface;

namespace NutcacheEmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Employee> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<Employee> Add(Employee employee)
        {
            return await _repository.Add(employee);
        }

        public async Task<Employee> Update(Employee employee)
        {
            return await _repository.Update(employee);
        }

        public async Task<Employee> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
