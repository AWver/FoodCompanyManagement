using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FoodCompanyManagement.Server.Data;
using FoodCompanyManagement.Shared.Domain;
using FoodCompanyManagement.Server.IRepository;

namespace FoodCompanyManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietPlansController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public DietPlansController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;

        }

        // GET: api/DietPlans
        [HttpGet]
        public async Task<IActionResult> GetDietPlans()
        {
            var dietPlans = await _unitOfWork.DietPlans.GetAll();
            return Ok(dietPlans);
        }

        // GET: api/DietPlans/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDietPlan(int id)
        {
            var dietPlan = await _unitOfWork.DietPlans.Get(q => q.Id == id);

            if (dietPlan == null)
            {
                return NotFound();
            }

            return Ok(dietPlan);
        }

        // PUT: api/DietPlans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDietPlan(int id, DietPlan dietPlan)
        {
            if (id != dietPlan.Id)
            {
                return BadRequest();
            }

            _unitOfWork.DietPlans.Update(dietPlan);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await DietPlanExists(id))
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

        // POST: api/DietPlans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DietPlan>> PostDietPlan(DietPlan dietPlan)
        {
            await _unitOfWork.DietPlans.Insert(dietPlan);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetDietPlan", new { id = dietPlan.Id }, dietPlan);
        }

        // DELETE: api/DietPlans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDietPlan(int id)
        {
            var dietPlan = await _unitOfWork.DietPlans.Get(q => q.Id == id);
            if (dietPlan == null)
            {
                return NotFound();
            }

            await _unitOfWork.DietPlans.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> DietPlanExists(int id)
        {
            var dietPlan = await _unitOfWork.DietPlans.Get(q => q.Id == id);
            return dietPlan != null;
        }
    }
}
