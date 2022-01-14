using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.actors
{
    public class LogConsumable : Consumable
    {
        public LogConsumable()
        {
            this.NAME = "LogConsumable";
            // Debug.Log("Item Created");
        }
        override public string GetName()
        {
            return this.NAME;
        }
        override public void Consume(Player target)
        {
            Debug.Log("Item Used");
            target.GetComponent<Rigidbody>().transform.position = new Vector3(0,0,0);
        }
    }
}

