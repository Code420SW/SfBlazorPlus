﻿using Microsoft.JSInterop;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Code420.SfBlazorPlus.Code.CssUtilities
{
    public class CssUtilities : ICssUtilities
    {
        #region Instance Variables


        #endregion


        #region Injected Dependencies

        // Injected instance of JS Runtime
        private IJSRuntime _jsRuntime;

        #endregion


        #region Constructor

        public CssUtilities(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// Converts the passed CSS color value from hex format to RGB and assigns the passed
        /// opacity value to create an RGBA value.
        /// </summary>
        /// <param name="backgroundColor">A CSS color value in either hex format of as a CSS
        /// var() that can be reduced to a hex color value.</param>
        /// <param name="backgroundOpacity">A CSS opacity value that will be used to contruct
        /// an RGBA color value.</param>
        /// <returns>String value containing an RGBA color value. If any errors occur preventing
        /// creation of the RGBA color value, black is returned.</returns>
        public async Task<string> ConvertToRgba(string backgroundColor, decimal backgroundOpacity)
        {
            string temp;
            string temp2;
            string output;


            // Consider the case where a CSS var() was passed in.
            // If not a var(), use the passed color value and continue processing
            if (backgroundColor.StartsWith("var("))
            {
                // Extract the varianble from the var()
                int pos = backgroundColor.IndexOf(")");
                if (pos == -1) return String.Empty;
                temp = backgroundColor.Substring(4, (pos - 4));

                // Call our JS helper routine to convert the variable to ots root value
                // If an error orcurred (like bad variable name), an empty string is returned
                temp2 = await _jsRuntime.InvokeAsync<string>("getCssVariable", temp);

                // If an error orcurred, return black as the color value
                if (temp2 == "") return "black";
            }
            else
            {
                temp2 = backgroundColor;
            }

            // Use the CSS utility class to convert the color value into RGBA
            // Return a black color value if an exception is thrown
            try
            {
                output = GenerateRgba(temp2, backgroundOpacity);
                return output;
            }
            catch (Exception ex)
            {
                return "black";
            }
        }

        /// <summary>
        /// Converts a CSS color value in hex format to RGBA format.
        /// </summary>
        /// <param name="backgroundColor">CSS color value in hex format</param>
        /// <param name="backgroundOpacity">CSS opacity value in decimal format</param>
        /// <returns></returns>
        public string GenerateRgba(string backgroundColor, decimal backgroundOpacity)
        {
            //
            // Remove all white spaces
            //
            string cleanString = RemoveWhitespace(backgroundColor);
            
            //
            // Handle hex formatted color code
            //
            if (cleanString.StartsWith("#"))
            {
                Color color = ColorTranslator.FromHtml(cleanString);
                int r = Convert.ToInt16(color.R);
                int g = Convert.ToInt16(color.G);
                int b = Convert.ToInt16(color.B);
                return string.Format("rgba({0}, {1}, {2}, {3});", r, g, b, backgroundOpacity);
            }
            else if (cleanString.StartsWith("rgb("))
            {
                //
                // Use RegEx to parse the rgb() values
                //
                Regex regex = new Regex(@"rgb\((?<r>\d{1,3}),(?<g>\d{1,3}),(?<b>\d{1,3})\)");
                Match match = regex.Match(cleanString);
                if (match.Success)
                {
                    int r = int.Parse(match.Groups["r"].Value);
                    int g = int.Parse(match.Groups["g"].Value);
                    int b = int.Parse(match.Groups["b"].Value);

                    return string.Format("rgba({0}, {1}, {2}, {3});", r, g, b, backgroundOpacity);
                }
                else return string.Format("rgba(0, 0, 0, {0});", backgroundOpacity);
            }
            else
            {
                return string.Format("rgba(0, 0, 0, {0});", backgroundOpacity);
            }
        }

        #endregion


        #region Private Methods for Internal Use Only

        private string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        #endregion
    }
}
