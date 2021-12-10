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
        // Update is called once per frame
        void Update()
        {
            Debug.DrawLine(player.transform.position, checkPoints[0].transform.position, Color.white);

        }
    }
}

