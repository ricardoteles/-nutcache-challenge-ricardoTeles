using Microsoft.EntityFrameworkCore;
using NutcacheEmployeeAPI.Models;
using NutcacheEmployeeAPI.Repositories.Interface;

namespace NutcacheEmployeeAPI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DbContext _context;

        public EmployeeRepository(DbContext context)
        {
            this._context = context;
        }

        public async Task<List<Employee>> GetAll()
        {
            return await _context.Set<Employee>().ToListAsync();
        }

        public async Task<Employee> Get(int id)
        {
            return await _context.Set<Employee>().FindAsync(id);
        }

        public async Task<Employee> Add(Employee employee)
        {
            _context.Set<Employee>().Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Update(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Delete(int id)
        {
            var employee = await _context.Set<Employee>().FindAsync(id);
            if (employee == null)
            {
                return employee;
            }

            _context.Set<Employee>().Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
