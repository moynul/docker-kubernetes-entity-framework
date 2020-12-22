using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerKubernetesExample.Models
{
    public interface IStudentRepository
    {
        Task Add(Student student);
        Task Update(Student student);
        Task Delete(int id);
        //Task<User> GetUser(string id);
        Task<Student> GetStudentByid(int? id);
        Task<IEnumerable<Student>> GetStudent();
    }
}
