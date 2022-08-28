using System;
using System.Collections;
using UnityEngine;

namespace  Quest.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        [SerializeField] private Pistol pistol;
        private void Update()
        {
            if (Time.timeScale == 0) return;
            Shoot();
        }
        
        private void Shoot()
        {
            if (Input.GetMouseButtonDown(0))//Shooting
            {
                pistol.PlayShot();
            }
        }
    }
}