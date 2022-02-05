using Code420.SfBlazorPlus.Code.Enums;

namespace Code420.SfBlazorPlus.Code.Models.MyCustomSpinner
{
    public class MyCustomSpinner
    {

        // Important that you update this to YOUR namespace
        private readonly string _assemblyNamespacePrefix = "Code420.SfBlazorPlus.CustomComponents.CustomSpinner.MyCustomSpinners";



        //
        // Instance variables
        //  Add ypur own as needed
        //

        private Type _spinnerType;
        private int _nominalHeight;
        private int _nominalWidth;
        private int _minHeight;
        private int _maxHeight;
        private int _minWidth;
        private int _maxWidth;
        private string _height;
        private string _width;



        //
        // Parameters
        //

        /// <summary>
        /// Type value containing the <see cref="Type" /> for the spinner component.
        /// </summary>
        public Type SpinnerType { get => _spinnerType; }

        /// <summary>
        /// String value containing the validated CSS size style for the spinner height.
        /// Value is based on parameter passed to constructor adjusted as needed to fall within the custom spinner's limits.
        /// </summary>
        public string SpinnerHeight { get => _height; }

        /// <summary>
        /// String value containing the validated CSS size style for the spinner width.
        /// Value is based on parameter passed to constructor adjusted as needed to fall within the custom spinner's limits.
        /// </summary>
        public string SpinnerWidth { get => _width; }



        //
        // Constructor
        //

        public MyCustomSpinner(CustomSpinners spinner, string height, string width)
        {

            // Save parameters to instance variables
            _height = height;
            _width = width;

            // Update instance variables for the spinner
            GetSpinnerSettings(spinner);

            // Perform sanity-checks on spinner parameters
            SetSpinnerSize(spinner);
        }


        //
        // Update instance variable for the spinner
        // Add new spinner definistions here
        // Provided a default clause in case you forget to update this method
        //
        private void GetSpinnerSettings(CustomSpinners spinner)
        {
            switch (spinner)
            {
                case CustomSpinners.SwingingBall:
                    _minHeight = _minWidth = 100;
                    _maxHeight = _maxWidth = 300;
                    _nominalHeight = _nominalWidth = 200;
                    _spinnerType = Type.GetType($"{ _assemblyNamespacePrefix }.CustomSpinnerSwingingBall");
                    break;

                default:
                    _minHeight = _minWidth = 100;
                    _maxHeight = _maxWidth = 300;
                    _nominalHeight = _nominalWidth = 200;
                    _spinnerType = Type.GetType($"{ _assemblyNamespacePrefix }.CustomSpinnerSwingingBall");
                    break;
            }
        }


        //
        // Method to validate parameters. Add to it as needed.
        //
        private void SetSpinnerSize(CustomSpinners spinner)
        {

            // Parse the passed _height and _width parameters as integers
            // It is assumed each is in the form of a CSS size style (e.g., 250px)
            // If a good parse can'r happen, fall back to defaults values
            if (int.TryParse(GetNumbers(_height), out int tempHeight) == false) tempHeight = _nominalHeight;
            if (int.TryParse(GetNumbers(_width), out int tempWidth) == false) tempWidth = _nominalWidth;


            // Sanity-check the sizes and adjust as needed
            if ((tempHeight < _minHeight) || (tempHeight > _maxHeight)) tempHeight = _nominalHeight;
            if ((tempWidth < _minWidth) || (tempWidth > _maxWidth)) tempWidth = _nominalWidth;


            // Reset the _height and _width
            _height = $"{ tempHeight }px";
            _width = $"{ tempWidth }px";
        }


        //
        // Helper method to parse integers out of a string
        //
        private string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
    }
}
