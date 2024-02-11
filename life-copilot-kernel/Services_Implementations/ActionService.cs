using life_copilot_kernel.Repositories;
using life_copilot_kernel.Services;
using life_copilot_kernel.Models;
using Action = life_copilot_kernel.Models.Action;
using life_copilot_kernel.Data;
using Microsoft.EntityFrameworkCore;

namespace life_copilot_kernel.Services_Implementations
{
    public class ActionService : IActionService
    {
        private readonly IActionRepository _actionRepository;
        private readonly ILogger<ActionService> _logger;
        private readonly DBContext _context;

        public ActionService(IActionRepository actionRepository, ILogger<ActionService> logger, DBContext Context)
        {
            _actionRepository = actionRepository;
            _logger = logger;
            _context = Context;
        }
       


        public async Task<Action> DeleteAction(Action action)
        {
            var actions = await _actionRepository.DeleteAction(action);
            return actions;
        }

        public async Task<Action> GetActionById(Guid? id)
        {
            var actions = await _actionRepository.GetActionById(id);
            return actions;
        }

        public async Task<List<Action>> GetActionByStatus(bool status)
        {
            var actions = await _actionRepository.GetActionByStatus(status);
            return actions;
        }

        public async Task<List<Action>> GetAllActions()
        {
            var actions = await _actionRepository.GetAllActions();
            return actions;
        }

        public async Task<Action> PostAction(Action newAction)
        {
            var action = await _actionRepository.GetActionById(newAction.Action_Id);
            if (action == null)
            {
                var actions = await _actionRepository.PostAction(newAction);
                return actions;
            }
            else
            {
                throw new Exception("action already exists!");
            }
           
        }

        public async Task<Action> UpdateAction(Action updatedAction)
        {
            var action = await _actionRepository.GetActionById(updatedAction.Action_Id);
            if (action == null)
            {
                throw new KeyNotFoundException($"Can't find action ");
            }
            else
            {
                _context.Entry(action).State = EntityState.Detached;
                _context.Attach(updatedAction);

                action.isDone = updatedAction.isDone;
                action.Description = updatedAction.Description;
                var actions = await _actionRepository.UpdateAction(updatedAction);
                return actions;
            }
           
            
        }
    }
}
