using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.actors
{
    public class Player : Plane
    {

        private Consumable item;

        // Start is called before the first frame update
        void Start()
        {
            this.item = null;
        }

        // Update is called once per frame
        void Update()
        {
            // consume, TODO input adequat
            if (Input.GetKeyDown(KeyCode.I))
            {
                UseItem();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PickUp") || other is PickUp)
            {
                // other.gameObject.SetActive(false);
                Debug.Log("PickUp");
                if (this.item == null)
                {
                    // TODO random select consumible
                    this.item = new LogConsumable();
                }  
            }
        }
        private void UseItem()
        {
            if (item != null)
            {
                // TODO determine if item is boost
                item.Consume(this);
                item = null;
            }
        }
    }

}
