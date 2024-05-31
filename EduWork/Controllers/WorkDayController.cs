using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EduWork.Data;
using EduWork.Entities;

namespace EduWork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkDaysController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkDaysController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WorkDays
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetWorkDays()
        {
            var workDays = await _context.WorkDays
                .Select(wd => new
                {
                    wd.WorkDayId,
                    wd.Date,
                    wd.SetTime,
                    wd.Endtime,
                    wd.BreakTime,
                    wd.ScheduledTime,
                    wd.ActualTime
                    // Add other properties as needed
                })
                .ToListAsync();

            return Ok(workDays);
        }

        // GET: api/WorkDays/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkDay(Guid id)
        {
            var workDay = await _context.WorkDays
                .Where(wd => wd.WorkDayId == id)
                .Select(wd => new
                {
                    wd.WorkDayId,
                    wd.Date,
                    wd.SetTime,
                    wd.Endtime,
                    wd.BreakTime,
                    wd.ScheduledTime,
                    wd.ActualTime
                    // Add other properties as needed
                })
                .FirstOrDefaultAsync();

            if (workDay == null)
            {
                return NotFound();
            }

            return Ok(workDay);
        }

        // PUT: api/WorkDays/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkDay(Guid id, WorkDay workDay)
        {
            if (id != workDay.WorkDayId)
            {
                return BadRequest();
            }

            _context.Entry(workDay).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkDayExists(id))
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

        // POST: api/WorkDays
        [HttpPost]
        public async Task<ActionResult<WorkDay>> PostWorkDay(WorkDay workDay)
        {
            _context.WorkDays.Add(workDay);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWorkDay), new { id = workDay.WorkDayId }, workDay);
        }

        // DELETE: api/WorkDays/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkDay(Guid id)
        {
            var workDay = await _context.WorkDays.FindAsync(id);
            if (workDay == null)
            {
                return NotFound();
            }

            _context.WorkDays.Remove(workDay);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkDayExists(Guid id)
        {
            return _context.WorkDays.Any(e => e.WorkDayId == id);
        }
    }
}