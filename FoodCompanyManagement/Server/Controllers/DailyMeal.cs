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
    public class DailyMealsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public DailyMealsController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;

        }

        // GET: api/DailyMeals
        [HttpGet]
        public async Task<IActionResult> GetDailyMeals()
        {
            var dailyMeals = await _unitOfWork.DailyMeals.GetAll();
            return Ok(dailyMeals);
        }

        // GET: api/DailyMeals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDailyMeal(int id)
        {
            var dailyMeal = await _unitOfWork.DailyMeals.Get(q => q.Id == id);

            if (dailyMeal == null)
            {
                return NotFound();
            }

            return Ok(dailyMeal);
        }

        // PUT: api/DailyMeals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyMeal(int id, DailyMeal dailyMeal)
        {
            if (id != dailyMeal.Id)
            {
                return BadRequest();
            }

            _unitOfWork.DailyMeals.Update(dailyMeal);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DailyMealExists(id))
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

        // POST: api/DailyMeals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DailyMeal>> PostDailyMeal(DailyMeal dailyMeal)
        {
            await _unitOfWork.DailyMeals.Insert(dailyMeal);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetDailyMeal", new { id = dailyMeal.Id }, dailyMeal);
        }

        // DELETE: api/DailyMeals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyMeal(int id)
        {
            var dailyMeal = await _unitOfWork.DailyMeals.Get(q => q.Id == id);
            if (dailyMeal == null)
            {
                return NotFound();
            }

            await _unitOfWork.DailyMeals.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> DailyMealExists(int id)
        {
            var dailyMeal = await _unitOfWork.DailyMeals.Get(q => q.Id == id);
            return dailyMeal != null;
        }
    }
}
