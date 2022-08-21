using UnityEngine;
using UnityEngine.Events;

namespace MyWorld.SO.Events
{

    public abstract class EventChannelBase : DescriptionBase
    {

    }

    public class EventChannel<T> : EventChannelBase
    {
        private UnityAction<T> actionBase;

        public virtual void RegisterListener(UnityAction<T> action)
        {
            actionBase += action;
        }

        public virtual void UnregisterListener(UnityAction<T> action)
        {
            actionBase -= action;
        }

        public virtual void RaiseEvent(T arg1)
        {
            actionBase?.Invoke(arg1);
        }
    }
}
