using life_copilot_kernel.Services;
using Microsoft.AspNetCore.Mvc;
using life_copilot_kernel.Models;
using Action = life_copilot_kernel.Models.Action;
using life_copilot_kernel.Middleware;

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
        public async Task<Response> GetAllActions()
        {
            try
            {
                var actions = await _actionService.GetAllActions();
                return new Response
                {
                    Status = 200,
                    Success = true,
                    Message = "Action(s) returned successfully",
                    Data = actions
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Status = 500,
                    Success = false,
                    Message = "Error while getting action(s)",
                    Data = ex.Message
                };
            }
            // return actions;
        }

        [HttpGet("GetActionById/{id}")]
        public async Task<Response> GetActionById(Guid id)
        {
            try
            {
                var action = await _actionService.GetActionById(id);
                return new Response
                {
                    Status = 200,
                    Success = true,
                    Message = "Action returned successfully",
                    Data = action
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Status = 500,
                    Success = false,
                    Message = "Error while getting action",
                    Data = ex.Message
                };
            }
            //return action;
        }
        [HttpGet("GetActionsByStatus")]
        public async Task<Response> GetActionsByStatus(bool status)
        {
            try
            {
                var actions = await _actionService.GetActionByStatus(status);
                return new Response
                {
                    Status = 200,
                    Success = true,
                    Message = "Action(s) returned successfully",
                    Data = actions
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Status = 500,
                    Success = false,
                    Message = "Error while getting action(s)",
                    Data = ex.Message
                };
            }
           // return actions;
        }
        [HttpPost]
       
        public async Task<Response> CreateAction(Action newAction)
        {
            try
            {
                var action = await _actionService.PostAction(newAction);
                return new Response
                {
                    Status = 201,
                    Success = true,
                    Message = "Action created successfully",
                    Data = action
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Status = 500,
                    Success = false,
                    Message = "Error while adding action",
                    Data = ex.Message
                };
            }
           // return machine;
        }

        [HttpPatch]
        public async Task<Response> UpdateAction(Action updatedAction)
        {
            try
            {
                var action = await _actionService.UpdateAction(updatedAction);

                return new Response
                {
                    Status = 200,
                    Success = true,
                    Message = "Action updated successfully",
                    Data = action
                };
            }
            catch (Exception ex)
            {

                return new Response
                {
                    Status = 500,
                    Success = false,
                    Message = "Error while updating action",
                    Data = ex.Message
                };
            }
            //return Ok(action);
        }

        [HttpDelete("DeleteActionById/{id}")]
        public async Task<Response> DeleteAction(Guid id)
        {
            try
            {
                var deletedAction = await _actionService.DeleteAction(id);
                return new Response
                {
                    Status = 200,
                    Success = true,
                    Message = "Action deleted successfully",
                    Data = deletedAction
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    Status = 500,
                    Success = false,
                    Message = "Error while deleting action",
                    Data = ex.Message
                };

            }
          //  return Ok(deletedAction);
        }

    }
}