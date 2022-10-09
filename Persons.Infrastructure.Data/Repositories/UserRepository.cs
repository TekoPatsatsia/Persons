using Microsoft.EntityFrameworkCore;
using Persons.Models;
using Persons.Core.Entities;
using Persons.Core.Utility;

namespace Persons.Infrastructure.Data.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<List<UserGetModel>> GetUsersAsync()
        {
            var users = await (from user in _db.User
                               select new UserGetModel
                               {
                                   Firstname = user.Firstname,
                                   Lastname = user.Lastname,
                                   IdNumber = user.IdNumber,
                                   BirthDate = user.BirthDate,
                                   Salary = user.Salary,
                                   BirthCertificateId = user.BirthCertificateId,
                                   Address = user.Address,
                                   IsDeleted = user.IsDeleted,
                               }).ToListAsync();

            foreach (var user in users)
            {
                var age = AgeCalculator.CalculateAge(user.BirthDate);
                user.Age = age;
                user.AverageSalary = CalculateAverageSalary(age);
            }

            return users;
        }

        public async Task CreateUserAsync(UserPutModel userModel)
        {
            User user = new()
            {
                Firstname = userModel.Firstname,
                Lastname = userModel.Lastname,
                Salary = userModel.Salary,
                IdNumber = userModel.IdNumber,
                BirthDate = userModel.BirthDate,
                BirthCertificateId = userModel.BirthCertificateId,
                Address = userModel.Address,
                IsDeleted = false,
            };
            await _db.AddAsync(user);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateUser(int id, UserPutModel model)
        {
            var user = await _db.User.SingleOrDefaultAsync(x => x.Id == id) ?? throw new NullReferenceException("does not exists");
            user.Firstname = model.Firstname;

        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _db.User.SingleOrDefaultAsync(x => x.Id == id) ?? throw new NullReferenceException("does not exists");
            user.IsDeleted = true;
            await _db.SaveChangesAsync();
        }

        public double CalculateAverageSalary(int age)
        {
            double averageSalary = 0;

            if (age >= 16 & age <= 18)
            {
                return AverageSalary(16, 18);
            }
            if (age >= 19 & age <= 25)
            {
                return AverageSalary(19, 25);
            }
            if (age >= 26 & age <= 45)
            {
                return AverageSalary(26, 45);
            }
            if (age >= 46)
            {
                return AverageSalary(46);
            }
            return averageSalary;
        }

        public double AverageSalary(int start, int end = 100)
        {
            double sumSalary = 0;
            var startDate = DateTime.Now.AddYears(-start);
            var endDate = DateTime.Now.AddYears(-end);

            var salaries = (from user in _db.User
                where user.BirthDate >= endDate && user.BirthDate <= startDate
                select user.Salary).ToList();

            sumSalary = salaries.Sum();
            var averageSalary = sumSalary / salaries.Count;
            return averageSalary;

        }
    }
}
