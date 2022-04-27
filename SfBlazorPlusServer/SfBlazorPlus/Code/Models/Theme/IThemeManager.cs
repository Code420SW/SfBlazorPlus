using Code420.SfBlazorPlus.Code.Enums;

namespace Code420.SfBlazorPlus.Code.Models.Theme
{
    public interface IThemeManager
    {
        Dictionary<string, string> ActiveTheme { get; set; }

        void SetThemeType(ThemeType themeType);

        string GetThemeItem(string key);
    }
}