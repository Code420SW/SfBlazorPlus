using Microsoft.AspNetCore.Components;
using Code420.SfBlazorPlus.BaseComponents.TabBase;
using Syncfusion.Blazor.Navigations;
using System.Diagnostics;
using Code420.SfBlazorPlus.Pages.Orchestrator;
using Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorTabManager.OrchestratorTabs.DummyTab;
using Syncfusion.Blazor;
using Code420.SfBlazorPlus.Code.Models.Orchestrator;

namespace Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorTabMananger
{
    public partial class OrchestratorTabManager : ComponentBase
    {

        #region Component Parameters

        #region Base Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// Contains the reference to the <see cref="Orchestrator"/> parent.
        /// Used to subscribe to event handlers provided by the parent.
        /// </summary>
        [Parameter]
        public Orchestrator OrchestratorRef { get; set; }

        /// <summary>
        /// String value specifying the name of the Orchestrator Tab component loaded when the the
        /// Tab Manager component is loaded.
        /// All Orchestrator Tabs must be located in the following namespace:
        /// Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorTabManager.OrchestratorTabs
        /// </summary>
        [Parameter]
        public string InitialMenuItemId { get; set; } = default;

        #endregion


        #region Event Callback Parameters

        // ==================================================
        // Event Callback Parameters
        // ==================================================


        #endregion


        #region CSS Parameters

        // ==================================================
        // CSS Styling Parameters
        // ==================================================


        #endregion

        #endregion



        #region Callback Events Invoked from Underlying Components

        // ==================================================
        // Methods used as Callback Events from the underlying component(s)
        // ==================================================

        private void MyAddedHandler(AddEventArgs args)
        {
            Debug.WriteLine("MyAddedHandler method invoked.");
        }

        private void MyAddingHandler(AddEventArgs args)
        {
            Debug.WriteLine("MyAddingHandler method invoked.");
        }

        private void MyCreatedHandler(object args)
        {
            Debug.WriteLine("MyCreatedHandler method invoked.");
            Debug.WriteLine($"ChildContent: { this.tabbase.ChildContent }");
        }

        private void MyDestroyedHandler(object args)
        {
            Debug.WriteLine("MyDestroyedHandler method invoked.");
        }

        private void MyDraggedHandler(DragEventArgs args)
        {
            Debug.WriteLine("MyDraggedHandler method invoked.");
        }

        private void MyOnDragStartHandler(DragEventArgs args)
        {
            Debug.WriteLine("MyOnDragStartHandler method invoked.");
        }

        private void MyOnRemovedHandler(RemoveEventArgs args)
        {
            Debug.WriteLine("MyOnRemovedHandler method invoked.");
        }

        private void MyOnRemovingHandler(RemoveEventArgs args)
        {
            Debug.WriteLine("MyOnRemovingHandler method invoked.");
        }

        private void MyOnSelectedHandler(SelectEventArgs args)
        {
            Debug.WriteLine($"MyOnSelectedHandler method invoked. Index = { selectedItem }");
            //var junk = await this.TabObj.GetTabContentAsync(selectedItem);
            //string[] tempString = { "my_dummy_class" };
            //await junk.AddClass(tempString);
            //StateHasChanged();
            //var classList = await junk.GetClassList();
            //Debug.WriteLine($"Content = { classList }");
        }

        private void MyOnSelectingHandler(SelectingEventArgs args)
        {
            Debug.WriteLine("MyOnSelectingHandler method invoked.");
        }

        private void MyOnSelectedItemChangedHandler(int index)
        {
            selectedItem = index;
            Debug.WriteLine($"MyOnSelectedItemChangedHandler method invoked. Index = { index }");
        }



        #endregion



        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================

        private const string appNamespace = "Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorTabManager.OrchestratorTabs";
        private TabBase tabbase;
        private int selectedItem = 0;
        RenderFragment renderFragment;
        List<TabItem> tabItem;

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

            //
            if (string.IsNullOrEmpty(InitialMenuItemId)) return;

            //
            //OrchestratorMenuItem defaultMenuItem = OrchestratorRef.SidebarMenuItems.FirstOrDefault(x => x.ItemId == InitialMenuItemId);

            //Type? myComponent1 = ResolveComponent(defaultMenuItem.ComponentName);

