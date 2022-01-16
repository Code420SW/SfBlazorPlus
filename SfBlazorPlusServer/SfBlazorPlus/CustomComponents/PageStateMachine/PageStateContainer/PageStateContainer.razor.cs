using Code420.SfBlazorPlus.Code.Enums;
using Microsoft.AspNetCore.Components;

namespace Code420.SfBlazorPlus.CustomComponents.PageStateMachine.PageStateContainer
{
    //
    // This is a simple component that is part of the Page State Machine system.
    // The component should be instantiated only by the PageStateManager component.
    //
    // This component simply encapsulates RenderFragments that are tied to a PageState enum.
    // Based on the State parameter (which are set within the PageStateManager component), when asked to re-render, the RenderFragment associated with the State is rendered.
    //
    // There is no reason to add a bunch of intelligence to this component. Any "smarts" should be added to the PageStateManager component.
    //

    public partial class PageStateContainer : ComponentBase
    {

        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// Specifies the current state of the component. Value is one of <see cref="PageState"/>.
        /// A default value should never be used since it should be passing in by the PageStateManager. Regardless, the default value is Operating.
        /// </summary>
        [Parameter]
        public PageState State { get; set; } = PageState.Operating;


        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the Loading state. 
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment LoadingFragment { get; set; } = null;


        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the Operating state 
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment ContentFragment { get; set; } = null;


        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the Error state. 
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment ErrorFragment { get; set; } = null;


        // ==================================================
        // Event Callback Parameters
        // ==================================================


        // ==================================================
        // CSS Styling Parameters
        // ==================================================

        #endregion



        #region Callback Events Invoked from Underlying Components

        // ==================================================
        // Methods used as Callback Events from the underlying component(s)
        // ==================================================

        /// <summary>
        /// An <see cref="EventCallback"/> cast as an <see cref="Action"/> that encapsulated
        /// consumer's method called when the button is clicked.
        /// </summary>
        //public void Click() => OnClick.Invoke();

        #endregion



        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================


        #endregion



        #region Injected Dependencies

        // Injected Dependencies



        // Dependency Injection


        #endregion



        #region Constructors

        // ==================================================
        // Constructors
        // ==================================================

        // This method is executed whenever the parent renders.
        // Parameters that were passed into the component are contained in a ParameterView.
        //  This is a good point at which to make asynchronous calls to a server (for example)
        //  based on the state passed into the component.
        // The component’s [Parameter] properties are assigned their values when you call
        //  base.SetParametersAsync(parameters) inside your override.
        // It is also the correct place to assign default parameter values.
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);
        }

        // Once the state from the ParameterCollection has been assigned to the component’s
        //  [Parameter] properties, these methods are executed. This is useful in the same way
        //  as SetParametersAsync, except it is possible to use the component’s state.
        // This method is only executed once when the component is first created.If the parent
        //  changes the component’s parameters at a later time, this method is skipped.
        // When the component is a @page, and our Blazor app navigates to a new URL that renders
        //  the same page, Blazor will reuse the current object instance for that page.Because the
        //  object is the same instance, Blazor does not call IDisposable.Dispose on the object,
        //  nor does it execute its OnInitialized method again.
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }

        // This method will be executed immediately after OnInitializedAsync if this is a new
        //  instance of a component. If it is an existing component that is being re-rendered because
        //  its parent is re-rendering then the OnInitialized* methods will not be executed, and this
        //  method will be executed immediately after SetParametersAsync instead
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        // This is the first place that the State should be changed
        //
        // This method is executed every time Blazor has re-generated the component’s RenderTree.
        //  This can be as a result of the component’s parent re-rendering, the user interacting with the component
        //  (e.g. a mouse-click), or if the component executes its StateHasChanged method to invoke a re-render.
        // This method has a single parameter named firstRender. This parameter is true only the first time the
        //  method is called on the current component, from there onwards it will always be false. In cases where
        //  additional component hook-up is required (for example, via JavaScript) it is useful to know this is the
        //  first render.
        // It is not until after the OnAfterRender method have executed that it is safe to use any references to
        //  components set via the @ref directive. And it is not until after the OnAfterRender method have been
        //  executed with firstRender set to true that it is safe to use any references to HTML elements set via
        //  the @ref directive
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        #endregion



        #region Public Methods Providing Access to the Underlying Components to the Consumer

        // ==================================================
        // Public Methods providing access to the underlying component to the consumer
        // ==================================================

        #endregion



        #region Private Methods for Internal Use Only

        // Invoked when the component is asked to render itself.
        // Will return the RenderFragment associated with the current State.
        private RenderFragment GetCurrentStateRenderFragment()
        {
            return State switch
            {
                PageState.Loading => LoadingFragment,
                PageState.Operating => ContentFragment,
                PageState.Error => ErrorFragment,
                _ => ErrorFragment
            };
        }

        #endregion

    }
}
