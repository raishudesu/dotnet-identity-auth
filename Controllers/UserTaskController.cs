using Microsoft.AspNetCore.Mvc;
using dotnet_authentication.Models;
using dotnet_authentication.Services;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("[controller]")]
public class UserTaskController : ControllerBase
{
    private readonly UserTaskService _userTaskService;

    public UserTaskController(UserTaskService userTaskService)
    {
        _userTaskService = userTaskService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<UserTask>>> GetAll()
    {
        var userTasks = await _userTaskService.GetUserTasks();
        return Ok(userTasks);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<UserTask>> GetById(Guid id)
    {
        var userTask = await _userTaskService.GetUserTaskById(id);
        return userTask != null ? Ok(userTask) : NotFound();
    }

    // [HttpPost]
    // public async Task<ActionResult<UserTask>> Create(UserTask userTask)
    // {
    //     var createdUserTask = await _userTaskService.CreateUserTask(userTask);
    //     return CreatedAtAction(nameof(GetById), new { id = createdUserTask.Id }, createdUserTask);
    // }

    [HttpPost] // WITH ERROR HANDLING
    public async Task<ActionResult<UserTask>> Create(UserTask userTask)
    {
        try
        {
            var createdTask = await _userTaskService.CreateUserTask(userTask);
            return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ApplicationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, UserTask userTask)
    {
        if (id != userTask.Id) return BadRequest();
        await _userTaskService.UpdateUserTask(userTask);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userTaskService.DeleteUserTask(id);
        return NoContent();
    }
}