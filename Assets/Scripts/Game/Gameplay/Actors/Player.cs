using UnityEngine;
using UnityEngine.UI;
using Gameplay.hud;
using Gameplay.controllers;

namespace Gameplay.actors
{
    public class Player : MonoBehaviour
    {
        //[SerializeField] private Consumable item = null;
        [SerializeField] private string name = ""; // For future instances where the player's username is displayed
        [SerializeField] private ConsumableHud cHud = null;
        [SerializeField] private Consumable item = null;
        internal CheckPoint check = null;
        public RaceController raceController = null;
        public PointerController pointer;
        float time;
        public Text finishText;

        // Start is called before the first frame update
        void Start()
        {
            // TODO set raceController dinamically
            raceController.InitializePlayer(this);
            try
            {
                pointer.SetCheck(check);
            }
            catch { }
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
                other.gameObject.SetActive(false);
                Debug.Log("PickUp");
                if (this.item == null)
                {
                    // TODO random select consumible
                    item = this.gameObject.AddComponent<LogConsumable>();
                    //cHud.SetConsumableIndicator(this.item);

                }  
            }
            if (other.gameObject.CompareTag("Checkpoint"))
            {
                this.EnterCheckpoint(other);
            }
        }

        private void UseItem()
        {
            //if (item != null)
            {
                // TODO determine if item is boost
               // item.Consume(this);
                //item = null;
            }
        }

        private void EnterPickUp()
        {
            // Debug.Log("PickUp");
            if (this.item == null)
            {
                this.SetConsumable();
            }
        }

        private void EnterCheckpoint(Collider other)
        {
            Debug.Log("Enter");
            if (GameObject.ReferenceEquals(check.gameObject, other.gameObject)) {
                Debug.Log("True");

                this.raceController.SetPlayerCheckpoint(this, check);
            }
        }

        internal void SetConsumable()
        {
            // TODO random select consumible
            item = this.gameObject.AddComponent<TurboConsumable>();
            //cHud.SetConsumableIndicator(this.item);
        }

        internal void SetCheckpoint(CheckPoint c)
        {
            check = c;
            pointer.SetCheck(check);
        }
        internal void SetFinishTime(float time)
        {
            float min = Mathf.FloorToInt(time / 60);
            float sec = time % 60;
            finishText.text = string.Format("{0:00}:{1}", min, sec.ToString());
        }
    }

}
