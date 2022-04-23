using Syncfusion.Blazor.Navigations;

namespace Code420.SfBlazorPlus.Code.Models.Orchestrator
{
    public class OrchestratorTabDefinition : IOrchestratorTabDefinition
    {
        public string MenuItemId { get; set; } = default;
        public bool IsLoaded { get; set; } = default;
        public int TabIndex { get; set; } = default;
        public TabItem TabDefinition { get; set; } = default;
    }
}
