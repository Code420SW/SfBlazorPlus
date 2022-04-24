using Syncfusion.Blazor.Navigations;
using System.ComponentModel;

namespace Code420.SfBlazorPlus.Code.Models.Orchestrator
{
    /// <summary>
    /// Defines the field used for a Tab Item
    /// </summary>
    public class OrchestratorTabDefinition : IOrchestratorTabDefinition
    {
        [Description("Unique ID for the Tab")]
        public string MenuItemId { get; set; } = default;

        [Description("Inicates if the Tab is loaded")]
        public bool IsLoaded { get; set; } = default;

        [Description("The index of the loaded Tab")]
        public int TabIndex { get; set; } = default;

        [Description("Contains the RenderFragment for the Tab")]
        public TabItem TabDefinition { get; set; } = default;
    }
}
