using FoodCompanyManagement.Server.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodCompanyManagement.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<DailyMeal> DailyMeals { get; }
        IGenericRepository<DietPlan> DietPlans { get; }
        IGenericRepository<Post> Posts { get; }
        IGenericRepository<ProfileData> ProfileDatas { get; }
        IGenericRepository<Topic> Topics { get; }
        IGenericRepository<User_DietPlan> User_DietPlans { get; }
    }
}