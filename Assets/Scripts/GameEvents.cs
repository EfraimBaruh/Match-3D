using DefaultNamespace;
using UnityEngine.Events;

namespace Events
{
    public static class GameEvents
    {
        public static BoolEvent IsMatch = new BoolEvent();

        public static OnMatchEvent ColumnMatch = new OnMatchEvent();

        public static OnMatchEvent RowMatch = new OnMatchEvent();

        public static OnSwipeEvent ControlMatch = new OnSwipeEvent();

        public static UnityEvent MatchActionCompleted = new UnityEvent();
    }
    
    public class BoolEvent : UnityEvent<bool> { }
    
    public class OnMatchEvent : UnityEvent<int, int, int> { }
    
    public class OnSwipeEvent : UnityEvent<int, int, SwipeDirection> {}
}
