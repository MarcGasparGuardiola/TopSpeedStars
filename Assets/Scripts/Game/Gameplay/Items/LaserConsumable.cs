using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace Gameplay.actors
{
    public class LaserConsumable : Consumable
    {
        public LaserConsumable()
        {
            this.NAME = "LaserConsumable";
        }
        override public string GetName()
        {
            return this.NAME;
        }

        override public void Consume(Player target)
        {
            if (PhotonNetwork.CurrentRoom != null)
            {
                PhotonNetwork.Instantiate("Prefabs/Item/Laser", transform.position, transform.rotation);
            } else
            {
                Debug.Log("Item Used");
                GameObject g = Instantiate(Resources.Load("Prefabs/Item/Laser") as GameObject, transform.position, transform.rotation);
                //g.GetComponent<Rigidbody>().AddForce( transform.rotation.eulerAngles * 0.01f);
            }
           
        }
    }
}
