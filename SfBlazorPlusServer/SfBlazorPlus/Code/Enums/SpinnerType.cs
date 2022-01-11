using System.ComponentModel;

namespace Code420.SfBlazorPlus.Code.Enums
{
    public enum SpinnerType
    {
        [Description(".e-spin-bootstrap4")]
        None = 0,

        [Description(".e-spin-material")]
        Material = 1,

        [Description(".e-spin-bootstrap4")]
        Bootstrap4 = 2,

        [Description(".e-spin-fabric .e-path-circle")]
        Fabric = 3,

        [Description(".e-spin-bootstrap")]
        Bootstrap = 4,

        [Description(".e-spin-high-contrast .e-path-circle")]
        HighContrast = 5,

        //[Description(".e-spin-tailwind")]
        //Tailwind = 6
    }
}
