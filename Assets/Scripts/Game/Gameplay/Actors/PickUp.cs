using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.actors
{
    public class PickUp : MonoBehaviour
    {
        private void Start()
        {}

        public void TimeOut()
        {
            StartCoroutine(Coroutine());
        }

        public IEnumerator Coroutine()
        {
            // TODO time out avaliability of pickup
            this.GetComponent<Collider>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
            
            yield return new WaitForSeconds(5);

            this.GetComponent<Collider>().enabled = true;
            this.GetComponent<MeshRenderer>().enabled = true;

        }
    }
}

