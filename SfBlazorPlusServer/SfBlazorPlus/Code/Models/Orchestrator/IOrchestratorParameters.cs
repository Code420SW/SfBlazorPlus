using Code420.SfBlazorPlus.Code.Models.Menus;
using Syncfusion.Blazor.Navigations;

namespace Code420.SfBlazorPlus.Code.Models.Orchestrator
{
    public interface IOrchestratorParameters
    {
        List<OrchestratorMenuItem> SidebarMenuItems { get; }
        List<OrchestratorMenuItem> MainMenuItems { get; }
        List<OrchestratorMenuItem> FavoritesMenuItems { get; }
        List<OrchestratorTabDefinition> OrchestratorTabs { get; }
    }
}