using Syncfusion.Blazor.Navigations;

namespace Code420.SfBlazorPlus.Code.Models.Orchestrator
{
    public interface IOrchestratorTabDefinition
    {
        bool IsLoaded { get; set; }
        string MenuItemId { get; set; }
        TabItem TabDefinition { get; set; }
        int TabIndex { get; set; }
    }
}