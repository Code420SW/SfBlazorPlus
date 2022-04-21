namespace Code420.SfBlazorPlus.Code.Models.Orchestrator
{
    public class OrchestratorMenuItem : IOrchestratorMenuItem
    {
        public string MenuText { get; set; } = default;
        public bool IsDisabled { get; set; } = false;
        public bool IsHidden { get; set; } = false;
        public Dictionary<string, object> HtmlAttributes { get; set; } = new();
        public string IconCss { get; set; } = default;
        public string ItemId { get; set; } = default;
        public string ParentId { get; set; } = default;
        public bool IsSeparator { get; set; } = false;
        public string Url { get; set; } = default;
        public string ComponentName { get; set; } = default;
        public string ComponentCssClass { get; set; } = default;
        public bool ComponentDisabled { get; set; } = false;
        public bool ComponentVisible { get; set; } = true;
        public string ComponentTabHeaderIconCss { get; set; } = default;
        public string ComponentTabHeaderIconPosition { get; set; } = default;
        public string ComponentTabHeaderText { get; set; } = default;
        public List<OrchestratorMenuItem> SubMenu { get; set; } = default;
    }
}
