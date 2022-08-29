using UnityEngine;

namespace MyWorld.SO.Events
{
    public abstract class DescriptionBase : ScriptableObject
    {
        [TextArea] [SerializeField] 
        private string description;
    }
}
