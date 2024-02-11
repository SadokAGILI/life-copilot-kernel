using life_copilot_kernel.Services;
using Microsoft.AspNetCore.Mvc;
using life_copilot_kernel.Models;
using Action = life_copilot_kernel.Models.Action;

namespace life_copilot_kernel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionController : ControllerBase
    {
        private readonly IActionService _actionService;
        private readonly ILogger<ActionController> _logger;
        public ActionController(IActionService actionService, ILogger<ActionController> logger)
        {
            _actionService = actionService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<List<Action>>> GetAllActions()
        {
            var actions = await _actionService.GetAllActions();
            return actions;
        }

        [HttpGet("GetActionById/{id}")]
        public async Task<Action> GetActionById(Guid id)
        {
            var action = await _actionService.GetActionById(id);
            return action;
        }
        [HttpGet("GetActionsByStatus")]
        public async Task<ActionResult<List<Action>>> GetActionsByStatus(bool status)
        {
            var actions = await _actionService.GetActionByStatus(status);
            return actions;
        }
        [HttpPost]
       
        public async Task<Action> CreateAction(Action newAction)
        {
            var machine = await _actionService.PostAction(newAction);
            return machine;
        }

        [HttpPatch]
        public async Task<ActionResult<Action>> UpdateAction(Action updatedAction)
        {
            var action = await _actionService.UpdateAction(updatedAction);
            return Ok(action);
        }

        [HttpDelete]
        public async Task<ActionResult<Action>> DeleteAction(Action action)
        {
            var deletedAction = await _actionService.DeleteAction(action);
            return Ok(deletedAction);
        }

    }
}