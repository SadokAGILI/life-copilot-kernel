using life_copilot_kernel.Data;
using life_copilot_kernel.Models;
using life_copilot_kernel.Repositories;
using Microsoft.EntityFrameworkCore;
using Action = life_copilot_kernel.Models.Action;

namespace life_copilot_kernel.Repositories_Implementations
{
    public class ActionRepository : IActionRepository
    {
        private readonly DBContext _context;
        public ActionRepository(DBContext Context)
        {
            _context = Context;
        }

        public Task<List<Action>> GetAllActions()
        {
            var actions = _context.Actions.ToListAsync();
            return actions;
        }

        public Task<Action> GetActionById(Guid? id)
        {
            var actions = _context.Actions.FirstOrDefaultAsync(u => u.Action_Id == id);
            return actions;
        }

        public Task<List<Action>> GetActionByStatus(bool status)
        {
            var actions = _context.Actions.Where(u => u.isDone == status).ToListAsync();
            return actions;
        }
        public async Task<Action> PostAction(Action newAction)
        {
            _context.Actions.Add(newAction);
            await _context.SaveChangesAsync();
            return newAction;
        }
        public async Task<Action> UpdateAction(Action updatedAction)
        {
            
          
            _context.Actions.Update(updatedAction);
            await _context.SaveChangesAsync();
            return updatedAction;
        }

        public async Task<Action> DeleteAction(Action action)
        {
            _context.Actions.Remove(action);
            await _context.SaveChangesAsync();
            return action;
        }
    }
}
