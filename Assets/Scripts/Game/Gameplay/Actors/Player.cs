using UnityEngine;
using UnityEngine.UI;
using Gameplay.hud;
using Gameplay.controllers;

namespace Gameplay.actors
{
    public class Player : MonoBehaviour
    {
        //[SerializeField] private Consumable item = null;
        [SerializeField] private string username = ""; // For future instances where the player's username is displayed
        [SerializeField] private ConsumableHud cHud = null;

        public CheckPoint check = null;

        [SerializeField] private Consumable item = null;

        public RaceController raceController = null;
        public PointerController pointer;
        float time;
        public Text finishText;

        Character character;

        // Start is called before the first frame update
        void Start()
        {
            if (CharacterManager.Instance != null)
            {
                character = CharacterManager.Instance.character;
            }
            
            GameObject prefab = Resources.Load(character.route) as GameObject;
            
            GameObject instance = Instantiate(prefab);
            instance.transform.localScale = Vector3.one * 5f;
            instance.transform.parent = this.transform;
            finishText = GameObject.FindGameObjectWithTag("FinishText").GetComponent<Text>();
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

        private void EnterPickUp(Collider other)
        {
            other.gameObject.SetActive(false);
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
        internal void SetFinishTime(float time)
        {
            float min = Mathf.FloorToInt(time / 60);
            float sec = time % 60;
            finishText.text = string.Format("{0:00}:{1}", min, sec.ToString());
        }
    }

}
