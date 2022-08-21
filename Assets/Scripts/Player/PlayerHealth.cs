using UnityEngine;
using MyWorld.SO;

namespace MyWorld.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private IntValue initialHealth;
        [SerializeField] private IntValue health;


        private void Start()
        {
            health.SetValue(initialHealth.Value);
        }

        public void GetDamage(int damage)
        {
            health.SetValue(health.Value-damage);
        }
    }
}

