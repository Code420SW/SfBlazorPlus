namespace Code420.SfBlazorPlus.Code
{
    public interface ICssUtilities
    {
        Task<string> ConvertToRgba(string backgroundColor, decimal backgroundOpacity);
        string GenerateRgba(string backgroundColor, decimal backgroundOpacity);
    }
}
