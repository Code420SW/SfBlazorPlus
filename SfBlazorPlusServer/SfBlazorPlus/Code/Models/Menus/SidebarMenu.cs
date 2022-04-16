namespace Code420.SfBlazorPlus.Code.Models.Menus
{
    public class SidebarMenu
    {
        public string Data { get; set; } = default;
        public bool Disabled { get; set; } = false;
        public bool Hidden { get; set; } = false;
        public Dictionary<string, object> HtmlAttributes { get; set; } = new();
        public string IconCss { get; set; } = default;
        public string ItemId { get; set; } = default;
        public string ParentId { get; set; } = default;
        public bool Separator { get; set; } = false;
        public string Url { get; set; } = default;
        public List<SidebarMenu> SubMenu { get; set; } = default;
    }
}
