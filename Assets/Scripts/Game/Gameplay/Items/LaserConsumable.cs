using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.actors
{
    public class LaserConsumable : Consumable
    {

        private new string NAME = "LaserConsumable";
        public LaserConsumable()
        

        {
            Debug.Log("Item Created");
        }
        override public string GetName()
        {
            return this.NAME;
        }
        override public void Consume(Player target)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 100.0f))
                print("Found an object - distance: " + hit.distance);
        }
        void FixedUpdate()
        {
           
        }
    }
}
