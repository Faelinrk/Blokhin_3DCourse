using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyWorld.SO
{
    [CreateAssetMenu(fileName = "New IntVariable", menuName = "IntVariable",order = 51)]
    public class IntValue : ScriptableObject
    {
        [SerializeField] private int value;
        public int Value => value;

        public void SetValue(int value)
        {
            this.value = value;
        }
    }  
}

