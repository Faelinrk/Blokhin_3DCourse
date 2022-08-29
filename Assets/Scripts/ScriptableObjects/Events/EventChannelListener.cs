using UnityEngine;
using UnityEngine.Events;

namespace MyWorld.SO.Events
{
    [ExecuteInEditMode]
    public abstract class EventChannelListenerBase : MonoBehaviour
    {
        [TextArea] [SerializeField] 
        private string _description;
    }
    public abstract class EventChannelListener <T>:EventChannelListenerBase
    {
        [SerializeField]
        private EventChannel<T> GameAction;
        [SerializeField]
        private UnityEvent<T> unityEvent;
        
        public virtual void OnEnable()
        {
            if (GameAction)
            {
                GameAction.RegisterListener(OnEventRaised);
            }
        }
        public virtual void OnDisable()
        {
            if (GameAction)
            {
                GameAction.UnregisterListener(OnEventRaised);
            }
        }
        
        public virtual void OnEventRaised(T arg1)
        {
            unityEvent?.Invoke(arg1);
        }
    }
}

