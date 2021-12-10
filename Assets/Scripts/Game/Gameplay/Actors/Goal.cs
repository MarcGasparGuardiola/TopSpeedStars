using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.actors
{
    public class Goal : CheckPoint
    {
        private Player winner;
        private Player[] playerOrder;
        private void Start()
        {
            winner = null;
        }
        // Update is called once per frame
        void Update()
        {
        
        }

        public new void Check()
        {
            // TODO animation o algo
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && winner == null)
            {
                winner = other.GetComponent<Player>();
            }
        }
    }
}
