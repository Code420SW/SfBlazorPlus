using System.ComponentModel;

namespace Code420.SfBlazorPlus.Code.Models.Menus
{
    /// <summary>
    /// Defines the fields used for a Menu Item.
    /// </summary>
    public class OrchestratorMenuItem : IOrchestratorMenuItem
    {
        [Description("Callback invoked when the Menu Item is selected")]
        public Action<object> MenuItemCallback { get; set; } = default;

        [Description("The Menu Item's display text")]
        public string MenuText { get; set; } = default;

        [Description("Indicates if the Menu Item is disabled")]
        public bool IsDisabled { get; set; } = false;

        [Description("Indicates if the Menu Item is hidden")]
        public bool IsHidden { get; set; } = false;

        [Description("Dictionary of CSS classes/attributes injected in the Menu Item's DOM element")]
        public Dictionary<string, object> HtmlAttributes { get; set; } = new();

        [Description("CSS class definition of the icon associated with the Menu Item")]
        public string IconCss { get; set; } = default;

        [Description("Unique identifier for the Menu Item")]
        public string ItemId { get; set; } = default;

        [Description("Identifies the Menu Item's parent Menu Item")]
        public string ParentId { get; set; } = default;

        [Description("Indicates if the Menu Item is a separator")]
        public bool IsSeparator { get; set; } = false;

        [Description("List of child Menu Items")]
        public List<OrchestratorMenuItem> SubMenu { get; set; } = default;

        [Description("URL followed when the Menu Item is clicked")]
        public string Url { get; set; } = default;

    }
}
