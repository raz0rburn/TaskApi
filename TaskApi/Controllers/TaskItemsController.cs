using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApi.Models;
using TaskApi.Helpers;
namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly dbContext _context;

        public TaskItemsController(dbContext context)
        {
            _context = context;
        }

        // GET: api/TaskItems
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems()
        {
            return await _context.TaskItems
                .ToListAsync();
        }
        // GET: api/TaskItems
        [HttpGet("deleted")]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetDeletedTaskItems()
        {
            return await _context.TaskItems.Where(p => p.IsDeleted.Equals(IsDeleted.Yes)).ToListAsync(); ;
            //return await _context.TaskItems

        }
        // GET: api/TaskItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(long id)
        {


            var taskItem = await _context.TaskItems.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return taskItem;
        }
        // GET: api/TaskItems/5
        [HttpGet("deleted/{id}")]
        public async Task<ActionResult<TaskItem>> GetDeletedTaskItem(long id)
        {


            var taskItem = await _context.TaskItems.FindAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }
            if (taskItem.IsDeleted.Equals(IsDeleted.Yes))
                return taskItem;
            else
                return NotFound();
        }
        // PUT: api/TaskItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(long id, TaskItemDTO taskItemDTO)
        {
            string varCompletionDate;




            if (id != taskItemDTO.Id)
            {
                return BadRequest();
            }



            //Запись даты если статус "Completed"

            if (taskItemDTO.Status == Status.Completed)
            {
                varCompletionDate = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
                varCompletionDate = "";



            var taskItem = new TaskItem
            {
                Id = taskItemDTO.Id,
                Name = taskItemDTO.Name,
                DueDate = taskItemDTO.DueDate,
                CreationDate = taskItemDTO.CreationDate,
                Status = taskItemDTO.Status,
                CompletionDate = varCompletionDate
            };



            _context.Entry(taskItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskItemExists(id))
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

        // POST: api/TaskItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TaskItemDTO>> CreateTaskItem(TaskItemDTO taskItemDTO)
        {

            var taskItem = new TaskItem
            {
                Id = taskItemDTO.Id,
                Name = taskItemDTO.Name,
                DueDate = taskItemDTO.DueDate,
                CreationDate = taskItemDTO.CreationDate,
                Status = taskItemDTO.Status
            };

            _context.TaskItems.Add(taskItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTaskItem),
                new { id = taskItem.Id },
                ItemToDTO(taskItem));
        }

        // POST: api/TaskItems/deleted/5
        [HttpPost("deleted/{id}")]
        public async Task<ActionResult<TaskItemDTO>> RestoreTaskItem(long id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            if ((taskItem.IsDeleted.Equals(IsDeleted.Yes)))
            {

                taskItem.IsDeleted = IsDeleted.No;

            }



            await _context.SaveChangesAsync();
            
            return CreatedAtAction(
                nameof(GetTaskItem),
                new { id = taskItem.Id },
                taskItem);
        }

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskItem>> SoftDeleteTaskItem(long id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            
            if ((taskItem.IsDeleted == IsDeleted.No))
                taskItem.IsDeleted = IsDeleted.Yes;
            
            //_context.TaskItems.Remove(taskItem);
            await _context.SaveChangesAsync();

            return taskItem;
        }

        // DELETE: api/TaskItems/deleted/5
        [HttpDelete("deleted/{id}")]
        public async Task<ActionResult<TaskItem>> DeleteTaskItem(long id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            if ((taskItem.IsDeleted.Equals(IsDeleted.Yes)))
            {
                
                _context.TaskItems.Remove(taskItem);
                
            }

            await _context.SaveChangesAsync();




            return taskItem;
           
        }


        private bool TaskItemExists(long id) =>
            _context.TaskItems.Any(e => e.Id == id);

        private static TaskItemDTO ItemToDTO(TaskItem taskItem) =>
            new TaskItemDTO
            {
                Id = taskItem.Id,
                Name = taskItem.Name,
                DueDate = taskItem.DueDate,
                CreationDate = taskItem.CreationDate,
                Status = taskItem.Status,
               
            };
    }
}
