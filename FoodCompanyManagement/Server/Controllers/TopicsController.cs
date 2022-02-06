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
    public class TopicsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public TopicsController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;

        }

        // GET: api/Topics
        [HttpGet]
        public async Task<IActionResult> GetTopics()
        {
            var topics = await _unitOfWork.Topics.GetAll();
            return Ok(topics);
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopic(int id)
        {
            var topic = await _unitOfWork.Topics.Get(q => q.Id == id);

            if (topic == null)
            {
                return NotFound();
            }

            return Ok(topic);
        }

        // PUT: api/Topics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(int id, Topic topic)
        {
            if (id != topic.Id)
            {
                return BadRequest();
            }

            _unitOfWork.Topics.Update(topic);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TopicExists(id))
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

        // POST: api/Topics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Topic>> PostTopic(Topic topic)
        {
            await _unitOfWork.Topics.Insert(topic);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTopic", new { id = topic.Id }, topic);
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topic = await _unitOfWork.Topics.Get(q => q.Id == id);
            if (topic == null)
            {
                return NotFound();
            }

            await _unitOfWork.Topics.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> TopicExists(int id)
        {
            var topic = await _unitOfWork.Topics.Get(q => q.Id == id);
            return topic != null;
        }
    }
}
