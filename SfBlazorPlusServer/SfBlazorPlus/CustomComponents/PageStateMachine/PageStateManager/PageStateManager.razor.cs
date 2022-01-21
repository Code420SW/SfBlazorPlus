using Code420.SfBlazorPlus.Code.Enums;
using Microsoft.AspNetCore.Components;

namespace Code420.SfBlazorPlus.CustomComponents.PageStateMachine.PageStateManager
{
    // 
    // This can be confusing--picture may help.
    //      Your Razor page:    <PageStateManager   @ref=@pageStateManager
    //                                              PageState=PageState.Loading>
    //
    //                              <Loading> Your Loading RenderFragmant </Loading>
    //                              <Operating> Your Operating RenderFragmant </Operating>
    //                              <Error> Your Error RenderFragmant </Error>
    //
    //                          </PageStateManager>
    //
    //
    // The component is responsible for containerizing multiple RenderFragments that are associated (one to one) with the PageState parameter.
    //
    // The PageState parameter is passed in but should only updated through calls to this component's SetPageState() method by your Razor page.
    //
    // The current value of the PageState parameter is a parameter to the PageStateContainer component.
    //
    // The SetPageState() method forces a StateHasChanged() call which causes the PageStateContainer component te re-render itself which will return the correct ReanderFragment.
    //
    // The PageStateManager component can be extended to handle different rendering situations.
    //  The states handled by the component can be extended by ensuring:
    //      1.  A corresponding PageState is defined in the PageState enum
    //      2.  A corresponding RenderFragment is accepted as a parameter in this component--define a RenderFragment parameter below
    //      3.  A corresponding RenderFragment parameter is defined in the PageStateContainer component
    //      4.  The GetCurrentStateRenderFragment() method in the PageStateContainer component is updated to handle all valid page states
    //
    // If there is a desire to add more intelligence to the "container" system, this is the place to do it, not the PageStateContainer component.

    public partial class PageStateManager : ComponentBase
    {

        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the content portion of the
        /// container. The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment Operating { get; set; } = null;


        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the loading portion of the
        /// container. The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment Loading { get; set; } = null;


        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the errpr portion of the
        /// container. The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment Error { get; set; } = null;



        // ==================================================
        // Event Callback Parameters
        // ==================================================

        /// <summary>
        /// Callback function <see cref="EventCallback"/> that is invoked when the state of the
        /// container changes.
        /// </summary>
        [Parameter]
        public EventCallback<PageState> PageStateChanged { get; set; }


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

        /// <summary>
        /// Specifies the current state of the component. Value is one of <see cref="ComponentState"/>.
        /// The default value is Content.
        /// </summary>
        public PageState PageState { get; set; } = PageState.Operating;

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
            _pageStateStore.AddStateChangeListeners(() => {
                PageState = _pageStateStore.GetState().State;
                StateHasChanged();
            });
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

        /// <summary>
        /// Method exposing the container's State parameter. Can be invoked to change the state instead
        /// of using the parameter.
        /// </summary>
        /// <param name="state">The new <see cref="PageState"/> of the state machine.</param>
        public void SetPageState(PageState state)
        {
            this.PageState = state;
            InvokeAsync(StateHasChanged);
        }

        #endregion



        #region Private Methods for Internal Use Only

        private RenderFragment GetCurrentStateRenderFragment()
        {
            return PageState switch
            {
                PageState.Loading => Loading,
                PageState.Operating => Operating,
                PageState.Error => Error,
                _ => Error
            };
        }

        #endregion
    }
}
