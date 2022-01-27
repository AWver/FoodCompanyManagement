using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodCompanyManagement.Server.Data;
using FoodCompanyManagement.Server.Models;
using FoodCompanyManagement.Server.IRepository;

namespace FoodCompanyManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User_DietPlansController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public User_DietPlansController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;

        }

        // GET: api/User_DietPlans
        [HttpGet]
        public async Task<IActionResult> GetUser_DietPlans()
        {
            var user_DietPlans = await _unitOfWork.User_DietPlans.GetAll();
            return Ok(user_DietPlans);
        }

        // GET: api/User_DietPlans/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser_DietPlan(int id)
        {
            var user_DietPlan = await _unitOfWork.User_DietPlans.Get(q => q.Id == id);

            if (user_DietPlan == null)
            {
                return NotFound();
            }

            return Ok(user_DietPlan);
        }

        // PUT: api/User_DietPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser_DietPlan(int id, User_DietPlan user_DietPlan)
        {
            if (id != user_DietPlan.Id)
            {
                return BadRequest();
            }

            _unitOfWork.User_DietPlans.Update(user_DietPlan);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await User_DietPlanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User_DietPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User_DietPlan>> PostUser_DietPlan(User_DietPlan user_DietPlan)
        {
            await _unitOfWork.User_DietPlans.Insert(user_DietPlan);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetUser_DietPlan", new { id = user_DietPlan.Id }, user_DietPlan);
        }

        // DELETE: api/User_DietPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser_DietPlan(int id)
        {
            var user_DietPlan = await _unitOfWork.User_DietPlans.Get(q => q.Id == id);
            if (user_DietPlan == null)
            {
                return NotFound();
            }

            await _unitOfWork.User_DietPlans.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> User_DietPlanExists(int id)
        {
            var user_DietPlan = await _unitOfWork.User_DietPlans.Get(q => q.Id == id);
            return user_DietPlan != null;
        }
    }
}
