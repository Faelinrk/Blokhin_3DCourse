using MyWorld.SO.Events;
using UnityEngine;

namespace MyWorld.SO
{
    [CreateAssetMenu(fileName = "New IntEventChannel", menuName = "EventChannel/Int",order=50)]
    public class IntEventChannel : EventChannel<int>
    {

    }
}

