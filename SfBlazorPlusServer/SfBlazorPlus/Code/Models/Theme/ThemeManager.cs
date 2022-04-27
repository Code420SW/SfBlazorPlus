using Code420.SfBlazorPlus.Code.Enums;

namespace Code420.SfBlazorPlus.Code.Models.Theme
{
    public class ThemeManager : IThemeManager
    {

        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================

        private ThemeType themeType = ThemeType.Light;
        private Dictionary<string, string> lightTheme { get; set; }
        private Dictionary<string, string> darkTheme { get; set; }

        #endregion



        #region Constructors

        public ThemeManager()
        {
            InitializeThemes();
            ActiveTheme = lightTheme;
        }

        #endregion



        #region Public Properties


        public Dictionary<string, string> ActiveTheme { get; set; }

        #endregion



        #region Public Methods Providing Access to the Underlying Components to the Consumer

        // ==================================================
        // Public Methods providing access to the underlying component to the consumer
        // ==================================================

        public void SetThemeType(ThemeType type)
        {
            themeType = type;

            ActiveTheme = themeType switch
            {
                ThemeType.Light => lightTheme,
                ThemeType.Dark => darkTheme,
                _ => lightTheme
            };
        }

        public string GetThemeItem(string key)
        {
            ActiveTheme.TryGetValue(key, out var item);
            return (item is not null) ? item : "red";
        }

        #endregion



        #region Private Methods for Internal Use Only

        private void InitializeThemes()
        {
            lightTheme = new Dictionary<string, string>
            {
                { "fg-color-500", "#77B6A6" },
                { "bg-color-100", "#F7F0E8" }
            };

            darkTheme = new Dictionary<string, string>
            {
                { "bg-color-100", "red" }
            };
        }

        #endregion
    }
}
