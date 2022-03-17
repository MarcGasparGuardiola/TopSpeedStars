using UnityEngine;
using UnityEngine.UI;
using Gameplay.hud;
using Gameplay.controllers;

namespace Gameplay.actors
{
    public class Player : MonoBehaviour
    {
        [SerializeField] internal string username = ""; // For future instances where the player's username is displayed
        [SerializeField] private ConsumableHud cHud = null;
        public CheckPoint check = null;
        public Consumable item = null;
        public RaceController raceController = null;
        public PointerController pointer;
        public float time;
        public bool finished = false;
        

        public Character character;

        // Start is called before the first frame update

        private void Awake()
        {
            username = "PLAYER";
            // TODO ship stats
        }
        void Start()
        {
            if (GameplayManager.Instance != null)
            {
                character = GameplayManager.Instance.character;
            }
            
            GameObject prefab = Resources.Load(character.route) as GameObject;
            
            GameObject instance = Instantiate(prefab,transform);
            instance.transform.localScale = Vector3.one * 5f;
            instance.transform.parent = this.transform;
            
        }

        // Update is called once per frame
        private  void Update()
        {            
            // consume, TODO input adequat
            if (Input.GetKeyDown(KeyCode.I))
            {
                UseItem();
            }
        }

        internal void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                
                this.EnterPickUp(other);
            }
            if (other.gameObject.CompareTag("Checkpoint"))
            {
                this.EnterCheckpoint(other);
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

        internal void EnterPickUp(Collider other)
        {
            other.GetComponent<PickUp>().TimeOut();
            // Debug.Log("PickUp");
            if (this.item == null)
            {
                this.SetConsumable();
            }
        }

        internal void EnterCheckpoint(Collider other)
        {
            
            if (GameObject.ReferenceEquals(check.gameObject, other.gameObject)) {
                // Debug.Log("True");

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
    }

}
