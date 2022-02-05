namespace Code420.SfBlazorPlus.Code.CssUtilities
{
    public interface ICssUtilities
    {
        Task<string> ConvertToRgba(string backgroundColor, decimal backgroundOpacity);
        string GenerateRgba(string backgroundColor, decimal backgroundOpacity);
    }
}
