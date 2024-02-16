using life_copilot_kernel.Models;
using Action = life_copilot_kernel.Models.Action;

namespace life_copilot_kernel.Services
{
    public interface IActionService
    {
        Task<List<Action>> GetAllActions();
        Task<Action> GetActionById(Guid? id);

        Task<List<Action>> GetActionByStatus(bool status);

        Task<Action> PostAction(Action newAction);

        Task<Action> DeleteAction(Guid? id);

        Task<Action> UpdateAction(Action updatedAction);
    }
}