            TabItem? componentTabItem;
            //Type? component = null;
            if (OrchestratorRef.OrchestratorTabs.TryGetValue(InitialMenuItemId, out componentTabItem) is false) return;

            tabItem = new List<TabItem>() { componentTabItem };
            //component = ResolveComponent(componentName);
            //if (component is null) return;
            //renderFragment = RenderComponent(typeof(DummyTab));

            //
            //tabItem = new()
            //{
            //    new TabItem
            //    {
            //        CssClass="tab__hardware",
            //        ContentTemplate = renderFragment,
            //        Disabled=false,
            //        Header = new TabHeader() 
            //        { 
            //            IconCss= "",
            //            IconPosition="",
            //            Text = "Default Tab"
            //        },
            //        Visible=true
            //    }
            //};

            //await AddTabAsync(tabItem, 1);

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
        /// Adds a list of Tab items to the Tab.
        /// </summary>
        /// <param name="items">List of <see cref="TabItem"/> to add to the Tab.</param>
        /// <param name="index">Index value that determines where the items to be added</param>
        public async Task AddTabAsync(List<TabItem> items, int index) => await this.tabbase.AddTabAsync(items, index);

        /// <summary>
        /// Disables/enables the Tab component.
        /// </summary>
        /// <param name="disable">Boolean value specifying is the Tab component is disabled (true) or enabled.</param>
        public async Task DisableAsync(bool disable) => await this.tabbase.DisableAsync(disable);

        /// <summary>
        /// Enables or disables a specific tab item.
        /// </summary>
        /// <param name="index">Integer value specifying the index of the tab.</param>
        /// <param name="isEnable">Boolean value specifying is the tab is enabled (true) or disabled.</param>
        /// <returns></returns>
        public async Task EnableTabAsync(int index, bool isEnable = true) => await this.tabbase.EnableTabAsync(index, isEnable);

        /// <summary>
        /// Returns the content element of the tab with the specified index.
        /// </summary>
        /// <param name="index">Integer value specifying the index of the tab whose content is to returned.</param>
        /// <returns>A <see cref="DOM"/> object containg the contents of the tab.</returns>
        public async Task<DOM> GetTabContentAsync(int index)
        {
            return await this.tabbase.GetTabContentAsync(index);
        }

        /// <summary>
        /// Returns the header element of the tab with the specified index.
        /// </summary>
        /// <param name="index">Integer value specifying the index of the tab whose content is to returned.</param>
        /// <returns>A <see cref="DOM"/> object containg the header element of the tab.</returns>
        public async Task<DOM> GetTabItemAsync(int index)
        {
            return await this.tabbase.GetTabItemAsync(index);
        }

        /// <summary>
        /// Show/hides a tab based on the specified index.
        /// </summary>
        /// <param name="index">Integer value spefifying the index of the tab to show/hide.</param>
        /// <param name="show">Boolean value specifying if the tab is shown (true) or hidden.</param>
        /// <returns></returns>
        public async Task HideTabAsync(int index, bool show) => await this.tabbase.HideTabAsync(index, show);

        /// <summary>
        /// Refresh the entire Tab component.
        /// </summary>
        public async Task RefreshAsync() => await this.tabbase.RefreshAsync();

        /// <summary>
        /// Removes an entire tab from the collection of tabs.
        /// </summary>
        /// <param name="index">Integer value spefifying the index of the tab to remove.</param>
        public async Task RemoveTabAsync(int index) => await this.tabbase.RemoveTabAsync(index);

        /// <summary>
        /// Activates a tab based on the specified index.
        /// </summary>
        /// <param name="index">Integer value spefifying the index of the tab to activate.</param>
        public async Task SelectAsync(int index) => await this.tabbase.SelectAsync(index);

        #endregion



        #region Private Methods for Internal Use Only

        //private Type? ResolveComponent(string componentName)
        //{
        //    return string.IsNullOrEmpty(componentName) ? null
        //        : Type.GetType($"{appNamespace}.{componentName}.{componentName}");
        //}

        //private RenderFragment RenderComponent(Type componentType) => 
        //    builder =>
        //{
        //    builder.OpenComponent(0, componentType);
        //    //builder.AddAttribute(1, "some-parameter", "a value");
        //    builder.CloseComponent();
        //};

        #endregion

    }
}
