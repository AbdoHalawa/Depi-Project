using DEPI_Project.Models;
using DEPI_Project.View_Models;
using ELearningPlatform.Models;
using Microsoft.AspNetCore.Identity;

namespace ELearning.Repositories
{
    public class InstructorRepo : IinstructorRepo
    {
        private readonly ELearningContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public InstructorRepo(ELearningContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task Add_Instructor(Instructor instructor, ApplicationUser InstructorAccount)
        {
            _context.Instructors.Add(instructor);

            // Create the student account
            var result = await _userManager.CreateAsync(InstructorAccount);
            if (result.Succeeded)
            {
                instructor.ApplicationUser_Id = InstructorAccount.Id;
            }
        }

        public async Task Delete_Instructor(Instructor instructor, ApplicationUser IsntructorAccount)
        {
            // Retrieve the ApplicationUser entity from the database to ensure it's fully loaded
            var InstructorAccountEntity = await _userManager.FindByIdAsync(IsntructorAccount.Id.ToString());
            if (InstructorAccountEntity == null)
            {
                throw new InvalidOperationException("Student account not found.");
            }
            // Delete the user account associated with the student
            var deleteResult = await _userManager.DeleteAsync(InstructorAccountEntity);
            if (!deleteResult.Succeeded)
            {
                throw new InvalidOperationException("Failed to delete the student account.");
            }
            // Remove the student entity from the context
            _context.Instructors.Remove(instructor);
        }

        public ApplicationUser Get_Account(int? id)
        {
            return (from account in _userManager.Users
                    where account.Id == id
                    select account
                   ).FirstOrDefault();
        }

        public List<Instructor> Get_AllInstructors()
        {
            return _context.Instructors.ToList();
        }

        public Instructor Get_InstructorByID(int id)
        {
            return (from instructor in _context.Instructors
                    where instructor.Id == id
                    select instructor).FirstOrDefault();
        }

        public async Task Save()
        {
            _context.SaveChanges();
        }

        public void Update_Instructor(int id, Instructor Instructor, ApplicationUser InstructorAccount)
        {
            Instructor old_Data = _context.Instructors.Where(s => s.Id == id).FirstOrDefault();
            if (old_Data != null)
            {
                old_Data.Name = Instructor.Name;
                old_Data.Street = Instructor.Street;
                old_Data.City = Instructor.City;
                old_Data.Country = Instructor.Country;
            }
            ApplicationUser old_Acount = _context.Users.Where(s => s.Id == old_Data.ApplicationUser_Id).FirstOrDefault();

            if (old_Acount != null)
            {
                old_Acount.Email = InstructorAccount.Email;
                old_Acount.PasswordHash = InstructorAccount.PasswordHash;
                old_Acount.PhoneNumber = InstructorAccount.PhoneNumber;
                old_Acount.UserName = InstructorAccount.UserName;
            }
        }
    }
}
