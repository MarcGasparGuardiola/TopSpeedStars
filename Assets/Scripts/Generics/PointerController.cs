using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gameplay.actors;
using Photon.Pun;

namespace Gameplay.controllers
{
    public class PointerController : MonoBehaviour
    {
        public Player player;
        public CheckPoint currentCheck;
        public GameObject pointer;
        public PhotonView view;
        // Update is called once per frame

        private void Start()
        {
            try
            {
                player = transform.parent.GetComponentInChildren<Player>();
                pointer = transform.parent.Find("Pointer").gameObject;
                currentCheck = player.check;
            }
            catch { }
            if (view == null)
            {
                view = transform.parent.GetComponentInChildren<PhotonView>();
            }
            if ((!view.IsMine) && PhotonNetwork.CurrentRoom != null)
            {
                pointer.SetActive(false);
                this.enabled = false;
            }
               
        }
        void Update()
        {
            // Debug.DrawLine(player.transform.position, currentCheck.transform.position, Color.white);
            Vector3 direction = currentCheck.transform.position - player.transform.position;
            pointer.transform.rotation = Quaternion.LookRotation(direction, Vector3.up); ;
            pointer.transform.position = player.transform.position;
        }
        
        internal void SetCheck(CheckPoint newCheck)
        {
            currentCheck = newCheck;
        }
    }
}

