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

        private Dictionary<string, string> ColorPalette { get; set; }

        #endregion



        #region Constructors

        public ThemeManager()
        {
            LoadColorPalette();
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

        //private string GetColorPaletteValue(string key)
        //{
        //    return ColorPalette[key];
        //}

        private void LoadColorPalette()
        {
            ColorPalette = new Dictionary<string, string>()
            {
                {"fg-900", "rgb(0, 141, 119)" },
                {"fg-700", "rgb(50, 151, 131)" },
                {"fg-500", "rgb(119, 182, 166)" },
                {"fg-300", "rgb(178, 213, 203)" },
                {"fg-100", "rgb(236, 245, 242)" },

                {"bg-900", "rgb(141, 101, 0)" },
                {"bg-700", "rgb(189, 154, 99)" },
                {"bg-500", "rgb(210, 182, 142)" },
                {"bg-300", "rgb(229, 211, 186)" },
                {"bg-100", "rgb(247, 240, 232)" },

                {"accent1-900", "rgb(141, 31, 0)" },
                {"accent1-700", "rgb(194, 114, 88)" },
                {"accent1-500", "rgb(215, 153, 133)" },
                {"accent1-300", "rgb(234, 193, 180)" },
                {"accent1-100", "rgb(249, 234, 230)" },

                {"accent2-900", "rgb(59, 0, 141)" },
                {"accent2-700", "rgb(138, 98, 184)" },
                {"accent2-500", "rgb(173, 141, 205)" },
                {"accent2-300", "rgb(206, 185, 225)" },
                {"accent2-100", "rgb(239, 231, 245)" },

                {"black-900", "rgb(20, 20, 20)" },
                {"black-700", "rgb(37, 37, 37)" },
                {"black-500", "rgb(95, 95, 95)" },
                {"black-300", "rgb(160, 160, 160)" },
                {"black-100", "rgb(231, 231, 231)" },

                {"white-900", "rgb(246,246,246)" },
                {"white-700", "rgb(249,249,249)" },
                {"white-500", "rgb(250,250,250)" },
                {"white-300", "rgb(252,252,252)" },
                {"white-100", "rgb(254,254,254)" },

                {"css-inherit", "inherit" },
                {"css-transparent", "transparent" }
            };
        }
        private void InitializeThemes()
        {
            lightTheme = new Dictionary<string, string>();

            lightTheme["header1--bg"] = ColorPalette["bg-700"];
            lightTheme["header2--bg"] = ColorPalette["bg-700"];
            lightTheme["footer--bg"] = ColorPalette["bg-700"];
            lightTheme["border__main--color"] = ColorPalette["accent1-700"];

            lightTheme["tab__container--bg"] = ColorPalette["bg-100"];
            lightTheme["tab__container--fg"] = ColorPalette["fg-900"];

            lightTheme["tab__header--bg"] = ColorPalette["bg-300"];
            lightTheme["tab__header-active-border--color"] = ColorPalette["fg-900"];
            lightTheme["tab__header-inactive-border--color"] = ColorPalette["fg-700"];
            lightTheme["tab__text-active--font-color"] = ColorPalette["fg-900"];
            lightTheme["tab__text-inactive--font-color"] = ColorPalette["fg-900"];
            lightTheme["tab__text-active-hover--font-color"] = ColorPalette["accent1-900"];
            lightTheme["tab__text-inactive-hover--font-color"] = ColorPalette["accent1-900"];

            lightTheme["sidebar--bg"] = ColorPalette["bg-300"];
            lightTheme["sidebar__border--color"] = ColorPalette["accent1-700"];
            lightTheme["sidebar__backdrop--bg"] = ColorPalette["accent1-300"];

            lightTheme["vmenu__item-normal--font-color"] = ColorPalette["fg-900"];
            lightTheme["vmenu__item-normal--background-color"] = ColorPalette["css-transparent"];
            lightTheme["vmenu__item-active--font-color"] = ColorPalette["accent1-900"];
            lightTheme["vmenu__item-active--background-color"] = ColorPalette["css-inherit"];
            lightTheme["vmenu__icon--font-color"] = ColorPalette["css-inherit"];
            lightTheme["vmenu__caret--font-color"] = ColorPalette["css-inherit"];
            lightTheme["vmenu__separator--border-color"] = ColorPalette["accent1-500"];
            lightTheme["vmenu__popup--font-color"] = ColorPalette["fg-900"];
            lightTheme["vmenu__popup--background-color"] = ColorPalette["bg-300"];
            lightTheme["vmenu__popup--border-color"] = ColorPalette["accent1-700"];

            lightTheme["hmenu__item-normal--font-color"] = ColorPalette["white-700"];
            lightTheme["hmenu__item-normal--background-color"] = ColorPalette["css-transparent"];
            lightTheme["hmenu__item-active--font-color"] = ColorPalette["accent1-900"];
            lightTheme["hmenu__item-active--background-color"] = ColorPalette["css-inherit"];
            lightTheme["hmenu__icon--font-color"] = ColorPalette["css-inherit"];
            lightTheme["hmenu__caret--font-color"] = ColorPalette["css-inherit"];
            lightTheme["hmenu__separator--border-color"] = ColorPalette["accent1-500"];
            lightTheme["hmenu__popup--font-color"] = ColorPalette["fg-900"];
            lightTheme["hmenu__popup--background-color"] = ColorPalette["bg-300"];
            lightTheme["hmenu__popup--border-color"] = ColorPalette["accent1-700"];

            lightTheme["sidebar-btn__btn-normal--background-color"] = ColorPalette["fg-700"];
            lightTheme["sidebar-btn__btn-normal--border-color"] = ColorPalette["bg-900"];
            lightTheme["sidebar-btn__btn-hover--background-color"] = ColorPalette["fg-700"];
            lightTheme["sidebar-btn__btn-hover--border-color"] = ColorPalette["accent1-900"];
            lightTheme["sidebar-btn__btn-active--background-color"] = ColorPalette["fg-700"];
            lightTheme["sidebar-btn__btn-active--border-color"] = ColorPalette["accent1-900"];
            lightTheme["sidebar-btn__icon-normal--font-color"] = ColorPalette["white-500"];




            darkTheme = new Dictionary<string, string>();

            darkTheme["header1--bg"] = ColorPalette["black-500"];
            darkTheme["header2--bg"] = ColorPalette["black-500"];
            darkTheme["footer--bg"] = ColorPalette["black-500"];
            darkTheme["border__main--color"] = ColorPalette["accent2-700"];

            darkTheme["tab__container--bg"] = ColorPalette["black-900"];  //black-900
            darkTheme["tab__container--fg"] = ColorPalette["white-500"];    //white-500

            darkTheme["tab__header--bg"] = ColorPalette["black-300"];
            darkTheme["tab__header-active-border--color"] = ColorPalette["accent2-900"];
            darkTheme["tab__header-inactive-border--color"] = ColorPalette["accent2-700"];
            darkTheme["tab__text-active--font-color"] = ColorPalette["accent2-900"];
            darkTheme["tab__text-inactive--font-color"] = ColorPalette["accent2-900"];
            darkTheme["tab__text-active-hover--font-color"] = ColorPalette["white-700"];
            darkTheme["tab__text-inactive-hover--font-color"] = ColorPalette["white-700"];

            darkTheme["sidebar--bg"] = ColorPalette["black-300"];
            darkTheme["sidebar__border--color"] = ColorPalette["accent2-700"];
            darkTheme["sidebar__backdrop--bg"] = ColorPalette["accent2-300"];

            darkTheme["vmenu__item-normal--font-color"] = ColorPalette["accent2-900"];
            darkTheme["vmenu__item-normal--background-color"] = ColorPalette["css-transparent"];
            darkTheme["vmenu__item-active--font-color"] = ColorPalette["white-700"];
            darkTheme["vmenu__item-active--background-color"] = ColorPalette["css-inherit"];
            darkTheme["vmenu__icon--font-color"] = ColorPalette["css-inherit"];
            darkTheme["vmenu__caret--font-color"] = ColorPalette["css-inherit"];
            darkTheme["vmenu__separator--border-color"] = ColorPalette["accent2-500"];
            darkTheme["vmenu__popup--font-color"] = ColorPalette["accent2-900"];
            darkTheme["vmenu__popup--background-color"] = ColorPalette["black-300"];
            darkTheme["vmenu__popup--border-color"] = ColorPalette["accent2-700"];

            darkTheme["hmenu__item-normal--font-color"] = ColorPalette["white-700"];
            darkTheme["hmenu__item-normal--background-color"] = ColorPalette["css-transparent"];
            darkTheme["hmenu__item-active--font-color"] = ColorPalette["accent2-900"];
            darkTheme["hmenu__item-active--background-color"] = ColorPalette["css-inherit"];
            darkTheme["hmenu__icon--font-color"] = ColorPalette["css-inherit"];
            darkTheme["hmenu__caret--font-color"] = ColorPalette["css-inherit"];
            darkTheme["hmenu__separator--border-color"] = ColorPalette["accent2-500"];
            darkTheme["hmenu__popup--font-color"] = ColorPalette["white-500"];
            darkTheme["hmenu__popup--background-color"] = ColorPalette["black-300"];
            darkTheme["hmenu__popup--border-color"] = ColorPalette["accent2-700"];

            darkTheme["sidebar-btn__btn-normal--background-color"] = ColorPalette["black-300"];
            darkTheme["sidebar-btn__btn-normal--border-color"] = ColorPalette["accent2-700"];
            darkTheme["sidebar-btn__btn-hover--background-color"] = ColorPalette["black-700"];
            darkTheme["sidebar-btn__btn-hover--border-color"] = ColorPalette["accent2-500"];
            darkTheme["sidebar-btn__btn-active--background-color"] = ColorPalette["black-700"];
            darkTheme["sidebar-btn__btn-active--border-color"] = ColorPalette["accent2-500"];
            darkTheme["sidebar-btn__icon-normal--font-color"] = ColorPalette["white-500"];
        }

        #endregion
    }
}
