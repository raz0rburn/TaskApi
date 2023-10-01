using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApi.Models;
using TaskApi.Helpers;
//added


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
            return await _context.TaskItems.Where(p => p.IsDeleted.Equals(IsDeleted.No)).ToListAsync();
        }
        // GET: api/TaskItems
        [Authorize]
        [HttpGet("deleted")]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetDeletedTaskItems()
        {
            return await _context.TaskItems.Where(p => p.IsDeleted.Equals(IsDeleted.Yes)).ToListAsync(); ;
            //return await _context.TaskItems

        }
        // GET: api/TaskItems/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTaskItem(long id)
        {


            var taskItem = await _context.TaskItems.FindAsync(id);

            if (taskItem == null || taskItem.IsDeleted == IsDeleted.Yes)
            {
                return NotFound();
            }

            return taskItem;
        }
        // GET: api/TaskItems/5
        [Authorize]
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
        [Authorize]
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
                Description = taskItemDTO.Description,
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

            return CreatedAtAction(
                nameof(GetTaskItem),
                new { id = taskItem.Id },
                ItemToDTO(taskItem));
            //return NoContent();
        }

        // POST: api/TaskItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<TaskItemDTO>> CreateTaskItem(TaskItemDTO taskItemDTO)
        {
            string varCompletionDate;


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
                Description = taskItemDTO.Description,
                DueDate = taskItemDTO.DueDate,
                CreationDate = taskItemDTO.CreationDate,
                CompletionDate = varCompletionDate,
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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




            return CreatedAtAction(
            nameof(GetTaskItem),
            new { id = taskItem.Id },
            taskItem);

        }


        private bool TaskItemExists(long id) =>
            _context.TaskItems.Any(e => e.Id == id);

        private static TaskItemDTO ItemToDTO(TaskItem taskItem) =>
            new TaskItemDTO
            {
                Id = taskItem.Id,
                Name = taskItem.Name,
                Description = taskItem.Description,
                DueDate = taskItem.DueDate,
                CreationDate = taskItem.CreationDate,
                Status = taskItem.Status,
               
            };
    }
}
