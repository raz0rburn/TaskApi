using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

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

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTaskItems()
        {
            return await _context.TaskItems
                .ToListAsync();
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

            if (taskItemDTO.Status == "Completed")
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
        public async Task<ActionResult<TaskItemDTO>> CreateTodoItem(TaskItemDTO taskItemDTO)
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

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaskItem>> DeleteTaskItem(long id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            _context.TaskItems.Remove(taskItem);
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
                Status = taskItem.Status
            };
    }
}
