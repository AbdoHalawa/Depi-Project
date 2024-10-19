using DEPI_Project.Models;

namespace DEPI_Project.Repositories
{
    public interface IStudentRepo
    {
        public async Task<IdentityResult> Add_Student(Student Course, ApplicationUser StudentAccount);
        public void Update_Student(int id, Student student, ApplicationUser StudentAccount);
        public Task Delete_Student(Student student, ApplicationUser StudentAccount);
        public Student Get_StudentByID(int id);
        public ApplicationUser Get_Account(int?id);
        public List<Student> Get_AllStudents();
        public List<Student> Get_AllStudentsByCourseID(int courseID);
        public Task Save();
    }
}
