
namespace Code420.SfBlazorPlus.Code.Models.Orchestrator
{
    public interface IOrchestratorMenuItem
    {
        Dictionary<string, object> HtmlAttributes { get; set; }
        string IconCss { get; set; }
        bool IsDisabled { get; set; }
        bool IsHidden { get; set; }
        bool IsSeparator { get; set; }
        string ItemId { get; set; }
        string MenuText { get; set; }
        string ParentId { get; set; }
        List<OrchestratorMenuItem> SubMenu { get; set; }
        string Url { get; set; }
    }
}