using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.actors
{
    public class TurboConsumable : Consumable
    {
        [Header("Components")]
        [SerializeField]
        [Tooltip("Transform of the aircraft the rig follows and references")]
        private float turboForce = 10.0f;

        public TurboConsumable()
        {
            this.NAME = "TurboConsumable";
            Debug.Log("Item Created");
        }
        override public string GetName()
        {
            return this.NAME;
        }
        override public void Consume(Player target)
        {
            Debug.Log("Item Used");
            Debug.Log(Vector3.forward * turboForce);
            StartCoroutine(StartTurbo(target));
        }

        IEnumerator StartTurbo(Player target)
        {
            Debug.Log("Start Adding force");
            StartCoroutine(AddForce(target));
            yield return new WaitForSeconds(1);
            Debug.Log("Stopping Adding force");
            StopCoroutine(AddForce(target));

        }

        IEnumerator AddForce(Player target)
        {
            for (int i = 0; i < 10; i++)
            {
                // target.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * turboForce);
                target.GetComponent<Rigidbody>().velocity += transform.forward * turboForce;
                Debug.Log(target.GetComponent<Rigidbody>().velocity);
                yield return null;
            }
        }
    }
}

