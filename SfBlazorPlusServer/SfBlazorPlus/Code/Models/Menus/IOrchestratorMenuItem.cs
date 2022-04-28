
namespace Code420.SfBlazorPlus.Code.Models.Menus
{
    public interface IOrchestratorMenuItem
    {
        Action<object> MenuItemCallback { get; set; }
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