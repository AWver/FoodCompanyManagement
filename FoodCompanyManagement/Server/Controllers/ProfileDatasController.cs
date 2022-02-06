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
    public class ProfileDatasController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileDatasController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;

        }

        // GET: api/ProfileDatas
        [HttpGet]
        public async Task<IActionResult> GetProfileDatas()
        {
            var profileDatas = await _unitOfWork.ProfileDatas.GetAll();
            return Ok(profileDatas);
        }

        // GET: api/ProfileDatas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfileData(int id)
        {
            var profileData = await _unitOfWork.ProfileDatas.Get(q => q.Id == id);

            if (profileData == null)
            {
                return NotFound();
            }

            return Ok(profileData);
        }

        // PUT: api/ProfileDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfileData(int id, ProfileData profileData)
        {
            if (id != profileData.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ProfileDatas.Update(profileData);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProfileDataExists(id))
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

        // POST: api/ProfileDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProfileData>> PostProfileData(ProfileData profileData)
        {
            await _unitOfWork.ProfileDatas.Insert(profileData);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetProfileData", new { id = profileData.Id }, profileData);
        }

        // DELETE: api/ProfileDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfileData(int id)
        {
            var profileData = await _unitOfWork.ProfileDatas.Get(q => q.Id == id);
            if (profileData == null)
            {
                return NotFound();
            }

            await _unitOfWork.ProfileDatas.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> ProfileDataExists(int id)
        {
            var profileData = await _unitOfWork.ProfileDatas.Get(q => q.Id == id);
            return profileData != null;
        }
    }
}
