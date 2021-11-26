using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.actors
{
    public class LogConsumable : MonoBehaviour, IConsumable
    {
        public LogConsumable()
        {
            Debug.Log("Item Created");
        }

        public void Consume(Plane target)
        {
            Debug.Log("Item Used");
            target.GetComponent<Rigidbody>().transform.position = new Vector3(0,0,0);
        }
    }
}

