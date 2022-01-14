using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.actors;

namespace Gameplay.controllers
{
    public class PointerController : MonoBehaviour
    {
        public Player player;
        public CheckPoint[] checkPoints;
        private CheckPoint currentCheck;
        private int checkId = 0;
        public GameObject pointer;
        // Update is called once per frame

        private void Start()
        {
            currentCheck = checkPoints[checkId];
        }
        void Update()
        {
            // Debug.DrawLine(player.transform.position, currentCheck.transform.position, Color.white);
            Vector3 direction = currentCheck.transform.position  - player.transform.position;
            pointer.transform.rotation = Quaternion.LookRotation(direction, Vector3.up); ;
            pointer.transform.position = player.transform.position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Checkpoint"))
            {
                if (GameObject.ReferenceEquals(other.gameObject, currentCheck.gameObject))
                {
                    currentCheck.GetComponent<CheckPoint>().Check();
                    ++checkId;
                    try
                    {
                        currentCheck = checkPoints[checkId];
                    }
                    catch {}
                                       
                    Debug.Log(checkId);
                }
            }
        }
    }
}

