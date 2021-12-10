using UnityEngine;
using Gameplay.hud;

namespace Gameplay.actors
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Consumable item = null;
        [SerializeField] private string name = ""; // For future instances where the player's username is displayed
        [SerializeField] private ConsumableHud cHud = null;
        // Start is called before the first frame update
        void Start()
        {
            //this.item = null;
            
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
            if (other.gameObject.CompareTag("PickUp"))
            {
                // TODO Use PickUP function
                other.GetComponent<PickUp>().TimeOut();
                Debug.Log("PickUp");
                if (this.item == null)
                {
                    // TODO random select consumible
                    item = this.gameObject.AddComponent<TurboConsumable>();
                    //cHud.SetConsumableIndicator(this.item);

                }  
            }
            if (other.gameObject.CompareTag("Checkpoint"))
            {
                // Debug.Log("Checkpoint");
                other.GetComponent<CheckPoint>().Check();
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
