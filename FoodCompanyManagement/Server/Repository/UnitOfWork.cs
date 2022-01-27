using FoodCompanyManagement.Server.Data;
using FoodCompanyManagement.Server.IRepository;
using FoodCompanyManagement.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FoodCompanyManagement.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<DailyMeal> _dailyMeals;
        private IGenericRepository<DietPlan> _dietPlans;
        private IGenericRepository<Post> _posts;
        private IGenericRepository<Topic> _topics;
        private IGenericRepository<User_DietPlan> _user_dietPlans;
        private IGenericRepository<ProfileData> _profileDatas;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<DailyMeal> DailyMeals
            => _dailyMeals ??= new GenericRepository<DailyMeal>(_context);
        public IGenericRepository<DietPlan> DietPlans
            => _dietPlans ??= new GenericRepository<DietPlan>(_context);
        public IGenericRepository<Post> Posts
            => _posts ??= new GenericRepository<Post>(_context);
        public IGenericRepository<Topic> Topics
            => _topics ??= new GenericRepository<Topic>(_context);
        public IGenericRepository<User_DietPlan> User_DietPlans
            => _user_dietPlans ??= new GenericRepository<User_DietPlan>(_context);
        public IGenericRepository<ProfileData> ProfileDatas
            => _profileDatas ??= new GenericRepository<ProfileData>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            //string user = "System";

            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user.UserName;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user.UserName;
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}