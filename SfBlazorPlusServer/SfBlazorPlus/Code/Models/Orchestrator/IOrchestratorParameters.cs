
namespace Code420.SfBlazorPlus.Code.Models.Orchestrator
{
    public interface IOrchestratorParameters
    {
        List<OrchestratorMenuItem> SidebarMenuItems { get; }
        List<OrchestratorMenuItem> MainMenuItems { get; }
        List<OrchestratorMenuItem> FavoritesMenuItems { get; }
        Dictionary<string, string> OrchestratorTabs { get; }
    }
}