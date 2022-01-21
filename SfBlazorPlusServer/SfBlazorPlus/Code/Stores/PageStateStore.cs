using Code420.SfBlazorPlus.Code.Enums;

namespace Code420.SfBlazorPlus.Code.Stores
{
    public class CurrentPageState
    {
        public PageState State { get; }
        public CurrentPageState(PageState state)
        {
            State = state;
        }
    }
    public class PageStateStore
    {
        private CurrentPageState _state;
        public PageStateStore()
        {
            _state = new CurrentPageState(PageState.Operating);
        }
        public CurrentPageState GetState()
        {
            return _state;
        }

        public void UpdatePageState(PageState state)
        {
            _state = new CurrentPageState(state);
            BroadcastStateChange();
        }

        //==========================================================//

        private Action _listeners;
        public void AddStateChangeListeners(Action listener)
        {
            _listeners += listener;
        }
        public void RemoveStateChangeListeners(Action listener)
        {
            _listeners -= listener;
        }

        public void BroadcastStateChange()
        {
            _listeners.Invoke();
        }
    }
}
