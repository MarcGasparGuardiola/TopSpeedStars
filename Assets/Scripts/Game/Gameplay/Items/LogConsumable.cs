using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.actors
{
    public class LogConsumable : Consumable
    {
<<<<<<< HEAD
        public  LogConsumable()
=======
        private string NAME = "LogConsumable";
        public LogConsumable()
>>>>>>> 6e4512a889d3d63522d1d9ed2d23b9fea3c79bfb
        {
            Debug.Log("Item Created");
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

