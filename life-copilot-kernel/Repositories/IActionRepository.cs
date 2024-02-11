using life_copilot_kernel.Models;
using Action = life_copilot_kernel.Models.Action;

namespace life_copilot_kernel.Repositories
{
    public interface IActionRepository
    {
        Task<List<Action>> GetAllActions();
        Task<Action> GetActionById(Guid? id);

        Task<List<Action>> GetActionByStatus(bool status);

        Task<Action> PostAction(Action newAction);

        Task<Action> DeleteAction (Action action);

        Task<Action> UpdateAction(Action updatedAction);

    }
}
