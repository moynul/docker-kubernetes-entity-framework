using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerKubernetesExample.Models
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CoreDbContext _CoreDbContext;

        public StudentRepository(CoreDbContext coreDbContext)
        {
            _CoreDbContext = coreDbContext;
        }

        public async Task Add(Student user)
        {
            try
            {
                await _CoreDbContext.students.AddAsync(user);
                await _CoreDbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Student user)
        {
            try
            {
                _CoreDbContext.students.Update(user);
                await _CoreDbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(int id)
        {
            Student user = await _CoreDbContext.students.FindAsync(id);
            if (user == null)
            {
                //return NotFound();
            }

            _CoreDbContext.students.Remove(user);
            await _CoreDbContext.SaveChangesAsync();

            //return user;
        }
        public async Task<Student> GetStudentByid(int? id)
        {
            try
            {
                return await _CoreDbContext.students.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Student>> GetStudent()
        {
            try
            {
                return _CoreDbContext.students.ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
