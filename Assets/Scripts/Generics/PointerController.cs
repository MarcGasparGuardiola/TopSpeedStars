using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.actors;

namespace Gameplay.controllers
{
    public class PointerController : MonoBehaviour
    {
        public Player player;
        private CheckPoint currentCheck;
        public GameObject pointer;
        // Update is called once per frame

        private void Start()
        {
            try
            {
                currentCheck = player.check;
            }
            catch { }
        }
        void Update()
        {
            // Debug.DrawLine(player.transform.position, currentCheck.transform.position, Color.white);
            Vector3 direction = currentCheck.transform.position - player.transform.position;
            pointer.transform.rotation = Quaternion.LookRotation(direction, Vector3.up); ;
            pointer.transform.position = player.transform.position;
        }
        
        internal void SetCheck(CheckPoint newCheck)
        {
            currentCheck = newCheck;
        }
    }
}

