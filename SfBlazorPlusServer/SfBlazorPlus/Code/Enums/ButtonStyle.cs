using System.ComponentModel;

namespace Code420.SfBlazorPlus.Code.Enums
{
    public enum ButtonStyle
    {
        [Description("e-primary")]
        Primary = 0,
        [Description("e-success")]
        Success = 1,
        [Description("e-info")]
        Information = 2,
        [Description("e-warning")]
        Warning = 3,
        [Description("e-danger")]
        Danger = 4,
        [Description("e-link")]
        Link = 5,
        [Description("e-secondary")]
        Secondary = 6,
        [Description("e-outline")]
        Outline = 7,
        [Description("e-flat")]
        Flat = 8,
        [Description("e-block")]
        Block = 9
    }
}
